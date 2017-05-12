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
        private List<Dictionary> dictionaries = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                var tenant = db.Tenants.FirstOrDefault(x => x.ID == int.Parse(Request.QueryString["id"]));
                var property = db.Properties.FirstOrDefault(x => x.ID == tenant.PropertyID);
                var state = db.States.FirstOrDefault(x => x.Id == property.StateID);
                var otherTenants = db.Tenants.Where(x => x.ParentID == tenant.ID).ToList();
                var payments = db.Payments.Where(x => x.TenantID == tenant.ID);

                dictionaries = db.Dictionaries.Where(x => x.Category == "Payments").ToList();

                litAddress.Text = string.Format("<a href='http://{6}/Pages/Property/PropertyDetail.aspx?id={5}'>{0}{1}<br />{2}, {3} {4}</a>", property.StreetAddress1, (!string.IsNullOrEmpty(property.StreetAddress2) ? "<br />" + property.StreetAddress2 : string.Empty), property.City, state.Code, property.ZipCode, property.ID, HttpContext.Current.Request.Url.Host);


                litTenants.Text = string.Format("<a href='http://{2}/Pages/Tenant/TenantDetail.aspx?id={0}'>{1}</a>", tenant.ID, tenant.FullName, HttpContext.Current.Request.Url.Host);
                otherTenants.ForEach(x => {
                    litTenants.Text += string.Format("<br/><a href='http://{2}/Pages/Tenant/TenantDetail.aspx?id={0}'>{1}</a>", x.ID, x.FullName, HttpContext.Current.Request.Url.Host);
                });

                repPayments.DataSource = payments.OrderBy(x => x.DueDate).ToList();
                repPayments.ItemDataBound += new RepeaterItemEventHandler(repPayments_DataBinding);
                repPayments.DataBind();
            }
        }

        protected void repPayments_DataBinding(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = (RepeaterItem) e.Item;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var payment = (RPMS_Database.Payment) e.Item.DataItem;
                Literal litAmountDue = (Literal) e.Item.FindControl("litAmountDue");
                Literal litType = (Literal) e.Item.FindControl("litType");
                Literal litDueDate = (Literal) e.Item.FindControl("litDueDate");
                Literal litPaymentAmount = (Literal) e.Item.FindControl("litPaymentAmount");
                Literal litPaymentDate = (Literal) e.Item.FindControl("litPaymentDate");
                Literal litBalance = (Literal) e.Item.FindControl("litBalance");
                HyperLink hlLease = (HyperLink) e.Item.FindControl("hlLease");

                litAmountDue.Text = payment.AmountDue.ToString("##,###.00");
                litDueDate.Text = payment.DueDate.ToString("MM/dd/yyyy");
                litPaymentAmount.Text = (payment.PaymentAmount.HasValue) ? payment.PaymentAmount.Value.ToString("##,###.00") : string.Empty;
                litPaymentDate.Text = (payment.PaymentDate.HasValue) ? payment.PaymentDate.Value.ToString("MM/dd/yyyy") : string.Empty;
                litBalance.Text = payment.Balance.ToString("##,###.00");
                totalBalance += payment.Balance;
                litType.Text = dictionaries.FirstOrDefault(x => x.ID == payment.TypeID).EntryName;

                hlLease.NavigateUrl = string.Format("MakePayment.aspx?id={0}", payment.ID);

                if (payment.Balance == 0)
                {
                    hlLease.Text = "Edit Payment";
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