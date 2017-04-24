using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPMS_Database;

namespace RPMS_Web.Pages.Payments
{
    public partial class MakePayment : System.Web.UI.Page
    {
        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();
        private RPMS_Database.RentPayment payment = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["id"] != null)
            {
                payment = db.RentPayments.FirstOrDefault(x => x.ID == int.Parse(Request.QueryString["id"]));

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

            litPaymentAmount.Text = payment.PaymentAmount.ToString("##,###.00");
            litPaymentDate.Text = payment.PaymentDate.ToString("MM/dd/yyyy");
            txtAmountPaid.Text = (payment.AmountPaid.HasValue) ? payment.AmountPaid.Value.ToString("##,###.00") : payment.PaymentAmount.ToString("##,###.00");
            txtDatePaid.Text = (payment.DatePaid.HasValue) ? payment.DatePaid.Value.ToString("MM/dd/yyyy") : DateTime.Now.ToString("MM/dd/yyyy");
            litBalance.Text = (payment.Balance.HasValue) ? payment.Balance.Value.ToString("##,###.00") : string.Empty;
            
        }

        protected void btnSubmitPayment_Click(object sender, EventArgs e)
        {
            if (payment != null)
            {
                payment.AmountPaid = decimal.Parse(txtAmountPaid.Text);
                payment.DatePaid = DateTime.Parse(txtDatePaid.Text);
                payment.Balance = payment.PaymentAmount - decimal.Parse(txtAmountPaid.Text);
                payment.ModifiedDate = DateTime.Now;
                payment.ModifiedBy = 1;
            }

            new RentPaymentDAL().UpdatePayment(payment);

            Response.Redirect(string.Format("PaymentList.aspx?id={0}", payment.TenantID));
        }
    }
}