using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPMS_Database
{
    public class PropertyDAL
    {
        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();

        public void InsertProperty(Property property)
        {
            try
            {
                db.Properties.InsertOnSubmit(property);

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateProperty(Property property)
        {
            var editedProperty = db.Properties.FirstOrDefault(x => x.ID == property.ID);
            editedProperty.StreetAddress1 = property.StreetAddress1;
            editedProperty.StreetAddress2 = property.StreetAddress2;
            editedProperty.City = property.City;
            editedProperty.StateID = property.StateID;
            editedProperty.ZipCode = property.ZipCode;
            editedProperty.County = property.County;
            editedProperty.Lat = property.Lat;
            editedProperty.Long = property.Long;
            editedProperty.RentAmount = property.RentAmount;
            editedProperty.DepositAmount = property.DepositAmount;
            editedProperty.PetDepositAmount = property.PetDepositAmount;
            editedProperty.TrashDayID = property.TrashDayID;
            editedProperty.NumberOfBedrooms = property.NumberOfBedrooms;
            editedProperty.NumberOfBathrooms = property.NumberOfBathrooms;
            editedProperty.SquareFootageEst = property.SquareFootageEst;
            editedProperty.EstimatedTax = property.EstimatedTax;
            editedProperty.IsRented = property.IsRented;
            editedProperty.IsActive = property.IsActive;
            editedProperty.HasWDConnection = property.HasWDConnection;
            editedProperty.HasCentralAC = property.HasCentralAC;
            editedProperty.DateModified = property.DateCreated;
            editedProperty.CreatedBy = property.CreatedBy;
            editedProperty.ModifiedBy = property.ModifiedBy;
            editedProperty.DateModified = property.DateModified;

            db.SubmitChanges();
        }
    }
}
