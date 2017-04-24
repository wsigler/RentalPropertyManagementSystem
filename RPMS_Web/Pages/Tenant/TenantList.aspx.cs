using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPMS_Database;

namespace RPMS_Web.Pages.Tenant
{
    public partial class TenantList : System.Web.UI.Page
    {
        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();
        private List<State> states = null;
        private List<RPMS_Database.Property> properties = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            states = db.States.ToList();
            properties = db.Properties.ToList();

            repTenants.DataSource = db.Tenants.Where(x => x.IsActive == true).OrderBy(o => o.PropertyID).ThenBy(d => d.ParentID).ToList();
            repTenants.ItemDataBound += new RepeaterItemEventHandler(repTenants_DataBinding);
            repTenants.DataBind();
        }

        protected void repTenants_DataBinding(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = (RepeaterItem) e.Item;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var tenant = (RPMS_Database.Tenant) e.Item.DataItem;
                var property = properties.FirstOrDefault(x => x.ID == tenant.PropertyID);
                var parent = (tenant.ParentID.HasValue) ? db.Tenants.FirstOrDefault(x => x.IsActive == true && x.ID == tenant.ParentID) : tenant;
                var lease = db.LeaseInfos.FirstOrDefault(x => x.IsCurrentLease == true && x.TenantID == parent.ID);

                Literal litFullName = (Literal) e.Item.FindControl("litFullName");
                Literal litEmail = (Literal) e.Item.FindControl("litEmail");
                Literal litPhone = (Literal) e.Item.FindControl("litPhone");
                Literal litPrimaryFullName = (Literal) e.Item.FindControl("litPrimaryFullName");

                HyperLink hlStreetAddress1 = (HyperLink) e.Item.FindControl("hlStreetAddress1");
                HyperLink hlEdit = (HyperLink) e.Item.FindControl("hlEdit");
                HyperLink hlDetails = (HyperLink) e.Item.FindControl("hlDetails");
                HyperLink hlLease = (HyperLink) e.Item.FindControl("hlLease");
                HyperLink hlPayment = (HyperLink) e.Item.FindControl("hlPayment");

                if (property != null)
                {
                    hlStreetAddress1.Text = property.StreetAddress1;
                    hlStreetAddress1.NavigateUrl = string.Format("~/Pages/Property/PropertyDetail.aspx?id={0}", property.ID);
                }
                else
                {
                    hlStreetAddress1.Text = string.Empty;
                }

                litFullName.Text = tenant.FullName;
                litEmail.Text = tenant.Email;
                litPhone.Text = tenant.Phone;
                litPrimaryFullName.Text = (tenant.ParentID.HasValue) ? db.Tenants.FirstOrDefault(x => x.ID == tenant.ParentID).FullName : string.Empty;

                hlEdit.NavigateUrl = string.Format("TenantAction.aspx?id={0}", tenant.ID);
                hlDetails.NavigateUrl = string.Format("TenantDetail.aspx?id={0}", tenant.ID);
                hlLease.NavigateUrl = (lease == null) ? string.Format("~/Pages/Lease/RentalAgreement.aspx?TenantId={0}", parent.ID) : string.Format("~/Pages/Lease/RentalAgreement.aspx?TenantId={0}&renewal=1", parent.ID);
                hlPayment.NavigateUrl = string.Format("~/Pages/Payments/PaymentList.aspx?id={0}", parent.ID);

                hlLease.Text = (lease == null) ? "| Create Lease" : "| Renew Lease";
                hlPayment.Text = "| Make Payment";

                hlPayment.Visible = (lease != null && tenant.ParentID == null);
                hlLease.Visible = (!tenant.ParentID.HasValue);
            }

                
        }        
    }
}