using Microsoft.Extensions.DependencyInjection;
using OP3.Core;
using OP3.MVVM.Model;
using OP3.MVVM.View;
using OP3.MVVM.ViewModel;
using OP3.Services;
using System;
using System.Windows;


namespace OP3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainWindowViewModel>()
            });
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<OrderWindowViewModel>();
            services.AddSingleton<TaxiDriversListWindowViewModel>();

            services.AddSingleton<InavigationService, NavigationService>();
            services.AddSingleton<Func<Type, ViewModelBase>>(provider => ViewModelType => (ViewModelBase)provider.GetRequiredService(ViewModelType));


            services.AddSingleton<TaxiAggregator>();

            _serviceProvider = services.BuildServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            
            var MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
