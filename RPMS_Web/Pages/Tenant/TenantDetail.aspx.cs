using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPMS_Database;
using System.Configuration;
using System.IO;

namespace RPMS_Web.Pages.Tenant
{
    public partial class TenantDetail : System.Web.UI.Page
    {
        #region Page Variables

        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();
        private List<RPMS_Database.Property> properties = null;
        private List<State> states = null;
        private RPMS_Database.Tenant tenant = null;

        #endregion

        #region Load

        protected void Page_Load(object sender, EventArgs e)
        {
            properties = db.Properties.Where(x => x.IsActive == true).OrderBy(o => o.StreetAddress1).ToList();
            states = db.States.ToList();
            string relativeDir = string.Empty;

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    tenant = db.Tenants.FirstOrDefault(x => x.ID == int.Parse(Request.QueryString["id"]));
                    var parentTenant = (tenant.ParentID.HasValue) ? db.Tenants.FirstOrDefault(x => x.IsActive == true && x.ID == tenant.ParentID) : tenant;

                    var lease = db.LeaseInfos.FirstOrDefault(x => x.IsCurrentLease == true && x.TenantID == parentTenant.ID);

                    hlCreateLeaseInfo.NavigateUrl = (lease == null) ? string.Format("~/Pages/Lease/RentalAgreement.aspx?TenantId={0}", parentTenant.ID) : string.Format("~/Pages/Lease/RentalAgreement.aspx?TenantId={0}&renewal=1", parentTenant.ID);
                    hlCreateLeaseInfo.Text = (lease == null) ? "Create Lease" : "Renew Lease";

                    hlEditTenant.NavigateUrl = string.Format("TenantAction.aspx?id={0}", tenant.ID);

                    // relative directory
                    relativeDir = string.Format("Tenants\\Tenant_{0}", parentTenant.ID);
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
                    fmCustomers.RootDirectories[0].Text = "Tenant " + parentTenant.ID.ToString();



                    PopulateDetails();
                }
            }
            

            
        }

        #region Populate Data

        private void PopulateDetails()
        {
            var user = db.Users.FirstOrDefault(x => x.ID == tenant.CreatedBy);
            var modifyUser = (tenant.ModifiedBy.HasValue) ? db.Users.FirstOrDefault(x => x.ID == tenant.ModifiedBy) : new User();
            var dlState = states.FirstOrDefault(x => x.Id == tenant.DriversLicenseStateID);
            var primary = (tenant.ParentID.HasValue) ? db.Tenants.FirstOrDefault(x => x.ID == tenant.ParentID.Value) : new RPMS_Database.Tenant();
            var property = properties.FirstOrDefault(x => x.ID == tenant.PropertyID);
            var state = states.FirstOrDefault(x => x.Id == property.StateID);

            litName.Text = string.Format("{0}{1}{2} ({3})", tenant.FirstName + " ", (!string.IsNullOrEmpty(tenant.MiddleName) ? tenant.MiddleName + " " : ""), tenant.LastName, tenant.FullName);
            litEmail.Text = tenant.Email;
            litPhoneNumber.Text = (!string.IsNullOrEmpty(tenant.Phone)) ? tenant.Phone : "";
            litDriversLicense.Text = (!string.IsNullOrEmpty(tenant.DriversLicense)) ? string.Format("{0} {1}", tenant.DriversLicense, dlState.Code) : string.Empty;
            litSSN.Text = tenant.SSN;
            hlPrimaryFullName.Text = (tenant.ParentID.HasValue) ? string.Format("{0}", primary.FullName) : string.Empty;
            hlPrimaryFullName.NavigateUrl = (tenant.ParentID.HasValue) ? string.Format("TenantDetail.aspx?id={0}", tenant.ParentID.Value) : string.Empty;
            litPrimary.Visible = (tenant.ParentID.HasValue);
            litCreateAudit.Text = string.Format("Created on {0} by {1}", tenant.DateCreated, user.FullName);
            litModifyAudit.Text = (tenant.ModifiedBy.HasValue) ? string.Format("Last modified on {0} by {1}", tenant.DateModified, modifyUser.FullName) : string.Empty;

            hlAddress.Text = string.Format("{0}{1}<br />{2}, {3} {4}", property.StreetAddress1, (!string.IsNullOrEmpty(property.StreetAddress2) ? "<br />" + property.StreetAddress2 : string.Empty), property.City, state.Code, property.ZipCode);
            hlAddress.NavigateUrl = string.Format("~/Pages/Property/PropertyDetail.aspx?id={0}", property.ID);

        }

        #endregion

        #endregion
    }
}