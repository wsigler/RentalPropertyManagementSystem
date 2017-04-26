using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPMS_Database
{
    public class RentPaymentDAL
    {
        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();

        public void AddPayments(List<RentPayment> payments)
        {
            try
            {
                payments.ForEach(x => {
                    db.RentPayments.InsertOnSubmit(x);
                    db.SubmitChanges();
                });

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void UpdatePayment(RentPayment payment)
        {
            var editedPayment = db.RentPayments.FirstOrDefault(x => x.ID == payment.ID);
            editedPayment.ID = payment.ID;
            editedPayment.PropertyID = payment.PropertyID;
            editedPayment.TenantID = payment.TenantID;
            editedPayment.PaymentAmount = payment.PaymentAmount;
            editedPayment.PaymentDueDate = payment.PaymentDueDate;
            editedPayment.AmountPaid = payment.AmountPaid;
            editedPayment.DatePaid = payment.DatePaid;
            editedPayment.Balance = payment.Balance;
            editedPayment.ModifiedBy = payment.ModifiedBy;
            editedPayment.ModifiedDate = payment.ModifiedDate;

            db.SubmitChanges();
        }
    }
}
