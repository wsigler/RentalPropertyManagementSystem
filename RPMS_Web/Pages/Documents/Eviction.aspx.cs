using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPMS_Database;

namespace RPMS_Web.Pages.Documents
{
    public partial class Eviction : System.Web.UI.Page
    {
        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                var tenant = db.Tenants.FirstOrDefault(x => x.ID == int.Parse(Request.QueryString["id"]));
                var otherTenants = db.Tenants.Where(x => x.ParentID == tenant.ID).ToList();
                var property = db.Properties.FirstOrDefault(x => x.ID == tenant.PropertyID);
                var state = db.States.FirstOrDefault(x => x.Id == property.StateID);
                var payments = db.Payments.Where(x => x.TenantID == tenant.ID && x.DueDate < DateTime.Now).ToList();

                var rentPayments = payments.Where(x => x.TypeID == 5000);
                var dailyLatePayments = payments.Where(x => x.TypeID == 5001);
                var initialLatePayments = payments.Where(x => x.TypeID == 5002);
                var returnCheck = payments.Where(x => x.TypeID == 5003);


                decimal totalAmountDue = 0M;

                payments.ForEach(x => {
                    totalAmountDue += x.Balance;
                });

                litTenantNames.Text = tenant.FullName;
                otherTenants.ForEach(x => {
                    litTenantNames.Text += string.Format("<br/>{0}", x.FullName);
                });
                litTenantNames2.Text = litTenantNames.Text;

                litAddress.Text = string.Format("{0}{1}<br />{2}, {3} {4}", property.StreetAddress1, (!string.IsNullOrEmpty(property.StreetAddress2) ? "<br />" + property.StreetAddress2 : string.Empty), property.City, state.Code, property.ZipCode);
                litDateOfNotice2.Text = litDateOfNotice.Text = DateTime.Now.ToString("MMMM dd, yyyy");
                litStreetAddress2.Text = litStreetAddress.Text = property.StreetAddress1;
                litPastDueAmount.Text = string.Format("{0}<br/>{1}<br/>{2}<br/>{3}<br/>{4}", totalAmountDue.ToString("###,##0.00"), "Rent: $" + rentPayments.Sum(x => x.Balance).ToString("##,##0.00"), "Late Payments: $"+ initialLatePayments.Sum(x => x.Balance).ToString("##,##0.00"), "Daily Late Payments: $" + dailyLatePayments.Sum(x => x.Balance).ToString("##,##0.00"), "Returned Checks: $" + returnCheck.Sum(x => x.Balance).ToString("##,###.00"));
                litCounty.Text = property.County;
            }
        }
    }
}