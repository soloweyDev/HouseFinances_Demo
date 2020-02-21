using System.Windows;

namespace HouseFinances
{
    /// <summary>
    /// Interaction logic for CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window
    {
        private CategoryViewModel categories;

        public CategoryWindow(CategoryViewModel categoryViewModel)
        {
            categories = categoryViewModel;
            InitializeComponent();
            DataContext = categories;
        }
    }
}
