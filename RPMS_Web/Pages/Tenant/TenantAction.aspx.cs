using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPMS_Database;

namespace RPMS_Web.Pages.Tenant
{
    public partial class TenantAction : System.Web.UI.Page
    {
        #region Page Variables

        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();
        private List<RPMS_Database.Property> properties = null;
        private List<State> states = null;
        private RPMS_Database.Tenant editTenant = null;

        #endregion

        #region Load

        protected void Page_Load(object sender, EventArgs e)
        {
            properties = db.Properties.Where(x => x.IsActive == true).OrderBy(o => o.StreetAddress1).ToList();
            states = db.States.ToList();

            if (!IsPostBack)
            {
                litHeader.Text = "Add Tenant";
                //hlEditTenant.Visible = false;
                cbIsActive.Visible = false;
                if (Request.QueryString["id"] != null)
                {
                    editTenant = db.Tenants.FirstOrDefault(x => x.ID == int.Parse(Request.QueryString["id"]));
                    litHeader.Text = "Edit Tenant";
                    btnCreate.Text = "Update";
                    PopulateForm();
                    PopulatePrimaryTenantDDL(editTenant.PropertyID);
                    
                    cbIsActive.Visible = true;
                    cbIsActive.Checked = editTenant.IsActive;
                }

                PopulatePropertyDDL();
                PopulateDLStateDDL();
            }
        }

        #region Populate Form Items

        private void PopulateForm()
        {
           txtFirstName.Text = editTenant.FirstName;
           txtMiddleName.Text = editTenant.MiddleName;
           txtLastName.Text = editTenant.LastName;
           txtFullName.Text = editTenant.FullName;
           txtPhone.Text = editTenant.Phone;
           txtSSN.Text = editTenant.SSN;
           txtEmail.Text = editTenant.Email;
           txtDriversLicense.Text = editTenant.DriversLicense;
        }

        private void PopulateDLStateDDL()
        {
            ddlDriversLicenseStateID.DataSource = states;
            ddlDriversLicenseStateID.DataTextField = "Code";
            ddlDriversLicenseStateID.DataValueField = "ID";
            ddlDriversLicenseStateID.DataBind();

            ddlDriversLicenseStateID.Items.Insert(0, new ListItem("-- Select --", "0"));

            if (editTenant != null)
            {
                ddlDriversLicenseStateID.SelectedIndex = ddlDriversLicenseStateID.Items.IndexOf(ddlDriversLicenseStateID.Items.FindByValue(editTenant.DriversLicenseStateID.ToString()));
            }
        }

        private void PopulatePropertyDDL()
        {
            properties.ForEach(x => {
                var state = states.FirstOrDefault(s => s.Id == x.StateID);
                ListItem item = new ListItem();
                item.Text = string.Format("{0} {1}, {2}", x.StreetAddress1, x.City, state.Code);
                item.Value = x.ID.ToString();
                ddlProperty.Items.Add(item);
            });

            ddlProperty.Items.Insert(0, new ListItem("-- Select --", "0"));

            if (editTenant != null)
            {
                ddlProperty.SelectedIndex = ddlProperty.Items.IndexOf(ddlProperty.Items.FindByValue(editTenant.PropertyID.ToString()));
            }
        }

        private void PopulatePrimaryTenantDDL(int propertyID)
        {
            var primary = db.Tenants.Where(x => x.PropertyID == propertyID && x.IsActive == true).ToList();
            if (primary.Count > 0)
            {
                ddlParentID.DataSource = primary;
                ddlParentID.DataTextField = "FullName";
                ddlParentID.DataValueField = "ID";
                ddlParentID.DataBind();
            }
            ddlParentID.Items.Insert(0, new ListItem("-- Select --", "0"));

            if (editTenant != null)
            {
                ddlParentID.SelectedIndex = (editTenant.ParentID.HasValue) ? ddlParentID.Items.IndexOf(ddlParentID.Items.FindByValue(editTenant.ParentID.ToString())) : ddlParentID.Items.IndexOf(ddlParentID.Items.FindByValue("0"));
            }
        }

        #endregion

        #endregion

        #region Button Clicks and DDL change

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                editTenant = db.Tenants.FirstOrDefault(x => x.ID == int.Parse(Request.QueryString["id"]));
            }

            RPMS_Database.Tenant tenant = new RPMS_Database.Tenant();

            tenant.PropertyID = int.Parse(ddlProperty.SelectedItem.Value);
            tenant.DriversLicenseStateID = int.Parse(ddlDriversLicenseStateID.SelectedItem.Value);
            tenant.FirstName = txtFirstName.Text;
            tenant.MiddleName = txtMiddleName.Text;
            tenant.LastName = txtLastName.Text;
            tenant.FullName = txtFullName.Text;
            tenant.Phone = txtPhone.Text;
            tenant.SSN = txtSSN.Text;
            tenant.Email = txtEmail.Text;
            tenant.DriversLicense = txtDriversLicense.Text;

            if (ddlParentID.SelectedItem.Value != "0")
            {
                tenant.ParentID = int.Parse(ddlParentID.SelectedItem.Value);
                var otherTenants = db.Tenants.Where(x => x.PropertyID == tenant.PropertyID).ToList();
                otherTenants.ForEach(x => {
                    if(x.ID == tenant.ParentID)
                    {
                        x.ParentID = null;
                    }
                    else
                    {
                        x.ParentID = tenant.ParentID;
                    }
                    x.ModifiedBy = 1;
                    x.DateModified = DateTime.Now;

                    new TenantDAL().UpdateTenant(x);
                });
            }
            else
            {
                tenant.ParentID = null;
            }

            if (editTenant != null)
            {
                //tenant.IsActive = cbIsActive.Checked;
                tenant.ID = editTenant.ID;
                tenant.ModifiedBy = 1;
                tenant.DateModified = DateTime.Now;
                tenant.CreatedBy = editTenant.CreatedBy;
                tenant.DateCreated = editTenant.DateCreated;
                tenant.IsActive = cbIsActive.Checked;

                new TenantDAL().UpdateTenant(tenant);
            }
            else
            {
                tenant.IsActive = true;
                tenant.CreatedBy = 1;
                tenant.DateCreated = DateTime.Now;
                new TenantDAL().InsertTenant(tenant);
            }

            Response.Redirect("TenantList.aspx");
        }

        protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlParentID.Items.Clear();
            PopulatePrimaryTenantDDL(int.Parse(ddlProperty.SelectedValue));
        }

        #endregion


    }
}