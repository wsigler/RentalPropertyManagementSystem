using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPMS_Database;

namespace RPMS_Web.Pages.Property
{
    public partial class PropertyAction : System.Web.UI.Page
    {
        #region Page Variables

        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();
        private List<State> states = null;
        private List<Dictionary> trashDays = null;
        private RPMS_Database.Property editProperty = null;

        #endregion

        #region Load

        protected void Page_Load(object sender, EventArgs e)
        {
            states = db.States.ToList();
            trashDays = db.Dictionaries.Where(x => x.Category == "DaysOfTheWeek").ToList();

            if (!IsPostBack)
            {
                litHeading.Text = "Add Property";

                if (Request.QueryString["id"] != null)
                {
                    editProperty = db.Properties.FirstOrDefault(x => x.ID == int.Parse(Request.QueryString["id"]));
                    btnCreate.Text = "Update";

                    PopulateForm();
                   
                    litHeading.Text = "Edit Property";
                    
                }

                PopulateStateDDL();
                PopulateTrashDayDDL();
            }
        }

        #region Populate Form Items

        private void PopulateForm()
        {
            txtStreetAddress1.Text = editProperty.StreetAddress1;
            txtStreetAddress2.Text = editProperty.StreetAddress2;
            txtCity.Text = editProperty.City;
            txtZipCode.Text = editProperty.ZipCode;
            txtLat.Text = (editProperty.Lat.HasValue) ? editProperty.Lat.Value.ToString() : string.Empty;
            txtLong.Text = (editProperty.Long.HasValue) ? editProperty.Long.Value.ToString() : string.Empty;
            txtSquareFootageEst.Text = (editProperty.SquareFootageEst.HasValue) ? editProperty.SquareFootageEst.ToString() : string.Empty;
            txtEstimatedTax.Text = (editProperty.EstimatedTax.HasValue) ? editProperty.EstimatedTax.Value.ToString() : string.Empty;
            txtRentAmount.Text = editProperty.RentAmount.ToString("#,##0.00");
            txtDepositAmount.Text = editProperty.DepositAmount.ToString("#,##0.00");
            txtPetDepositAmount.Text = editProperty.PetDepositAmount.ToString("#,##0.00");
            txtNumberOfBedrooms.Text = editProperty.NumberOfBedrooms.ToString();
            txtNumberOfBathrooms.Text = editProperty.NumberOfBathrooms.ToString();
            cbWDConnection.Checked = editProperty.HasWDConnection;
            cbAC.Checked = editProperty.HasCentralAC;
            cbIsActive.Checked = editProperty.IsActive;
        }

        private void PopulateStateDDL()
        {
            ddlState.DataSource = states;
            ddlState.DataTextField = "Code";
            ddlState.DataValueField = "ID";
            ddlState.DataBind();

            ddlState.Items.Insert(0, new ListItem("-- Select --", "0"));

            if(editProperty != null)
            {
                ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByValue(editProperty.StateID.ToString()));
            }
        }

        private void PopulateTrashDayDDL()
        {
            ddlTrashDay.DataSource = trashDays;
            ddlTrashDay.DataTextField = "EntryName";
            ddlTrashDay.DataValueField = "ID";
            ddlTrashDay.DataBind();

            ddlTrashDay.Items.Insert(0, new ListItem("-- Select --", "0"));

            if (editProperty != null)
            {
                ddlTrashDay.SelectedIndex = ddlTrashDay.Items.IndexOf(ddlTrashDay.Items.FindByValue(editProperty.TrashDayID.ToString()));
            }
        }

        #endregion
        
        #endregion

        #region Button Clicks

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                editProperty = db.Properties.FirstOrDefault(x => x.ID == int.Parse(Request.QueryString["id"]));
            }

            RPMS_Database.Property property = new RPMS_Database.Property();

            property.StreetAddress1 = txtStreetAddress1.Text;
            property.StreetAddress2 = txtStreetAddress2.Text;
            property.City = txtCity.Text;
            property.StateID = int.Parse(ddlState.SelectedItem.Value);
            property.ZipCode = txtZipCode.Text;
            if(!string.IsNullOrEmpty(txtLat.Text))
            {
                property.Lat = decimal.Parse(txtLat.Text);
            }
            else
            {
                property.Lat = null;
            }

            if (!string.IsNullOrEmpty(txtLong.Text))
            {
                property.Long = decimal.Parse(txtLong.Text);
            }
            else
            {
                property.Long = null;
            }

            if (!string.IsNullOrEmpty(txtSquareFootageEst.Text))
            {
                property.SquareFootageEst = int.Parse(txtSquareFootageEst.Text);
            }
            else
            {
                property.SquareFootageEst = null;
            }

            if (!string.IsNullOrEmpty(txtEstimatedTax.Text))
            {
                property.EstimatedTax = decimal.Parse(txtEstimatedTax.Text);
            }
            else
            {
                property.EstimatedTax = null;
            }

            property.RentAmount = decimal.Parse(txtRentAmount.Text);
            property.DepositAmount = decimal.Parse(txtDepositAmount.Text);
            property.PetDepositAmount = decimal.Parse(txtPetDepositAmount.Text);
            property.NumberOfBedrooms = int.Parse(txtNumberOfBedrooms.Text);
            property.NumberOfBathrooms = int.Parse(txtNumberOfBathrooms.Text);
            property.TrashDayID = int.Parse(ddlTrashDay.SelectedItem.Value);
            property.HasWDConnection = cbWDConnection.Checked;
            property.HasCentralAC = cbAC.Checked;
            property.IsActive = cbIsActive.Checked;
            
            if (editProperty != null)
            {
                property.ID = editProperty.ID;
                property.ModifiedBy = 1;
                property.DateModified = DateTime.Now;
                property.CreatedBy = editProperty.CreatedBy;
                property.DateCreated = editProperty.DateCreated;
                new PropertyDAL().UpdateProperty(property);
            }
            else
            {
                property.CreatedBy = 1;
                property.DateCreated = DateTime.Now;
                new PropertyDAL().InsertProperty(property);
            }

            Response.Redirect("PropertyList.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PropertyList.aspx");
        }

        #endregion
    }
}