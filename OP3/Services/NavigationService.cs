using OP3.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace OP3.Services
{

    public interface InavigationService
    {
        ViewModelBase CurrentView { get; }
        void NavigateTo<T>() where T: ViewModelBase;
    }
    public class NavigationService : ObservableObject, InavigationService
    {
        private Func<Type, ViewModelBase> _viewModelFactory;

        private ViewModelBase _currentView;
        public ViewModelBase CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged() ;
            }
        }

        public NavigationService(Func<Type, ViewModelBase> ViewModelFactory)
        {
            _viewModelFactory = ViewModelFactory;
        }

        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
        {
            ViewModelBase ViewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            CurrentView = ViewModel;
        }
    }
}
