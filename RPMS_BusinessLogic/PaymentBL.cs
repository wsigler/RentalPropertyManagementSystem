using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using RPMS_Database;

namespace RPMS_BusinessLogic
{
    public class PaymentBL
    {
        private RentalManagementDBDataContext db = new RentalManagementDBDataContext();

        public void CreatePayments(int tenantId, int propertyId, DateTime sDate, DateTime eDate, decimal proRateAmount)
        {
            var property = db.Properties.FirstOrDefault(x => x.ID == propertyId);
            var payments = new List<Payment>();
            var dateSpan = (eDate.Month + eDate.Year * 12) - (sDate.Month + sDate.Year * 12);

            if (proRateAmount > 0)
            {
                Payment payment = new Payment();
                payment.TenantID = tenantId;
                payment.PropertyID = propertyId;
                payment.DueDate = sDate;
                payment.AmountDue = proRateAmount;
                payment.PaymentAmount = proRateAmount;
                payment.PaymentDate = sDate;
                payment.Balance = 0;
                payment.ModifiedBy = 1;
                payment.ModifiedDate = DateTime.Now;
                payments.Add(payment);
            }
            else
            {
                dateSpan++;
            }

            for (int x = 1; x <= dateSpan; x++)
            {
                Payment payment = new Payment();
                payment.TenantID = tenantId;
                payment.PropertyID = propertyId;
                DateTime paymentDate = (proRateAmount > 0) ? sDate.AddMonths(x) : sDate.AddMonths(x - 1);
                payment.DueDate = new DateTime(paymentDate.Year, paymentDate.Month, 5);
                payment.AmountDue = property.RentAmount;
                payment.Balance = property.RentAmount;

                payments.Add(payment);
            }

            new PaymentDAL().AddPayments(payments);
        }

        public decimal ProrateAmount(DateTime sDate, decimal rentAmount)
        {
            int daysInMonth = DateTime.DaysInMonth(sDate.Year, sDate.Month);
            int daysLeft = daysInMonth - sDate.Day;

            decimal perDayRent = rentAmount / daysInMonth;

            decimal proRatedAmount = Math.Round(perDayRent * daysLeft, 2);

            return proRatedAmount;
        }

        public decimal IsRentCurrent(int propertyId)
        {
            DateTime sDate = new DateTime();
            DateTime eDate = new DateTime();

            if (DateTime.Now.Day < 5)
            {
                sDate = new DateTime(DateTime.Now.Month - 1, 4, DateTime.Now.Year);
                eDate = new DateTime(DateTime.Now.Month - 1, 6, DateTime.Now.Year);
            }
            else
            {
                sDate = new DateTime(DateTime.Now.Month, 4, DateTime.Now.Year);
                eDate = new DateTime(DateTime.Now.Month, 6, DateTime.Now.Year);
            }

            var payment = db.Payments.FirstOrDefault(x => x.PropertyID == propertyId && (x.DueDate >= sDate && x.DueDate <= eDate));

            if (payment != null)
            {
                if (payment.PaymentDate.HasValue)
                {

                    return payment.Balance;
                }
                else
                {
                    return payment.AmountDue;
                }
            }
            else
            {
                return payment.AmountDue;
            }
        }
    }
}
