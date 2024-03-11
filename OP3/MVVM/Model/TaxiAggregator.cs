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

        public ObservableCollection<TaxiOrder.Order> Orders = new ObservableCollection<TaxiOrder.Order>()
        {
            
        };

        public List<Taxi.TaxiDriver> TaxiDrivers = new List<Taxi.TaxiDriver>()
        {
            new Taxi.TaxiDriver("Стив", new Taxi.Car($"{random.Next(0, 26)}{random.Next(1000, 10000)}", "Тесла Кибертрак", true)),
            new Taxi.TaxiDriver("Бэтмен", new Taxi.Car($"{random.Next(0, 26)}{random.Next(1000, 10000)}", "Бэтмобиль", true)),
            new Taxi.TaxiDriver("Ведьмак", new Taxi.Car($"{random.Next(0, 26)}{random.Next(1000, 10000)}", "Плотва", false)),
            new Taxi.TaxiDriver("Супермен", new Taxi.Car($"{random.Next(0, 26)}{random.Next(1000, 10000)}", "Супермен", false)),
            new Taxi.TaxiDriver("Флеш", new Taxi.Car($"{random.Next(0, 26)}{random.Next(1000, 10000)}", "Спина", false))
        };

        public List<Taxi.TaxiDriver> TaxiDriversTemp { get; set; }

        public void AddNewTaxiDriver(Taxi.TaxiDriver driver)
        {
            TaxiDrivers.Add(driver);
        }

        public void RemoveTaxiDriver(Taxi.TaxiDriver driver)
        {
            TaxiDrivers.Remove(driver);
        }

        public void FindBestDriver()
        {

        }

        public void AddReadyDriverInTempList(Taxi.ArgsOfTaxiDriver driverArgs)
        {

        }

        public void CreateAnOrder(Customer customer, TaxiOrder.Address departure, TaxiOrder.Address destination, bool isHaveChildSeat)
        {
            Orders.Add(new TaxiOrder.Order(customer, departure, destination, isHaveChildSeat));
        }
    }
}
