using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OP3.MVVM.Model.TaxiOrder;

namespace OP3.MVVM.Model
{
    public class Customer
    {

        public delegate void WantToTakeATaxi(TaxiOrder.ArgsOfTaxiOrder OrderArgs);
        public event WantToTakeATaxi NotificationOfCustomer;

        public string Name { get; set; }


        public Customer(string name)
        {
            Name = name;
        }

        public void TakeATaxi(TaxiOrder.ArgsOfTaxiOrder OrderArgs)
        {
            NotificationOfCustomer?.Invoke(OrderArgs);
        }
    }
}
