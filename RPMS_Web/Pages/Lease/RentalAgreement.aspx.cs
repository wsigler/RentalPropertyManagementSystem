using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPMS_Database;
using RPMS_BusinessLogic;
using System.Configuration;
using System.IO;

namespace RPMS_Web.Pages.Lease
{
    public partial class RentalAgreement : System.Web.UI.Page
    {
        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();
        private List<State> states = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            states = db.States.ToList();
            if (!IsPostBack)
            {
                if (Request.QueryString["TenantId"] != null)
                {
                    if (Request.QueryString["renewal"] != null)
                    {
                        PopulateRenewalTenantLease(int.Parse(Request.QueryString["TenantId"]));
                    }
                    else
                    {
                        PopulateTenantLease(int.Parse(Request.QueryString["TenantId"]));
                    }
                }
                else
                {
                    if (Request.QueryString["PropertyId"] != null)
                    {
                        PopulatePropertyLease(int.Parse(Request.QueryString["PropertyId"]));
                    }
                }
            }
        }

        #region Populate Form Data

        private void PopulatePropertyLease(int PropertyId)
        {
            var property = db.Properties.FirstOrDefault(x => x.ID == PropertyId);
            divTenants.Visible = false;
            litAddress.Text = string.Format("{0}{1}<br />{2}, {3} {4}", property.StreetAddress1, (!string.IsNullOrEmpty(property.StreetAddress2) ? "<br />" + property.StreetAddress2 : string.Empty), property.City, states.FirstOrDefault(x => x.Id == property.StateID).Code, property.ZipCode);
            txtRent.Text = property.RentAmount.ToString("#,##0.##");
            txtDeposit.Text = property.DepositAmount.ToString("#,##0.##");
            txtPetDeposit.Text = property.PetDepositAmount.ToString("#,##0.##");
            txtStartDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            txtEndDate.Text = DateTime.Now.AddDays(365).ToString("MM/dd/yyyy");
            txtDepositDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        private void PopulateTenantLease(int tenantId)
        {
            var tenant = db.Tenants.FirstOrDefault(x => x.ID == tenantId);
            List<RPMS_Database.Tenant> otherTenants = new List<RPMS_Database.Tenant>();
            if(tenant.ParentID.HasValue)
            {
                var parentId = tenant.ParentID;
                otherTenants.AddRange(db.Tenants.Where(x => x.ParentID == parentId && x.IsActive == true));
                tenant = db.Tenants.FirstOrDefault(x => x.ID == parentId);
            }
            else
            {
                otherTenants.AddRange(db.Tenants.Where(x => x.ParentID == tenant.ID && x.IsActive == true));
            }
            var property = db.Properties.FirstOrDefault(x => x.ID == tenant.PropertyID);

            litAddress.Text = string.Format("{0}{1}<br />{2}, {3} {4}", property.StreetAddress1, (!string.IsNullOrEmpty(property.StreetAddress2) ? "<br />" + property.StreetAddress2 : string.Empty), property.City, states.FirstOrDefault(x => x.Id == property.StateID).Code, property.ZipCode);
            litName.Text = string.Format("{0}{1}{2} ({3})", tenant.FirstName + " ", (!string.IsNullOrEmpty(tenant.MiddleName) ? tenant.MiddleName + " " : ""), tenant.LastName, tenant.FullName);
            txtRent.Text = property.RentAmount.ToString("#,##0.##");
            txtDeposit.Text = property.DepositAmount.ToString("#,##0.##");
            txtPetDeposit.Text = property.PetDepositAmount.ToString("#,##0.##");
            txtStartDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            txtEndDate.Text = DateTime.Now.AddDays(365).ToString("MM/dd/yyyy");
            txtDepositDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            litEmail.Text = tenant.Email;
            litOtherTenants.Text = string.Empty;
            otherTenants.ForEach(x => {
                litOtherTenants.Text += string.Format("Name: {0}{1}{2} ({3}) <br/>", x.FirstName + " ", (!string.IsNullOrEmpty(x.MiddleName) ? x.MiddleName + " " : ""), x.LastName, x.FullName);
            });
        }

        private void PopulateRenewalTenantLease(int tenantId)
        {
            var tenant = db.Tenants.FirstOrDefault(x => x.ID == tenantId);
            var lease = db.LeaseInfos.FirstOrDefault(x => x.IsCurrentLease == true && x.TenantID == tenant.ID);

            List<RPMS_Database.Tenant> otherTenants = new List<RPMS_Database.Tenant>();
            if (tenant.ParentID.HasValue)
            {
                var parentId = tenant.ParentID;
                otherTenants.AddRange(db.Tenants.Where(x => x.ParentID == parentId && x.IsActive == true));
                tenant = db.Tenants.FirstOrDefault(x => x.ID == parentId);
            }
            else
            {
                otherTenants.AddRange(db.Tenants.Where(x => x.ParentID == tenant.ID));
            }
            var property = db.Properties.FirstOrDefault(x => x.ID == lease.PropertyID);

            litAddress.Text = string.Format("{0}{1}<br />{2}, {3} {4}", property.StreetAddress1, (!string.IsNullOrEmpty(property.StreetAddress2) ? "<br />" + property.StreetAddress2 : string.Empty), property.City, states.FirstOrDefault(x => x.Id == property.StateID).Code, property.ZipCode);
            litName.Text = string.Format("{0}{1}{2} ({3})", tenant.FirstName + " ", (!string.IsNullOrEmpty(tenant.MiddleName) ? tenant.MiddleName + " " : ""), tenant.LastName, tenant.FullName);
            txtRent.Text = lease.RentAmount.ToString("#,##0.##");
            txtDeposit.Text = lease.DepositAmount.ToString("#,##0.##");
            txtPetDeposit.Text = lease.PetDepositAmount.ToString("#,##0.##");
            txtStartDate.Text = (lease.StartDate.HasValue) ? lease.EndDate.Value.AddDays(1).ToString("MM/dd/yyyy") : DateTime.Now.ToString("MM/dd/yyyy");
            txtEndDate.Text = (lease.EndDate.HasValue) ? lease.EndDate.Value.AddDays(365).ToString("MM/dd/yyyy") : DateTime.Now.AddDays(365).ToString("MM/dd/yyyy");
            txtDepositDate.Text = (lease.DepositDate.HasValue) ? lease.DepositDate.Value.ToString("MM/dd/yyyy") : DateTime.Now.ToString("MM/dd/yyyy");
            litEmail.Text = tenant.Email;
            litOtherTenants.Text = string.Empty;
            otherTenants.ForEach(x => {
                litOtherTenants.Text += string.Format("Name: {0}{1}{2} ({3}) <br/>", x.FirstName + " ", (!string.IsNullOrEmpty(x.MiddleName) ? x.MiddleName + " " : ""), x.LastName, x.FullName);
            });
            txtNumberOfChildren.Text = (lease.NumberOfChildren.HasValue) ? lease.NumberOfChildren.Value.ToString() : "0";
            txtMaxNumOfOccupants.Text = (lease.MaxNumberOfOccupants.HasValue) ? lease.MaxNumberOfOccupants.Value.ToString() : "5";
        }

        private RPMS_Database.LeaseInfo PopulateFromFormData(RPMS_Database.LeaseInfo lease)
        {
            lease.RentAmount = decimal.Parse(txtRent.Text);
            lease.DepositAmount = decimal.Parse(txtDeposit.Text);
            lease.PetDepositAmount = decimal.Parse(txtPetDeposit.Text);
            lease.StartDate = DateTime.Parse(txtStartDate.Text);
            lease.EndDate = DateTime.Parse(txtEndDate.Text);
            lease.DepositDate = DateTime.Parse(txtDepositDate.Text);
            lease.IsCurrentLease = true;
            lease.NumberOfChildren = (!string.IsNullOrEmpty(txtNumberOfChildren.Text)) ? int.Parse(txtNumberOfChildren.Text) : 0;
            lease.MaxNumberOfOccupants = (!string.IsNullOrEmpty(txtMaxNumOfOccupants.Text)) ? int.Parse(txtMaxNumOfOccupants.Text) : 5;

            return lease;
        }

        #endregion

        #region Button Clicks

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            LeaseInfo lease = new LeaseInfo();
            int propertyID = 0;

            if (Request.QueryString["renewal"] != null)
            {
                if (Request.QueryString["TenantId"] != null)
                {
                    lease = db.LeaseInfos.FirstOrDefault(x => x.IsCurrentLease == true && x.TenantID == int.Parse(Request.QueryString["TenantId"]));
                }

                LeaseInfo extendedLease = new LeaseInfo();
                extendedLease = PopulateFromFormData(extendedLease);

                extendedLease.PropertyID = lease.PropertyID;
                extendedLease.TenantID = lease.TenantID;
                
                new RPMS_Database.LeaseInfoDAL().InsertLeaseInfo(extendedLease);

                lease = db.LeaseInfos.FirstOrDefault(x => x.IsCurrentLease == true && x.PropertyID == extendedLease.PropertyID);
            }
            else
            {
                if (Request.QueryString["TenantId"] != null)
                {
                    var tenant = db.Tenants.FirstOrDefault(x => x.ID == int.Parse(Request.QueryString["TenantId"]));

                    List<RPMS_Database.Tenant> otherTenants = new List<RPMS_Database.Tenant>();
                    if (tenant.ParentID.HasValue)
                    {
                        var parentId = tenant.ParentID;
                        otherTenants.AddRange(db.Tenants.Where(x => x.ParentID == parentId && x.IsActive == true));
                        tenant = db.Tenants.FirstOrDefault(x => x.ID == parentId);
                    }
                    var property = db.Properties.FirstOrDefault(x => x.ID == tenant.PropertyID);

                    lease.TenantID = tenant.ID;
                    lease.PropertyID = tenant.PropertyID;
                    

                    propertyID = property.ID;
                }

                if (Request.QueryString["PropertyId"] != null)
                {

                    propertyID = lease.PropertyID = int.Parse(Request.QueryString["PropertyId"]);
                }
                lease = PopulateFromFormData(lease);
                
                new RPMS_Database.LeaseInfoDAL().InsertLeaseInfo(lease);

                lease = db.LeaseInfos.FirstOrDefault(x => x.IsCurrentLease == true && x.PropertyID == propertyID);

            }

            // relative directory
            string relativeDir = (lease.TenantID.HasValue) ? string.Format("Tenants\\Tenant_{0}", lease.TenantID.Value) : string.Format("Properties\\Property_{0}", lease.PropertyID);

            // get directory path
            string leaseDir = ConfigurationManager.AppSettings["FileLocation"] + relativeDir;

            var host = ConfigurationManager.AppSettings["HostLocation"];
            new RPMS_BusinessLogic.PDFConverter().ConvertToPDF(host, leaseDir,
                string.Format("/Lease {0} - {1}", lease.StartDate.Value.ToString("yyyy-MM-dd"), lease.EndDate.Value.ToString("yyyy-MM-dd")),
                string.Format("http://{0}/Pages/Lease/Lease.aspx?id={1}", host, lease.ID));

            if (lease.TenantID.HasValue)
            {
                Response.Redirect(string.Format("~/Pages/Tenant/TenantDetail.aspx?id={0}", lease.TenantID.Value));
            }
            else
            {
                Response.Redirect(string.Format("~/Pages/Property/PropertyDetail.aspx?id={0}", lease.PropertyID));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeaseList.aspx");
        }

        #endregion


    }
}