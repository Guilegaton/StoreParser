using SimpleInjector;
using SimpleInjector.Lifestyles;
using StoreParser.Business.Sites.Rent;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StoreParser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Container _container = new Container();

        protected override void OnStartup(StartupEventArgs e)
        {
            ConfigureDependencies();

            var mainWindow = _container.GetInstance<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureDependencies()
        {
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Add application services. For instance:
            _container.Register<Gorod>(Lifestyle.Singleton);
            _container.Register<DomRia>(Lifestyle.Singleton);
            _container.Register<MainWindow>(() => new MainWindow(_container));

            _container.Verify();
        }
    }
}
