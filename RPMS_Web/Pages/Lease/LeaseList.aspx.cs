using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPMS_Database;

namespace RPMS_Web.Pages.Lease
{
    public partial class LeaseList : System.Web.UI.Page
    {
        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();
        private List<State> states = null;
        private List<RPMS_Database.Property> properties = null;
        private List<RPMS_Database.Tenant> tenants = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            states = db.States.ToList();
            properties = db.Properties.Where(x => x.IsActive == true).ToList();
            tenants = db.Tenants.Where(x => x.IsActive == true).ToList();
            var leases = db.LeaseInfos.Where(x => x.IsCurrentLease == true);
            repLeases.DataSource = leases;
            repLeases.ItemDataBound += new RepeaterItemEventHandler(repLeases_DataBinding);
            repLeases.DataBind();
        }

        protected void repLeases_DataBinding(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = (RepeaterItem) e.Item;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var lease = (RPMS_Database.LeaseInfo) e.Item.DataItem;
                var property = properties.FirstOrDefault(x => x.ID == lease.PropertyID);
                var state = states.FirstOrDefault(x => x.Id == property.StateID);
                var tenant = (lease.TenantID.HasValue) ? tenants.FirstOrDefault(x => x.ID == lease.TenantID.Value) : new RPMS_Database.Tenant();

                Literal litStartDate = (Literal) e.Item.FindControl("litStartDate");
                Literal litEndDate = (Literal) e.Item.FindControl("litEndDate");
                CheckBox cbIsRented = (CheckBox) e.Item.FindControl("cbIsRented");
                HyperLink hlTenantName = (HyperLink) e.Item.FindControl("hlTenantName");
                HyperLink hlStreetAddress = (HyperLink) e.Item.FindControl("hlStreetAddress");
                HyperLink hlEdit = (HyperLink) e.Item.FindControl("hlEdit");
                HyperLink hlDetails = (HyperLink) e.Item.FindControl("hlDetails");
                HyperLink hlLease = (HyperLink) e.Item.FindControl("hlLease");

                litStartDate.Text = (lease.StartDate.HasValue) ? lease.StartDate.Value.ToString("MM/dd/yyyy") : string.Empty;
                litEndDate.Text = (lease.EndDate.HasValue) ? lease.EndDate.Value.ToString("MM/dd/yyyy") : string.Empty;

                cbIsRented.Checked = property.IsRented;
                cbIsRented.Enabled = false;

                hlTenantName.Text = (lease.TenantID.HasValue) ? tenant.FullName : "Blank Lease";
                hlTenantName.NavigateUrl = (lease.TenantID.HasValue) ? string.Format("~/Pages/Tenant/TenantDetail.aspx?id={0}", lease.TenantID.Value) : "~/Pages/Tenant/TenantList.aspx";

                hlStreetAddress.Text = string.Format("{0}{1} {2}, {3} {4}", property.StreetAddress1, (!string.IsNullOrEmpty(property.StreetAddress2) ? " " + property.StreetAddress2 : string.Empty), property.City, state.Code, property.ZipCode);
                hlStreetAddress.NavigateUrl = string.Format("~/Pages/Property/PropertyDetail.aspx?id={0}&reprint=1", property.ID);

                hlLease.NavigateUrl = (lease.TenantID.HasValue) ? string.Format("~/Pages/Lease/RentalAgreement.aspx?TenantId={0}&renewal=1", tenant.ID) : string.Format("~/Pages/Lease/RentalAgreement.aspx?PropertyId={0}", property.ID);
            }
        }
    }
}