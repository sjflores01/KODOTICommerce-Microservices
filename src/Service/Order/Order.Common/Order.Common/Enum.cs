using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Order.Common
{
    public class Enum
    {
        public enum OrderStatus 
        { 
            Cancel,
            Pending,
            Approved
        }

        public enum OrderPayment
        {
            CreditCard,
            PayPal,
            BankTransfer
        }
    }
}
