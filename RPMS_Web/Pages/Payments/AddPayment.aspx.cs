using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPMS_Database;
using RPMS_BusinessLogic;

namespace RPMS_Web.Pages.Payments
{
    public partial class AddPayment : System.Web.UI.Page
    {
        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();
        //private List<Dictionary> paymentTypes = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["new"] != null)
                {
                    ShowAdd();
                }
                else
                {
                    ShowList();
                }

                PopulateTenantDropdown();
                PopulatePaymentTypes();
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

        private void PopulatePaymentTypes()
        {
            ddlPaymentTypes.DataSource = db.Dictionaries.Where(x => x.Category == "Payments").ToList();
            ddlPaymentTypes.DataTextField = "EntryName";
            ddlPaymentTypes.DataValueField = "ID";
            ddlPaymentTypes.DataBind();

            ddlPaymentTypes.Items.Insert(0, new ListItem("-- Select --", "0"));
        }

        private void ShowAdd()
        {
            phEdit.Visible = true;
            phList.Visible = false;
            txtDescription.Text = string.Empty;
            txtEntryName.Text = string.Empty;
            btnCreate.Text = "Create";
            hdnID.Value = "0";
        }

        private void ShowList()
        {
            phEdit.Visible = false;
            phList.Visible = true;
            repPaymentTypes.DataSource = db.Dictionaries.Where(x => x.Category == "Payments").ToList();
            repPaymentTypes.ItemDataBound += new RepeaterItemEventHandler(repPaymentTypes_DataBinding);
            repPaymentTypes.DataBind();
        }

        protected void repPaymentTypes_DataBinding(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = (RepeaterItem) e.Item;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var paymentType = (Dictionary) e.Item.DataItem;
                Literal litPaymentTypeName = (Literal) e.Item.FindControl("litPaymentTypeName");
                Button btnPaymentType = (Button) e.Item.FindControl("btnPaymentType");

                litPaymentTypeName.Text = paymentType.EntryName;
            }
        }

        protected void btnPaymentType_Click(object sender, EventArgs e)
        {
            Button btn = (Button) sender;

            var id = int.Parse(btn.CommandArgument);
            var paymentType = db.Dictionaries.FirstOrDefault(x => x.ID == id);
            phEdit.Visible = true;
            phList.Visible = false;
            hdnID.Value = btn.CommandArgument;
            txtEntryName.Text = paymentType.EntryName;
            txtDescription.Text = paymentType.Description;
            btnCreate.Text = "Update";
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            bool add = true;
            int id = 0;

            if(hdnID.Value != "0" && hdnID.Value != null)
            {
                add = false;
                id = int.Parse(hdnID.Value);
            }

            var paymentType = new RPMS_Database.Dictionary();

            paymentType.Category = "Payments";
            paymentType.Description = txtDescription.Text;
            paymentType.EntryName = txtEntryName.Text;
            if (add)
            {
                var entries = db.Dictionaries.Where(x => x.Category == "Payments").OrderByDescending(o => o.ID).ToList();
                paymentType.ID = entries[0].ID + 1;

                new DictionaryDAL().AddDictionary(paymentType);
            }
            else
            {
                paymentType.ID = id;

                new DictionaryDAL().UpdateDictionary(paymentType);
            }

            Response.Redirect("AddPayment.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddPayment.aspx");
        }

        protected void btnCreatePayment_Click(object sender, EventArgs e)
        {
            decimal amount = 0M;
            var paymentType = db.Dictionaries.FirstOrDefault(x => x.ID == int.Parse(ddlPaymentTypes.SelectedItem.Value));
            var tenant = db.Tenants.FirstOrDefault(x => x.ID == int.Parse(ddlTenants.SelectedItem.Value));
            
            switch(paymentType.ID)
            {
                case 5000: //Rent
                    amount = db.Properties.FirstOrDefault(x => x.ID == tenant.PropertyID).RentAmount;
                    break;
                case 5001: //Daily Late Payment
                case 5002: //Late Charge
                case 5003: //Check Return
                    amount = decimal.Parse(paymentType.Description);
                    break;
                case 5004: //Deposit
                    amount = db.Properties.FirstOrDefault(x => x.ID == tenant.PropertyID).DepositAmount;
                    break;
                case 5005: //Pet Deposit
                    amount = db.Properties.FirstOrDefault(x => x.ID == tenant.PropertyID).PetDepositAmount;
                    break;
                default:
                    break;
            }
                
            new PaymentBL().CreateFeePayment(tenant, DateTime.Parse(txtFeeDate.Text), paymentType.ID, amount);

            Response.Redirect("AddPayment.aspx");
        }

        protected void btnCancelPayment_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddPayment.aspx");
        }
    }
}