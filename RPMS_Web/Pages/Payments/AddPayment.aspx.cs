using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPMS_Database;

namespace RPMS_Web.Pages.Payments
{
    public partial class AddPayment : System.Web.UI.Page
    {
        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();
        private List<Dictionary> paymentTypes = null;

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
            }
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
    }
}