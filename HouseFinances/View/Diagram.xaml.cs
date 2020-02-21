using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace HouseFinances
{
    public partial class Diagram : Window
    {
        public Diagram(DataGrid data, bool income = true)
        {
            InitializeComponent();
            Title = data.Items.SourceCollection is IEnumerable<FinansDayAll> ? "Графики" : income ? "Приход" : "Расход";
            DiagramViewModel graphViewModel = new DiagramViewModel(data);
            DataContext = graphViewModel;
        }
    }
}
