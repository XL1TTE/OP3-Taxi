using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OP3.MVVM.Model
{

    public class TaxiAggregator
    {
        public static Random random = new Random();
        static List<Taxi.TaxiDriver> DriversToEmployee = new List<Taxi.TaxiDriver>()
        {
            new Taxi.TaxiDriver("Стив", new Taxi.Car($"{random.Next(0, 26)}{random.Next(1000, 10000)}", "Тесла Кибертрак", true)),
            new Taxi.TaxiDriver("Бэтмен", new Taxi.Car($"{random.Next(0, 26)}{random.Next(1000, 10000)}", "Бэтмобиль", true)),
            new Taxi.TaxiDriver("Ведьмак", new Taxi.Car($"{random.Next(0, 26)}{random.Next(1000, 10000)}", "Плотва", false)),
            new Taxi.TaxiDriver("Супермен", new Taxi.Car($"{random.Next(0, 26)}{random.Next(1000, 10000)}", "Супермен", false)),
            new Taxi.TaxiDriver("Флеш", new Taxi.Car($"{random.Next(0, 26)}{random.Next(1000, 10000)}", "Спина", false)),
            new Taxi.TaxiDriver("Стивен", new Taxi.Car($"{random.Next(0, 26)}{random.Next(1000, 10000)}", "Тесла Кибертрак", false)),
            new Taxi.TaxiDriver("Робин", new Taxi.Car($"{random.Next(0, 26)}{random.Next(1000, 10000)}", "Бэтмобиль", false)),
            new Taxi.TaxiDriver("Соловей", new Taxi.Car($"{random.Next(0, 26)}{random.Next(1000, 10000)}", "Плотва", false)),
            new Taxi.TaxiDriver("Муравей", new Taxi.Car($"{random.Next(0, 26)}{random.Next(1000, 10000)}", "Супермен", false)),
            new Taxi.TaxiDriver("Зум", new Taxi.Car($"{random.Next(0, 26)}{random.Next(1000, 10000)}", "Спина", false))
        };

        public ObservableCollection<TaxiOrder.Order> Orders = new ObservableCollection<TaxiOrder.Order>()
        {
            
        };

        public List<Taxi.TaxiDriver> TaxiDrivers = new List<Taxi.TaxiDriver>()
        {

        };

        public List<Taxi.TaxiDriver> TaxiDriversTemp = new List<Taxi.TaxiDriver>();

        public void AddNewTaxiDriver(Taxi.TaxiDriver driver)
        {
            driver.NotificationOfDriver += AddReadyDriverInTempList;
            TaxiDrivers.Add(driver);            
        }

        public void RemoveTaxiDriver(Taxi.TaxiDriver driver)
        {
            driver.NotificationOfDriver -= AddReadyDriverInTempList;
            TaxiDrivers.Remove(driver);
        }

        public void FindBestDriver()
        {
            List<double> Distances = new List<double>();
            double MinDistance = 1000000;
            Taxi.TaxiDriver BestDriver = null;
            for (int j = 0; j < TaxiDriversTemp.Count; j++)
            {
                Distances.Add(Math.Sqrt(Math.Pow((TaxiDriversTemp[j].CurrentLocation.Item1 - Orders[^1].Departure.Coordinates.Item1), 2) +
                    Math.Pow((TaxiDriversTemp[j].CurrentLocation.Item2 - Orders[^1].Departure.Coordinates.Item2), 2)));
                if (Distances[j] < MinDistance)
                {
                    BestDriver = TaxiDriversTemp[j];
                    MinDistance = Distances[j];
                }
            }
            if (BestDriver != null) { BestDriver.IsFree = false; }
            Orders[^1].Driver = BestDriver;
            Distances.Clear();
            TaxiDriversTemp.Clear();

        }

        public void AddReadyDriverInTempList(Taxi.ArgsOfTaxiDriver driverArgs)
        {
            TaxiDriversTemp.Add(driverArgs.TaxiDriver);
        }

        public void CreateAnOrder(Customer customer, TaxiOrder.Address departure, TaxiOrder.Address destination, bool isHaveChildSeat)
        {
            TaxiOrder.Order _order = new TaxiOrder.Order(customer, departure, destination, isHaveChildSeat);
            Orders.Add(_order);
            
            foreach(Taxi.TaxiDriver Driver in TaxiDrivers)
            {
                customer.NotificationOfCustomer += Driver.GoToOrder;
            }
            customer.TakeATaxi(new TaxiOrder.ArgsOfTaxiOrder(_order));
            FindBestDriver();
        }

        public TaxiAggregator()
        {
            foreach(var driver in DriversToEmployee)
            {
                AddNewTaxiDriver(driver);
            }
        }
    }
}
