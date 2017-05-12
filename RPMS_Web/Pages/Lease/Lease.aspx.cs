using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RPMS_Database;
using RPMS_BusinessLogic;

namespace RPMS_Web.Pages.Lease
{
    public partial class Lease : System.Web.UI.Page
    {
        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();
        private string signatureLine = "Tenant Signature: _____________________________________________________ Date:__________________";
        private string printLine = "Tenant Print: ___________________________________________________________________________";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                var lease = db.LeaseInfos.FirstOrDefault(x => x.ID == int.Parse(Request.QueryString["id"]));
                var tenant = (lease.TenantID.HasValue) ? db.Tenants.FirstOrDefault(x => x.ID == lease.TenantID) : new RPMS_Database.Tenant();
                var property = db.Properties.FirstOrDefault(x => x.ID == lease.PropertyID);
                var state = db.States.FirstOrDefault(x => x.Id == property.StateID);

                litProratedRent.Text = string.Empty;

                if (lease.TenantID.HasValue)
                {
                    //Create payments for the lease
                    if (lease.StartDate.HasValue)
                    {
                        decimal proRatedAmount = 0M;
                        if (lease.StartDate.Value.Day > 1)
                        {
                            proRatedAmount = new PaymentBL().ProrateAmount(lease.StartDate.Value, lease.RentAmount);

                            litProratedRent.Text = string.Format("First month's prorated amount is ${0} and paid on {1}.", proRatedAmount.ToString("##,##0.00"), lease.StartDate.Value.ToString("MM/dd/yyyy"));
                        }

                        new PaymentBL().CreateFeePayment(tenant, lease.StartDate.Value, 5004, lease.DepositAmount);
                        new PaymentBL().CreatePayments(lease.TenantID.Value, lease.PropertyID, lease.StartDate.Value, lease.EndDate.Value, proRatedAmount);
                    }

                    property.IsRented = true;

                    new PropertyDAL().UpdateProperty(property);

                    property = db.Properties.FirstOrDefault(x => x.ID == lease.PropertyID);
                }

                List<RPMS_Database.Tenant> otherTenants = (lease.TenantID.HasValue) ? db.Tenants.Where(x => x.ParentID == tenant.ID).ToList() : new List<RPMS_Database.Tenant>();



                litTenants2.Text = litTenants.Text = (lease.TenantID.HasValue) ? string.Format("{0}{1}{2}", tenant.FirstName + " ", (!string.IsNullOrEmpty(tenant.MiddleName) ? tenant.MiddleName + " " : ""), tenant.LastName) :
                    "_________________________________________________________________________________";

                litSignatures.Text = (lease.TenantID.HasValue) ? string.Format("Tenant Print: <b>{0}{1}{2}</b><br/><br/>{3}<br/><br/><br/>", tenant.FirstName + " ", (!string.IsNullOrEmpty(tenant.MiddleName) ? tenant.MiddleName + " " : ""), tenant.LastName, signatureLine) :
                    string.Format("{0}<br/><br/><br/>{1}<br/><br/><br/>{2}<br/><br/><br/>{3}<br/><br/><br/>", printLine, signatureLine, printLine, signatureLine);

                otherTenants.ForEach(x => {
                    litTenants.Text += string.Format(" and {0}{1}{2}", x.FirstName + " ", (!string.IsNullOrEmpty(x.MiddleName) ? x.MiddleName + " " : ""), x.LastName);
                    litTenants2.Text += string.Format(" and {0}{1}{2}", x.FirstName + " ", (!string.IsNullOrEmpty(x.MiddleName) ? x.MiddleName + " " : ""), x.LastName);
                    litSignatures.Text += string.Format("Tenant Print: <b>{0}{1}{2}</b><br/><br/>{3}<br/><br/><br/>", x.FirstName + " ", (!string.IsNullOrEmpty(x.MiddleName) ? x.MiddleName + " " : ""), x.LastName, signatureLine);
                });

                litProperty.Text = string.Format("{0}{1} {2}, {3} {4}", property.StreetAddress1, (!string.IsNullOrEmpty(property.StreetAddress2) ? property.StreetAddress2 : string.Empty), property.City, state.Code, property.ZipCode);
                litStartDate.Text = (lease.StartDate.HasValue) ? lease.StartDate.Value.ToString("MM/dd/yyyy") : "________________________";
                litEndDate.Text = (lease.EndDate.HasValue) ? lease.EndDate.Value.ToString("MM/dd/yyyy") : "________________________";
                litDepositDate.Text = (lease.DepositDate.HasValue) ? lease.DepositDate.Value.ToString("MM/dd/yyyy") : "________________________";
                litRent.Text = lease.RentAmount.ToString("#,##0.##");
                litDeposit.Text = lease.DepositAmount.ToString("#,##0.##");
                litNumAdults.Text = (lease.TenantID.HasValue) ? (otherTenants.Count + 1).ToString() : "_____________";
                litNumChildren.Text = (lease.TenantID.HasValue) ? (lease.NumberOfChildren.HasValue) ? lease.NumberOfChildren.Value.ToString() : "0" : "_____________";
                litNumberOfPeopleMax.Text = (lease.MaxNumberOfOccupants.HasValue) ? string.Format("<b>{0}</b>", lease.MaxNumberOfOccupants) : "<b>5</b>";
                litPetDeposit.Text = lease.PetDepositAmount.ToString("#,##0.##");
                litTrashDay.Text = (property.TrashDayID.HasValue) ? db.Dictionaries.FirstOrDefault(x => x.ID == property.TrashDayID).EntryName : "__________________";
            }
        }
    }
}