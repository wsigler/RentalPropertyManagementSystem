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
                rowEntry.Visible = false;
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
            string tenantDir = ConfigurationManager.AppSettings["FileLocation"] + relativeDir;

            var host = ConfigurationManager.AppSettings["HostLocation"];

            if (rbNonRenewal.Checked)
            {
                

                new RPMS_BusinessLogic.PDFConverter().ConvertToPDF(host, tenantDir,
                string.Format("/Nonrenewal Form {0}", DateTime.Now.ToString("yyyy-MM-dd")),
                string.Format("http://{0}/Pages/Documents/NonRenewal.aspx?id={1}", host, parent.ID));
            }

            if(rbEviction.Checked)
            {
                new RPMS_BusinessLogic.PDFConverter().ConvertToPDF(host, tenantDir,
                string.Format("/Eviction Notice {0}", DateTime.Now.ToString("yyyy-MM-dd")),
                string.Format("http://{0}/Pages/Documents/Eviction.aspx?id={1}", host, parent.ID));
            }

            if(rbNoticeOfEntry.Checked)
            {

                new RPMS_BusinessLogic.PDFConverter().ConvertToPDF(host, tenantDir,
                string.Format("/Notice Of Entry {0}", DateTime.Now.ToString("yyyy-MM-dd")),
                string.Format("http://{0}/Pages/Documents/NoticeOfEntry.aspx?id={1}&reason={2}&date={3}&time={4}", host, parent.ID, txtReasons.Text, txtDateOfEntry.Text, txtTimeOfEntry.Text));
            }

            Response.Redirect(string.Format("~/Pages/Tenant/TenantDetail.aspx?id={0}", tenantId));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void rbNoticeOfEntry_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton) sender;
            rowEntry.Visible = rb.Checked;
        }

        protected void rbNonRenewal_CheckedChanged(object sender, EventArgs e)
        {
            rowEntry.Visible = false;
        }

        protected void rbEviction_CheckedChanged(object sender, EventArgs e)
        {
            rowEntry.Visible = false;
        }
    }
}