using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPMS_Database;

namespace RPMS_Web.Pages.Documents
{
    public partial class NoticeOfEntry : System.Web.UI.Page
    {
        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && Request.QueryString["reason"] != null && Request.QueryString["date"] != null && Request.QueryString["time"] != null)
            {
                
                var tenant = db.Tenants.FirstOrDefault(x => x.ID == int.Parse(Request.QueryString["id"]));

                if (tenant.ParentID.HasValue)
                {
                    var parentId = tenant.ParentID;
                    tenant = db.Tenants.FirstOrDefault(x => x.ID == parentId);
                }
                var tenants = db.Tenants.Where(x => x.ParentID == tenant.ID).ToList();
                var property = db.Properties.FirstOrDefault(x => x.ID == tenant.PropertyID);
                var state = db.States.FirstOrDefault(x => x.Id == property.StateID);
                var lease = db.LeaseInfos.FirstOrDefault(x => x.PropertyID == property.ID && x.IsCurrentLease == true);
                litDateOfLetter.Text = DateTime.Now.ToString("MMMM dd, yyyy");
                litTenants.Text = string.Format("{0}{1}{2}", tenant.FirstName + " ", (!string.IsNullOrEmpty(tenant.MiddleName) ? tenant.MiddleName + " " : ""), tenant.LastName);
                tenants.ForEach(x =>
                {
                    litTenants.Text += string.Format("<br/>{0}{1}{2}", x.FirstName + " ", (!string.IsNullOrEmpty(x.MiddleName) ? x.MiddleName + " " : ""), x.LastName);
                });
                litStreet.Text = property.StreetAddress1;
                litCityStateZip.Text = string.Format("{0}, {1} {2}", property.City, state.Code, property.ZipCode);
                litReasonsForEntry.Text = Request.QueryString["reason"];
                litDateOfEntry.Text = Request.QueryString["date"];
                litTimeOfEntry.Text = Request.QueryString["time"];
            }
        }
    }
}