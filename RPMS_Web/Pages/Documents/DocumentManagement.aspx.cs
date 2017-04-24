using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPMS_Database;
using System.Configuration;

namespace RPMS_Web.Pages.Documents
{
    public partial class DocumentManagement : System.Web.UI.Page
    {
        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateTenantDropdown();
            }
        }

        private void PopulateTenantDropdown()
        {
            ddlTenants.DataSource = db.Tenants.Where(x => x.IsActive == true).ToList();
            ddlTenants.DataTextField = "FullName";
            ddlTenants.DataValueField = "ID";
            ddlTenants.DataBind();

            ddlTenants.Items.Insert(0, new ListItem("-- Select --", "0"));
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            var tenantId = int.Parse(ddlTenants.SelectedItem.Value);
            var tenant = db.Tenants.FirstOrDefault(x => x.IsActive == true && x.ID == tenantId);
            var parent = (tenant.ParentID.HasValue) ? db.Tenants.FirstOrDefault(x => x.IsActive == true && x.ID == tenant.ParentID.Value) : tenant;

            // relative directory
            string relativeDir = string.Format("Tenants\\Tenant_{0}", parent.ID);

            // get directory path
            string nonrenewalDir = ConfigurationManager.AppSettings["FileLocation"] + relativeDir;

            if (rbNonRenewal.Checked)
            {
                new RPMS_BusinessLogic.PDFConverter().ConvertNonRenewalToPDF(HttpContext.Current.Request.Url.Host + ":52223", parent.ID, nonrenewalDir,
                string.Format("/Nonrenewal Form {0}", DateTime.Now.ToString("yyyy-MM-dd")));
            }

            if(rbNoticeOfEntry.Checked)
            {
                //Response.Redirect(string.Format("~/Pages/Lease/RentalAgreement.aspx?TenantId={0}", tenantId));
            }

            Response.Redirect(string.Format("~/Pages/Tenant/TenantDetail.aspx?id={0}", tenantId));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}