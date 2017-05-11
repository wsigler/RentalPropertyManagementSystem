using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPMS_BusinessLogic
{
    public class Enums
    {
        public enum PaymentTypes
        {
            Rent = 5000,
            DailyLatePayment = 5001,
            InitialLateCharge = 5002,
            CheckReturn = 5003
        }
    }
}
