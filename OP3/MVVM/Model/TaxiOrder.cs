using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace OP3.MVVM.Model
{
    public class TaxiOrder
    {
        static Random random = new Random();
        public class ArgsOfTaxiOrder
        {
            public Order Order { get; set; }
            public ArgsOfTaxiOrder(Order _order)
            {
                Order = _order;
            }
        }
        public class Address
        {
            public (double, double) Coordinates { get; set; }
            public string Street { get; set; }
            public string House { get; set; }
            public string FullAdress { get; set; }

            public Address(string street, string house)
            {
                House = house;
                Street = street;
                FullAdress = $"{Street} {House}";
                Coordinates = (random.Next(0, 100), random.Next(0, 100));
            }
        }
        public class Order
        {
            public Address Departure { get; set; }
            public Address Destination { get; set; }
            public bool IsChildSeatNeeded { get; set; }
            public double Distance { get; set; }
            public Taxi.TaxiDriver Driver { get; set; }
            public Customer Customer { get; set; }

            public Order(Customer customer, TaxiOrder.Address departure, TaxiOrder.Address destination, bool isHaveChildSeat)
            {
                Customer = customer;
                Departure = departure;
                Destination = destination;
                IsChildSeatNeeded = isHaveChildSeat;
            }
        }
    }
}
