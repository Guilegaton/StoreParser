using SimpleInjector;
using StoreParser.Business.Interfaces;
using StoreParser.Business.Sites.Rent;
using StoreParser.Models.Entities;
using StoreParser.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.DataVisualization.Charting;

namespace StoreParser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IBaseDependendentWindow
    {
        private const ushort _pageCount = 4;

        private DomRia _domRiaSiteService { get; set; }
        private Gorod _gorodSiteService { get; set; }
        private Container _container { get; }

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(Container container)
        {
            _container = container;
            ProcessDependencies(_container);
            InitializeComponent();
            LoadColumnChartData(GetRentOrders());
            RentTB.ItemsSource = GetRentOrderVeiwModels();
        }

        private void LoadColumnChartData(IList<RentOrder> orders)
        {
            foreach (var group in orders.GroupBy(order => order.Location.Trim()))
            {
                var columnPrice = new ColumnSeries
                {
                    Title = group.Key,
                    ItemsSource = new KeyValuePair<string, double>[] { new KeyValuePair<string, double>("", (group.Sum(g => g.Price) / group.Count()).Value) },
                    DependentValueBinding = new System.Windows.Data.Binding("Value"),
                    IndependentValueBinding = new System.Windows.Data.Binding("Key")
                };

                PriceChart.Series.Add(columnPrice);
            }


            foreach (var group in orders.Where(order => order.Space > 0).GroupBy(order => order.Location.Trim()))
            {
                var columnSpace = new ColumnSeries
                {
                    Title = group.Key,
                    ItemsSource = new KeyValuePair<string, double>[] { new KeyValuePair<string, double>("", (group.Sum(g => g.Space) / group.Count()).Value) },
                    DependentValueBinding = new System.Windows.Data.Binding("Value"),
                    IndependentValueBinding = new System.Windows.Data.Binding("Key")
                };
                SpaceChart.Series.Add(columnSpace);
            }
        }

        public void ProcessDependencies(Container container)
        {
            _domRiaSiteService = container.GetInstance<DomRia>();
            _gorodSiteService = container.GetInstance<Gorod>();
        }

        protected override void OnClosed(EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private IList<RentOrder> GetRentOrders()
        {
            var result = new List<RentOrder>();
            Parallel.For(1, _pageCount, (i) =>
            {
                lock (result)
                {
                    result.AddRange(_domRiaSiteService.GetOrders(i));
                    result.AddRange(_gorodSiteService.GetOrders(i));
                }
            });

            return result;
        }

        private IList<RentOrderViewModel> GetRentOrderVeiwModels()
        {
            var result = new List<RentOrderViewModel>();
            Parallel.For(1, _pageCount, (i) =>
            {
                lock (result)
                {
                    result.AddRange(_domRiaSiteService.GetViewModels(i));
                    result.AddRange(_gorodSiteService.GetViewModels(i));
                }
            });

            return result;
        }
    }
}
