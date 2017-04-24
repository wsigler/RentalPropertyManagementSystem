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
            var payments = new List<RentPayment>();
            var dateSpan = (eDate.Month + eDate.Year * 12) - (sDate.Month + sDate.Year * 12);

            if(proRateAmount > 0)
            {
                RentPayment payment = new RentPayment();
                payment.TenantID = tenantId;
                payment.PropertyID = propertyId;
                payment.PaymentDate = sDate;
                payment.PaymentAmount = proRateAmount;
                payment.AmountPaid = proRateAmount;
                payment.DatePaid = sDate;
                payment.Balance = 0;
                payments.Add(payment);
            }
            else
            {
                dateSpan++;
            }

            for (int x = 1; x <= dateSpan; x++)
            {
                RentPayment payment = new RentPayment();
                payment.TenantID = tenantId;
                payment.PropertyID = propertyId;
                DateTime paymentDate = (proRateAmount > 0) ? sDate.AddMonths(x) : sDate.AddMonths(x - 1);
                payment.PaymentDate = new DateTime(paymentDate.Year, paymentDate.Month, 5);
                payment.PaymentAmount = property.RentAmount;
                payment.Balance = property.RentAmount;
               
                payments.Add(payment);
            }

            new RentPaymentDAL().AddPayments(payments);
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

            var payment = db.RentPayments.FirstOrDefault(x => x.PropertyID == propertyId && (x.PaymentDate >= sDate && x.PaymentDate <= eDate));

            if(payment != null)
            {
                if(payment.DatePaid.HasValue)
                {

                    return (payment.Balance.Value > 0) ? payment.Balance.Value : 0M;
                }
                else
                {
                    return payment.PaymentAmount;
                }
            }
            else
            {
                return payment.PaymentAmount;
            }
        }
    }
}
