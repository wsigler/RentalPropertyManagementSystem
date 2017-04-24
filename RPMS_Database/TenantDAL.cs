using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPMS_Database
{
    public class TenantDAL
    {
        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();

        public void InsertTenant(Tenant tenant)
        {
            try
            {
                db.Tenants.InsertOnSubmit(tenant);

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateTenant(Tenant tenant)
        {
            var editedTenant = db.Tenants.FirstOrDefault(x => x.ID == tenant.ID);
            editedTenant.ID = tenant.ID;
            editedTenant.PropertyID = tenant.PropertyID;
            editedTenant.DriversLicenseStateID = tenant.DriversLicenseStateID;
            editedTenant.FirstName = tenant.FirstName;
            editedTenant.MiddleName = tenant.MiddleName;
            editedTenant.LastName = tenant.LastName;
            editedTenant.FullName = tenant.FullName;
            editedTenant.Phone = tenant.Phone;
            editedTenant.SSN = tenant.SSN;
            editedTenant.Email = tenant.Email;
            editedTenant.DriversLicense = tenant.DriversLicense;
            editedTenant.ParentID = tenant.ParentID;
            editedTenant.ModifiedBy = tenant.ModifiedBy;
            editedTenant.DateModified = tenant.DateModified;
            editedTenant.IsActive = tenant.IsActive;
            editedTenant.CreatedBy = tenant.CreatedBy;
            editedTenant.DateCreated = tenant.DateCreated;

            db.SubmitChanges();
        }
    }
}
