using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPMS_Database
{
    public class LeaseInfoDAL
    {
        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();

        public void InsertLeaseInfo(LeaseInfo lease)
        {
            try
            {
                var otherLeases = db.LeaseInfos.Where(x => x.PropertyID == lease.PropertyID && x.IsCurrentLease).ToList();

                otherLeases.ForEach(x => {
                    x.IsCurrentLease = false;
                    UpdateLeaseInfo(x);
                });

                db.LeaseInfos.InsertOnSubmit(lease);

                db.SubmitChanges();

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateLeaseInfo(LeaseInfo lease)
        {
            var editedLeaseInfo = db.LeaseInfos.FirstOrDefault(x => x.ID == lease.ID);
            editedLeaseInfo.ID = lease.ID;
            editedLeaseInfo.TenantID = lease.TenantID;
            editedLeaseInfo.PropertyID = lease.PropertyID;
            editedLeaseInfo.RentAmount = lease.RentAmount;
            editedLeaseInfo.DepositAmount = lease.DepositAmount;
            editedLeaseInfo.PetDepositAmount = lease.PetDepositAmount;
            editedLeaseInfo.StartDate = lease.StartDate;
            editedLeaseInfo.EndDate = lease.EndDate;
            editedLeaseInfo.DepositDate = lease.DepositDate;
            editedLeaseInfo.IsCurrentLease = lease.IsCurrentLease;
            editedLeaseInfo.NumberOfChildren = lease.NumberOfChildren;
            editedLeaseInfo.MaxNumberOfOccupants = lease.MaxNumberOfOccupants;

            db.SubmitChanges();
        }
    }
}
