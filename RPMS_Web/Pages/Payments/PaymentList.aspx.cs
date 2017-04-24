using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPMS_Database;

namespace RPMS_Web.Pages.Payments
{
    public partial class PaymentList : System.Web.UI.Page
    {
        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();
        private decimal totalBalance = 0M;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                var tenant = db.Tenants.FirstOrDefault(x => x.ID == int.Parse(Request.QueryString["id"]));
                var property = db.Properties.FirstOrDefault(x => x.ID == tenant.PropertyID);
                var state = db.States.FirstOrDefault(x => x.Id == property.StateID);
                var otherTenants = db.Tenants.Where(x => x.ParentID == tenant.ID).ToList();
                var payments = db.RentPayments.Where(x => x.TenantID == tenant.ID);

                litAddress.Text = string.Format("<a href='http://{6}/Pages/Property/PropertyDetail.aspx?id={5}'>{0}{1}<br />{2}, {3} {4}</a>", property.StreetAddress1, (!string.IsNullOrEmpty(property.StreetAddress2) ? "<br />" + property.StreetAddress2 : string.Empty), property.City, state.Code, property.ZipCode, property.ID, HttpContext.Current.Request.Url.Host);


                litTenants.Text = string.Format("<a href='http://{2}/Pages/Tenant/TenantDetail.aspx?id={0}'>{1}</a>", tenant.ID, tenant.FullName, HttpContext.Current.Request.Url.Host);
                otherTenants.ForEach(x => {
                    litTenants.Text += string.Format("<br/><a href='http://{2}/Pages/Tenant/TenantDetail.aspx?id={0}'>{1}</a>", x.ID, x.FullName, HttpContext.Current.Request.Url.Host);
                });

                repPayments.DataSource = payments;
                repPayments.ItemDataBound += new RepeaterItemEventHandler(repPayments_DataBinding);
                repPayments.DataBind();
            }
        }

        protected void repPayments_DataBinding(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = (RepeaterItem) e.Item;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var payment = (RPMS_Database.RentPayment) e.Item.DataItem;
                Literal litPaymentAmount = (Literal) e.Item.FindControl("litPaymentAmount");
                Literal litPaymentDate = (Literal) e.Item.FindControl("litPaymentDate");
                Literal litAmountPaid = (Literal) e.Item.FindControl("litAmountPaid");
                Literal litPaidDate = (Literal) e.Item.FindControl("litPaidDate");
                Literal litBalance = (Literal) e.Item.FindControl("litBalance");
                HyperLink hlLease = (HyperLink) e.Item.FindControl("hlLease");

                litPaymentAmount.Text = payment.PaymentAmount.ToString("##,###.00");
                litPaymentDate.Text = payment.PaymentDate.ToString("MM/dd/yyyy");
                litAmountPaid.Text = (payment.AmountPaid.HasValue) ? payment.AmountPaid.Value.ToString("##,###.00") : string.Empty;
                litPaidDate.Text = (payment.DatePaid.HasValue) ? payment.DatePaid.Value.ToString("MM/dd/yyyy") : string.Empty;
                litBalance.Text = (payment.Balance.HasValue) ? payment.Balance.Value.ToString("##,###.00") : string.Empty;
                totalBalance += (payment.Balance.HasValue) ? payment.Balance.Value : 0M;

                hlLease.NavigateUrl = string.Format("MakePayment.aspx?id={0}", payment.ID);

                if (payment.Balance.HasValue)
                {
                    if (payment.Balance.Value == 0)
                    {
                        hlLease.Text = "Edit Payment";
                    }
                }

            }
            if(e.Item.ItemType == ListItemType.Footer)
            {
                Literal litTotalBalance = (Literal) e.Item.FindControl("litTotalBalance");
                litTotalBalance.Text = totalBalance.ToString("###,###.00");
            }
        }
    }
}