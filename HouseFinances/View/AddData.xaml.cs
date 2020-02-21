using System.Windows;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Linq;

namespace HouseFinances
{
    /// <summary>
    /// Interaction logic for AddData.xaml
    /// </summary>
    public partial class AddData : Window
    {
        private readonly AddDataViewModel addData;

        /// <summary>
        /// Конструктор для добавления
        /// </summary>
        /// <param name="finans"></param>
        /// <param name="monthBalance"></param>
        /// <param name="yearMonth"></param>
        /// <param name="type"></param>
        public AddData(Finans finans, MonthBalance monthBalance, string yearMonth, string type)
        {
            addData = new AddDataViewModel(finans, yearMonth, type)
            {
                Data = {Edit = false, MonthBalance = monthBalance}
            };
            InitializeComponent();
            Title = addData.Data.Type;
            addData.Data.DayIndex = addData.Data.Daies.ToList().IndexOf(addData.Data.Day);
            addData.Data.CategoryIndex = addData.Data.Categories.Count - 1;
            addData.Data.ProductIndex = addData.Data.Products.Count - 1;
            addData.Data.Description = "нет пояснений";
            addData.Content = "Добавить";
            DataContext = addData;
        }

        /// <summary>
        /// Изменение суммы в поле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbSum_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (tbSum.Text.Length < 3) return;

            var separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            string match = @"^[0-9]{1,}" + separator + @"{0,1}[0-9]{0,2}$";
            if (!Regex.IsMatch(tbSum.Text, match))
            {
                MessageBox.Show($"Формат суммы: 10{separator}99", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.ServiceNotification);
            }
        }

        /// <summary>
        /// Изменение выбора категории
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbCategory_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (addData.Data.Category == "нет категории") return;

            addData.AddProduct(addData.Data.Category);
            if (!addData.Data.Edit)
                addData.Data.ProductIndex = addData.Data.Products.Count - 1;
            else
            {
                if (addData.Data.Products.FirstOrDefault(x => x == addData.Data.Product) == null)
                    addData.Data.ProductIndex = addData.Data.Products.Count - 1;
            }
        }
    }
}
