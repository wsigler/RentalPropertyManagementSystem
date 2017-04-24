using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPMS_Database;
using System.Globalization;

namespace RPMS_Web.Pages.Property
{
    public partial class PropertyList : System.Web.UI.Page
    {
        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();
        private List<State> states = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            states = db.States.ToList();
            var properties = db.Properties.Where(x => x.IsActive == true).OrderBy(o => o.City).ThenBy(t => t.StreetAddress1);
            repProperties.DataSource = properties;
            repProperties.ItemDataBound += new RepeaterItemEventHandler(repProperties_DataBinding);
            repProperties.DataBind();
        }

        protected void repProperties_DataBinding(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = (RepeaterItem) e.Item;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var property = (RPMS_Database.Property) e.Item.DataItem; 

                Literal litStreetAddress = (Literal) e.Item.FindControl("litStreetAddress");
                Literal litCity = (Literal) e.Item.FindControl("litCity");
                Literal litState = (Literal) e.Item.FindControl("litState");
                Literal litZip = (Literal) e.Item.FindControl("litZip");
                Literal litRentAmount = (Literal) e.Item.FindControl("litRentAmount");
                Literal litDepositAmount = (Literal) e.Item.FindControl("litDepositAmount");
                Literal litPetDepositAmount = (Literal) e.Item.FindControl("litPetDepositAmount");
                Literal litNumberOfBedrooms = (Literal) e.Item.FindControl("litNumberOfBedrooms");
                Literal litNumberOfBathrooms = (Literal) e.Item.FindControl("litNumberOfBathrooms");
                Literal litSquareFootageEst = (Literal) e.Item.FindControl("litSquareFootageEst");
                Literal litEstimatedTax = (Literal) e.Item.FindControl("litEstimatedTax");
                CheckBox cbHasWDConnection = (CheckBox) e.Item.FindControl("cbHasWDConnection");
                CheckBox cbHasCentralAC = (CheckBox) e.Item.FindControl("cbHasCentralAC");
                CheckBox cbIsRented = (CheckBox) e.Item.FindControl("cbIsRented");
                HyperLink hlEdit = (HyperLink) e.Item.FindControl("hlEdit");
                HyperLink hlDetails = (HyperLink) e.Item.FindControl("hlDetails");
                HyperLink hlLease = (HyperLink) e.Item.FindControl("hlLease");

                litStreetAddress.Text = (!string.IsNullOrEmpty(property.StreetAddress2)) ? string.Format("{0} {1}", property.StreetAddress1, property.StreetAddress2) : property.StreetAddress1;
                litCity.Text = property.City;
                litState.Text = states.FirstOrDefault(x => x.Id == property.StateID).Code;
                litZip.Text = property.City;
                litRentAmount.Text = property.RentAmount.ToString("C", CultureInfo.CurrentCulture);
                litDepositAmount.Text = property.DepositAmount.ToString("C", CultureInfo.CurrentCulture);
                litPetDepositAmount.Text = property.PetDepositAmount.ToString("C", CultureInfo.CurrentCulture);
                litNumberOfBedrooms.Text = property.NumberOfBedrooms.ToString();
                litNumberOfBathrooms.Text = property.NumberOfBathrooms.ToString();
                litSquareFootageEst.Text = (property.SquareFootageEst.HasValue) ? property.SquareFootageEst.Value.ToString() : string.Empty;
                litEstimatedTax.Text = (property.EstimatedTax.HasValue) ? property.EstimatedTax.Value.ToString("C", CultureInfo.CurrentCulture) : string.Empty;
                cbHasWDConnection.Checked = property.HasWDConnection;
                cbHasCentralAC.Checked = property.HasCentralAC;
                cbIsRented.Checked = property.IsRented;

                cbHasWDConnection.Enabled = false;
                cbHasCentralAC.Enabled = false;
                cbIsRented.Enabled = false;

                hlEdit.NavigateUrl = string.Format("PropertyAction.aspx?id={0}", property.ID);
                hlDetails.NavigateUrl = string.Format("PropertyDetail.aspx?id={0}", property.ID);
                hlLease.NavigateUrl = string.Format("~/Pages/Lease/RentalAgreement.aspx?PropertyID={0}", property.ID);
            }
        }
    }
}