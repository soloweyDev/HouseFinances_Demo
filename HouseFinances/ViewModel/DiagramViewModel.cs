using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HouseFinances
{
    public class DiagramViewModel : DataProperty
    {
        private readonly Dictionary<string, double> groups = new Dictionary<string, double>();
        private IEnumerable<FinansDayTable> listMonth;
        private SeriesCollection myPie = new SeriesCollection();
        public SeriesCollection MyPie
        {
            get => myPie;
            set
            {
                myPie = value;
                OnPropertyChanged();
            }
        }

        public Func<ChartPoint, string> PointLabel { get; set; }

        public DiagramViewModel(DataGrid data)
        {
            listMonth = data.Items.SourceCollection.Cast<FinansDayTable>();
            if (listMonth.Count() == 0)
            {
                MessageBox.Show("В текущем месяце нет записей", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.ServiceNotification);
                return;
            }

            var temp = listMonth.GroupBy(x => x.Category);
            foreach (var element in temp)
            {
                groups[element.Key] = element.Sum(x => double.Parse(x.Sum));
            }
            groups = groups.OrderBy(x => x.Value).Reverse().ToDictionary(pair => pair.Key, pair => pair.Value);

            PointLabel = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            foreach (var element in groups)
            {
                MyPie.Add(new PieSeries
                {
                    Title = element.Key,
                    Values = new ChartValues<double>(new List<double> { element.Value }),
                    DataLabels = true,
                    LabelPoint = PointLabel
                });
            }
        }
    }
}
