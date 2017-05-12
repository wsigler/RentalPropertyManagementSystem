using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPMS_Database;
using System.Globalization;
using System.Xml;
using System.ServiceModel.Syndication;

namespace RPMS_Web
{
    public partial class _Default : Page
    {
        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();
        private List<State> states = null;
        private List<RPMS_Database.Property> properties = null;
        private List<RPMS_Database.Tenant> tenants = null;
        private List<RPMS_Database.LeaseInfo> leases = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //This needs to run first!!!
                PopulateClassVariables();

                PopulatePropertyList();
                PopulateTenantList();
                PopulateLeaseList();
                RSSFeed();
            }
        }

        #region Populate Panels

        private void PopulateClassVariables()
        {
            states = db.States.ToList();
            properties = db.Properties.ToList();
            tenants = db.Tenants.Where(x => x.IsActive == true).ToList();
            leases = db.LeaseInfos.Where(x => x.IsCurrentLease == true).ToList();
        }

        private void PopulateTenantList()
        {
            repTenants.DataSource = tenants.Where(x => x.IsActive == true).OrderBy(o => o.PropertyID).ThenBy(d => d.ParentID).ToList();
            repTenants.ItemDataBound += new RepeaterItemEventHandler(repTenants_DataBinding);
            repTenants.DataBind();
        }

        private void PopulatePropertyList()
        {
            properties = db.Properties.ToList();
            repPropertiesRented.DataSource = properties.Where(x => x.IsRented == true && x.IsActive == true).OrderBy(o => o.City).ThenBy(t => t.StreetAddress1).ToList();
            repPropertiesRented.ItemDataBound += new RepeaterItemEventHandler(repPropertiesRented_DataBinding);
            repPropertiesRented.DataBind();

            repAvailProperties.DataSource = properties.Where(x => x.IsRented == false && x.IsActive == true).OrderBy(o => o.City).ThenBy(t => t.StreetAddress1).ToList(); ;
            repAvailProperties.ItemDataBound += new RepeaterItemEventHandler(repAvailProperties_DataBinding);
            repAvailProperties.DataBind();
        }

        private void PopulateLeaseList()
        {
            repLeases.DataSource = leases;
            repLeases.ItemDataBound += new RepeaterItemEventHandler(repLeases_DataBinding);
            repLeases.DataBind();
        }

        #endregion

        #region Data Bind

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
                hlStreetAddress.NavigateUrl = string.Format("~/Pages/Property/PropertyDetail.aspx?id={0}", property.ID);

                hlLease.NavigateUrl = (lease.TenantID.HasValue) ? string.Format("~/Pages/Lease/RentalAgreement.aspx?TenantId={0}&renewal=1", tenant.ID) : string.Format("~/Pages/Lease/RentalAgreement.aspx?PropertyId={0}", property.ID);
            }
        }

        protected void repAvailProperties_DataBinding(object sender, RepeaterItemEventArgs e)
        { 
            RepeaterItem item = (RepeaterItem) e.Item;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var property = (RPMS_Database.Property) e.Item.DataItem;

                Literal litStreetAddress = (Literal) e.Item.FindControl("litStreetAddress");
                Literal litRent = (Literal) e.Item.FindControl("litRent");
                Literal litDeposit = (Literal) e.Item.FindControl("litDeposit");
                Literal litBedrooms = (Literal) e.Item.FindControl("litBedrooms");
                Literal litBathrooms = (Literal) e.Item.FindControl("litBathrooms");
                CheckBox cbWD = (CheckBox) e.Item.FindControl("cbWD");
                CheckBox cbAC = (CheckBox) e.Item.FindControl("cbAC");
                HyperLink hlDetails = (HyperLink) e.Item.FindControl("hlDetails");

                litStreetAddress.Text = (!string.IsNullOrEmpty(property.StreetAddress2)) ? string.Format("{0} {1}", property.StreetAddress1, property.StreetAddress2) : property.StreetAddress1;
                litRent.Text = property.RentAmount.ToString("##,###.00");
                litDeposit.Text = property.DepositAmount.ToString("##,###.00");
                litBedrooms.Text = property.NumberOfBedrooms.ToString();
                litBathrooms.Text = property.NumberOfBathrooms.ToString();
                cbAC.Checked = property.HasCentralAC;
                cbWD.Checked = property.HasWDConnection;
                cbAC.Enabled = false;
                cbWD.Enabled = false;

                hlDetails.NavigateUrl = string.Format("~/Pages/Property/PropertyDetail.aspx?id={0}", property.ID);
            }
        }

        protected void repPropertiesRented_DataBinding(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = (RepeaterItem) e.Item;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var property = (RPMS_Database.Property) e.Item.DataItem;

                Literal litStreetAddress = (Literal) e.Item.FindControl("litStreetAddress");
                Literal litLeaseExpireDate = (Literal) e.Item.FindControl("litLeaseExpireDate");
                CheckBox cbRentCurrent = (CheckBox) e.Item.FindControl("cbRentCurrent");
                HyperLink hlDetails = (HyperLink) e.Item.FindControl("hlDetails");
                HyperLink hlMakePayment = (HyperLink) e.Item.FindControl("hlMakePayment");

                var tenant = db.Tenants.FirstOrDefault(x => x.PropertyID == property.ID && x.IsActive == true && x.ParentID == null);
                

                LeaseInfo propLease = leases.FirstOrDefault(x => x.PropertyID == property.ID);
                var payments = db.Payments.Where(x => x.PropertyID == property.ID && x.TenantID == tenant.ID).ToList();

                var compareDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 5);

                var payment = payments.FirstOrDefault(x => x.DueDate == compareDate && x.TypeID == 5000);
                if(payment != null)
                {
                    cbRentCurrent.Checked = (payment.Balance == 0);

                    if(DateTime.Now.Day > 5 && payment.Balance > 0)
                    {
                        var dailyFees = payments.FirstOrDefault(x => x.DueDate == compareDate && x.TypeID == 5001);
                        int dateDif = DateTime.Now.Day - 5;
                        decimal amountPerDay = decimal.Parse(db.Dictionaries.FirstOrDefault(x => x.ID == 5001).Description);
                        bool isNew = false;

                        if(dailyFees == null)
                        {
                            dailyFees = new Payment();
                            dailyFees.TypeID = 5001;
                            dailyFees.DueDate = compareDate;
                            dailyFees.TenantID = payment.TenantID;
                            dailyFees.PropertyID = payment.PropertyID;
                            isNew = true;
                        }

                        dailyFees.AmountDue = dateDif * amountPerDay;
                        dailyFees.Balance = dailyFees.AmountDue;
                        dailyFees.ModifiedBy = 1;
                        dailyFees.ModifiedDate = DateTime.Now;

                        if(isNew)
                        {
                            new PaymentDAL().AddPayment(dailyFees);
                        }
                        else
                        {
                            new PaymentDAL().UpdatePayment(dailyFees);
                        }


                    }
                }


                if (propLease != null)
                {
                    if (DateTime.Now.AddDays(30) > propLease.EndDate.Value)
                    {
                        litLeaseExpireDate.Text = string.Format("<div class='site-danger'>{0}</div>", propLease.EndDate.Value.ToString("MM/dd/yyyy"));
                    }
                    else
                    {
                        if (DateTime.Now.AddDays(60) > propLease.EndDate.Value)
                        {
                            litLeaseExpireDate.Text = string.Format("<div class='site-warning'>{0}</div>", propLease.EndDate.Value.ToString("MM/dd/yyyy"));
                        }
                        else
                        {
                            if (DateTime.Now.AddDays(90) > propLease.EndDate.Value)
                            {
                                litLeaseExpireDate.Text = string.Format("<div class='site-info'>{0}</div>", propLease.EndDate.Value.ToString("MM/dd/yyyy"));
                            }
                            else
                            {
                                if (DateTime.Now.AddDays(120) > propLease.EndDate.Value)
                                {
                                    litLeaseExpireDate.Text = string.Format("<div class='site-suggest'>{0}</div>", propLease.EndDate.Value.ToString("MM/dd/yyyy"));
                                }
                                else
                                {
                                    litLeaseExpireDate.Text = propLease.EndDate.Value.ToString("MM/dd/yyyy");
                                }
                            }
                        }
                    }
                }

                litStreetAddress.Text = (!string.IsNullOrEmpty(property.StreetAddress2)) ? string.Format("{0} {1}", property.StreetAddress1, property.StreetAddress2) : property.StreetAddress1;
                hlDetails.NavigateUrl = string.Format("~/Pages/Property/PropertyDetail.aspx?id={0}", property.ID);
                hlMakePayment.NavigateUrl = (tenant != null) ? string.Format("~/Pages/Payments/PaymentList.aspx?id={0}", tenant.ID) : string.Empty;
                hlMakePayment.Visible = (tenant != null);
            }
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
                Literal litStreetAddress1 = (Literal) e.Item.FindControl("litStreetAddress1");
                Literal litPhone = (Literal) e.Item.FindControl("litPhone");

                HyperLink hlDetails = (HyperLink) e.Item.FindControl("hlDetails");
                HyperLink hlLease = (HyperLink) e.Item.FindControl("hlLease");


                if (property != null)
                {
                    var state = states.FirstOrDefault(x => x.Id == property.StateID);
                    litStreetAddress1.Text = property.StreetAddress1;
                }
                else
                {
                    litStreetAddress1.Text = string.Empty;
                }

                litFullName.Text = tenant.FullName;
                litPhone.Text = tenant.Phone;

                hlDetails.NavigateUrl = string.Format("~/Pages/Tenant/TenantDetail.aspx?id={0}", tenant.ID);
                hlLease.NavigateUrl = (lease == null) ? string.Format("~/Pages/Lease/RentalAgreement.aspx?TenantId={0}", parent.ID) : string.Format("~/Pages/Lease/RentalAgreement.aspx?TenantId={0}&renewal=1", parent.ID);
                hlLease.Text = (lease == null) ? "| Create Lease" : "| Renew Lease";
                hlLease.Visible = (!tenant.ParentID.HasValue);

            }


        }

        protected void repFeed_DataBind(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = (RepeaterItem) e.Item;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var something = (string) e.Item.DataItem;
                Literal lt = (Literal) e.Item.FindControl("lt");
                lt.Text = string.Format("<a href={0}>{1}</a><br/>", something, something);

            }
        }
        #endregion

        #region RSS?
        private void RSSFeed()
        {
            string url = "http://feeds2.feedburner.com/RealtororgAuctionHeadlines";
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            List<string> something = new List<string>();
            foreach (SyndicationItem item in feed.Items)
            {
                something.Add(item.Links[0].Uri.OriginalString.ToString());
                //String subject = item.Links;
                //String summary = item.Summary.Text;
            }
            repFeed.DataSource = something;
            repFeed.ItemDataBound += new RepeaterItemEventHandler(repFeed_DataBind);
            repFeed.DataBind();
        }

    #endregion
}
}