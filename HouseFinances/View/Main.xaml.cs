using System.Windows;

namespace HouseFinances
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel mainViewModel;

        public MainWindow()
        {
            InitializeComponent();
            mainViewModel = new MainViewModel();
            DataContext = mainViewModel;
            mainViewModel.Index = mainViewModel.ListYearsMonths.IndexOf(mainViewModel.YearMonth);
        }
    }
}
