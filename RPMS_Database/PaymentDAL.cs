using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPMS_Database
{
    public class PaymentDAL
    {
        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();

        public void AddPayments(List<Payment> payments)
        {
            try
            {
                payments.ForEach(x => {
                    db.Payments.InsertOnSubmit(x);
                    db.SubmitChanges();
                });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdatePayment(Payment payment)
        {
            var editedPayment = db.Payments.FirstOrDefault(x => x.ID == payment.ID);
            editedPayment.ID = payment.ID;
            editedPayment.PropertyID = payment.PropertyID;
            editedPayment.TenantID = payment.TenantID;
            editedPayment.AmountDue = payment.AmountDue;
            editedPayment.DueDate = payment.DueDate;
            editedPayment.PaymentAmount = payment.PaymentAmount;
            editedPayment.PaymentDate = payment.PaymentDate;
            editedPayment.Balance = payment.Balance;
            editedPayment.ModifiedBy = payment.ModifiedBy;
            editedPayment.ModifiedDate = payment.ModifiedDate;
            editedPayment.TypeID = payment.TypeID;

            db.SubmitChanges();
        }
    }
}
