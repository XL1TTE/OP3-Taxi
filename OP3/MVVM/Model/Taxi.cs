﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP3.MVVM.Model
{   
    public class Taxi
    {
        public class ArgsOfTaxiDriver
        {
            public TaxiDriver TaxiDriver { get; set; }
            public ArgsOfTaxiDriver(TaxiDriver taxiDriver)
            {
                TaxiDriver = taxiDriver;
            }
        }

        public class Car
        {
            public string Number { get; set; }
            public string CarMark { get; set; }
            bool ChildSeat { get; set; }

            public Car(string number, string carMark, bool childSeat)
            {
                Number = number;
                CarMark = carMark;
                ChildSeat = childSeat;
            }
        }

        public class TaxiDriver
        {
            public delegate void RespondedToOrder();
            public event RespondedToOrder NotificationOfDriver;

            public string Name { get; set; }
            public (double, double) CurrentLocation { get; set; }
            public double Rating { get; set; }
            public bool IsFree { get; set; }
            public Car Car { get; set; }

            public TaxiDriver(string name, Car car)
            {
                Name = name; 
                Car = car;
            }

            public void GoToOrder(TaxiOrder.ArgsOfTaxiOrder order)
            {

            }
        }

    }
}