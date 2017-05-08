using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPMS_Database;
using RPMS_BusinessLogic;

namespace RPMS_Web.Pages.Payments
{
    public partial class MakePayment : System.Web.UI.Page
    {
        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();
        private RPMS_Database.Payment payment = null;
        private Enums.PaymentTypes paymentTypes = new Enums.PaymentTypes();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["id"] != null)
            {
                payment = db.Payments.FirstOrDefault(x => x.ID == int.Parse(Request.QueryString["id"]));

                if (!IsPostBack)
                {
                    PopulateForm();
                }
            }
        }

        private void PopulateForm()
        {
            var tenant = db.Tenants.FirstOrDefault(x => x.ID == payment.TenantID);
            var property = db.Properties.FirstOrDefault(x => x.ID == tenant.PropertyID);
            var state = db.States.FirstOrDefault(x => x.Id == property.StateID);
            var otherTenants = db.Tenants.Where(x => x.ParentID == tenant.ID).ToList();

            litAddress.Text = string.Format("<a href='http://{6}/Pages/Property/PropertyDetail.aspx?id={5}'>{0}{1}<br />{2}, {3} {4}</a>", property.StreetAddress1, (!string.IsNullOrEmpty(property.StreetAddress2) ? "<br />" + property.StreetAddress2 : string.Empty), property.City, state.Code, property.ZipCode, property.ID, HttpContext.Current.Request.Url.Host);

            litTenants.Text = string.Format("<a href='http://{2}/Pages/Tenant/TenantDetail.aspx?id={0}'>{1}</a>", tenant.ID, tenant.FullName, HttpContext.Current.Request.Url.Host);
            otherTenants.ForEach(x => {
                litTenants.Text += string.Format("<br/><a href='http://{2}/Pages/Tenant/TenantDetail.aspx?id={0}'>{1}</a>", x.ID, x.FullName, HttpContext.Current.Request.Url.Host);
            });

            hlBackToList.NavigateUrl = string.Format("~/Pages/Payments/PaymentList.aspx?id={0}", Request.QueryString["id"]);

            litAmountDue.Text = payment.AmountDue.ToString("##,###.00");
            litDueDate.Text = payment.DueDate.ToString("MM/dd/yyyy");
            txtPaymentAmount.Text = (payment.PaymentAmount.HasValue) ? payment.PaymentAmount.Value.ToString("##,###.00") : payment.AmountDue.ToString("##,###.00");
            txtPaymentDate.Text = (payment.PaymentDate.HasValue) ? payment.PaymentDate.Value.ToString("MM/dd/yyyy") : DateTime.Now.ToString("MM/dd/yyyy");
            litBalance.Text = payment.Balance.ToString("##,###.00");
            
        }

        protected void btnSubmitPayment_Click(object sender, EventArgs e)
        {
            if (payment != null)
            {
                payment.PaymentAmount = decimal.Parse(txtPaymentAmount.Text);
                payment.PaymentDate = DateTime.Parse(txtPaymentDate.Text);
                payment.Balance = payment.AmountDue - decimal.Parse(txtPaymentAmount.Text);

                //if (payment.Balance == payment.AmountDue)
                //{
                //    payment.Balance = payment.AmountDue - decimal.Parse(txtPaymentAmount.Text);
                //}
                //else
                //{
                //    if(payment.Balance == 0)
                //    {
                //        
                //    }
                //    else
                //    {
                //        if(payment.Balance < payment.AmountDue)
                //        { }
                //    }
                //}
                
                payment.ModifiedDate = DateTime.Now;
                payment.ModifiedBy = 1;
            }

            new PaymentDAL().UpdatePayment(payment);

            Response.Redirect(string.Format("PaymentList.aspx?id={0}", payment.TenantID));
        }
    }
}