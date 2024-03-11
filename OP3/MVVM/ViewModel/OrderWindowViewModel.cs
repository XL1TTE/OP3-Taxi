using OP3.Core;
using OP3.MVVM.Model;
using OP3.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP3.MVVM.ViewModel
{
    public class OrderWindowViewModel: ViewModelBase
    {
        private TaxiAggregator TaxiAggregator;

        private InavigationService _navigation;
        public InavigationService Navigation
        {
            get => _navigation;

            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        private string _customerFIO;
        public string CustomerFIO
        {
            get => _customerFIO;
            set
            {
                _customerFIO = value;
                OnPropertyChanged();
            }
        }

        private string _destinationStreet;
        public string DestinationStreet
        {
            get => _destinationStreet;
            set
            {
                _destinationStreet = value;
                OnPropertyChanged();
            }
        }
        private string _departureStreet;
        public string DepartureStreet
        {
            get => _departureStreet;
            set
            {
                _departureStreet = value;
                OnPropertyChanged();
            }
        }
        private string _destinationHome;
        public string DestinationHome
        {
            get => _destinationHome;
            set
            {
                _destinationHome = value;
                OnPropertyChanged();
            }
        }
        private string _departureHome;
        public string DepartureHome
        {
            get => _departureHome;
            set
            {
                _departureHome = value;
                OnPropertyChanged();
            }
        }

        private bool _childSeatNeeded;
        public bool ChildSeatNeeded
        {
            get => _childSeatNeeded;
            set
            {
                _childSeatNeeded = value;
                if(value == false) { ChildSeatTextVisible = "Hidden"; }
                else { ChildSeatTextVisible = "Visible"; }
                OnPropertyChanged();
            }
        }
        private string _childSeatTextVisible = "Hidden";
        public string ChildSeatTextVisible
        {
            get => _childSeatTextVisible;
            set
            {
                _childSeatTextVisible = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<TaxiOrder.Order> _ordersList;
        public ObservableCollection<TaxiOrder.Order> OrdersList
        {
            get => _ordersList;
            set
            {
                _ordersList = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateToDriversList { get; set; }
        public RelayCommand CreateAnOrder { get; set; }
        public OrderWindowViewModel(InavigationService navigationService, TaxiAggregator taxiAggregator)
        {
            Navigation = navigationService;
            TaxiAggregator = taxiAggregator;

            NavigateToDriversList = new RelayCommand(o => Navigation.NavigateTo<TaxiDriversListWindowViewModel>(), o => true);
            CreateAnOrder = new RelayCommand(o => _CreateAnOrder(), o => true);
        }

        private void _CreateAnOrder()
        {
            TaxiAggregator.CreateAnOrder(new Customer(CustomerFIO), new TaxiOrder.Address(DepartureStreet, DepartureHome),
                new TaxiOrder.Address(DestinationStreet, DestinationHome), ChildSeatNeeded);
            OrdersList = TaxiAggregator.Orders;
            _ClearFields();
        }
        private void _ClearFields()
        {
            CustomerFIO = String.Empty;
            DepartureStreet = String.Empty;
            DepartureHome = String.Empty;
            DestinationStreet = String.Empty;
            DestinationHome = String.Empty;
            ChildSeatNeeded = false;
        }
    }
}
