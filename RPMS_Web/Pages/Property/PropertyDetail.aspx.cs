using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPMS_Database;
using System.Configuration;
using System.IO;

namespace RPMS_Web.Pages.Property
{
    public partial class PropertyDetail : System.Web.UI.Page
    {
        #region Page Variables

        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();
        private List<State> states = null;
        private List<Dictionary> trashDays = null;
        private RPMS_Database.Property property = null;
        private List<RPMS_Database.Tenant> tenants = null;

        #endregion

        #region Load

        protected void Page_Load(object sender, EventArgs e)
        {
            states = db.States.ToList();
            trashDays = db.Dictionaries.Where(x => x.Category == "DaysOfTheWeek").ToList();
            string relativeDir = string.Empty;

            if (Request.QueryString["id"] != null)
            {
                property = db.Properties.FirstOrDefault(x => x.ID == int.Parse(Request.QueryString["id"]));
                hlEditProperty.NavigateUrl = string.Format("PropertyAction.aspx?id={0}", property.ID);
                var lease = db.LeaseInfos.FirstOrDefault(x => x.IsCurrentLease == true && x.PropertyID == property.ID);
                tenants = (lease != null) ? db.Tenants.Where(x => x.IsActive == true && x.PropertyID == property.ID).ToList() : new List<RPMS_Database.Tenant>();

                PopulateDetails();

                // relative directory
                relativeDir = string.Format("Properties\\Property_{0}", property.ID);
                // get directory path
                string tenantDir = ConfigurationManager.AppSettings["FileLocation"] + relativeDir;

                // check for customer directory...create if it doesn't exist
                if (!Directory.Exists(tenantDir))
                {
                    // create dir
                    Directory.CreateDirectory(tenantDir);
                }

                // use virtual directory
                fmCustomers.RootDirectories[0].DirectoryPath = "/files/" + relativeDir.Replace("\\", "/");
                fmCustomers.RootDirectories[0].Text = "Property " + property.StreetAddress1;
            }
        }

        private void PopulateDetails()
        {
            var state = states.FirstOrDefault(x => x.Id == property.StateID);
            var trashDay = trashDays.FirstOrDefault(x => x.ID == property.TrashDayID);
            var user = db.Users.FirstOrDefault(x => x.ID == property.CreatedBy);
            var modifyUser = (property.ModifiedBy.HasValue) ? db.Users.FirstOrDefault(x => x.ID == property.ModifiedBy) : new User();
            var primaryTenant = tenants.FirstOrDefault(x => x.ParentID == null);
            var otherTenants = tenants.Where(x => x.ParentID != null).ToList();

            litAddress.Text = string.Format("{0}{1}<br />{2}, {3} {4}", property.StreetAddress1, (!string.IsNullOrEmpty(property.StreetAddress2) ? "<br />" + property.StreetAddress2 : string.Empty), property.City, state.Code, property.ZipCode);
            litActive.Text = (property.IsActive) ? "Yes" : "No";
            litIsRented.Text = (property.IsRented) ? "Yes" : "No";
            litLat.Text = (property.Lat.HasValue) ? property.Lat.Value.ToString("####.######") : string.Empty;
            litLong.Text = (property.Long.HasValue) ? property.Long.Value.ToString("####.######") : string.Empty;
            litEstimatedTax.Text = (property.EstimatedTax.HasValue) ? property.EstimatedTax.Value.ToString("###,##0.00") : string.Empty;
            litSquareFootageEst.Text = (property.SquareFootageEst.HasValue) ? property.SquareFootageEst.Value.ToString() : string.Empty;
            litRentAmount.Text = property.RentAmount.ToString("#,##0.00");
            litDepositAmount.Text = property.DepositAmount.ToString("#,##0.00");
            litPetDepositAmount.Text = property.PetDepositAmount.ToString("#,##0.00");
            litNumberOfBedrooms.Text = property.NumberOfBedrooms.ToString();
            litNumberOfBathrooms.Text = property.NumberOfBathrooms.ToString();
            litDayOfTheWeek.Text = (trashDay != null) ? trashDay.EntryName : string.Empty;
            litHasWDConnection.Text = (property.HasWDConnection) ? "Yes" : "No";
            litHasCentralAC.Text = (property.HasCentralAC) ? "Yes" : "No";
            litCreateAudit.Text = string.Format("Created on {0} by {1}", property.DateCreated, user.FullName);
            litModifyAudit.Text = (property.ModifiedBy.HasValue) ? string.Format("Last modified on {0} by {1}", property.DateModified, modifyUser.FullName) : string.Empty;

            
            if(tenants.Count > 0)
            {
                litTenantLable.Visible = true;
                litCurrentTenant.Visible = true;
                litCurrentTenant.Text = string.Format("<a href='http://{0}/Pages/Tenant/TenantDetail.aspx?id={1}'>{2}</a>", HttpContext.Current.Request.Url.Host, primaryTenant.ID, primaryTenant.FullName);
                otherTenants.ForEach(x => {
                    litCurrentTenant.Text += string.Format("<br/><a href='http://{0}/Pages/Tenant/TenantDetail.aspx?id={1}'>{2}</a>", HttpContext.Current.Request.Url.Host, x.ID, x.FullName);
                });
            }
            else
            {
                litTenantLable.Visible = false;
                litCurrentTenant.Visible = false;
            }
            
        }

        #endregion
    }
}