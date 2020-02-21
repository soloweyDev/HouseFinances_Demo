using System.Windows;

namespace HouseFinances
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
            AboutViewModel about = new AboutViewModel();
            DataContext = about;
        }
    }
}
