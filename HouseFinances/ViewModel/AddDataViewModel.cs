using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;

namespace HouseFinances
{
    public class AddDataViewModel : DataProperty
    {
        public readonly string PathBalanceFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HouseFinances", "balance.xml");

        private string yearMonth;
        private Data data;
        private readonly FinansDay oldFinansDay;
        private ObservableCollection<FinansDayTable> table = new ObservableCollection<FinansDayTable>();
        private FinanceViewModel finance;
        private CategoryViewModel categories;
        private string content;
        private RelayCommand preview;
        private RelayCommand close;
        private RelayCommand add;

        public string YearMonth
        {
            get => yearMonth;
            set
            {
                yearMonth = value;
                OnPropertyChanged();
            }
        }
        public Data Data
        {
            get => data;
            set
            {
                data = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<FinansDayTable> Table
        {
            get => table;
            set
            {
                table = value;
                OnPropertyChanged();
            }
        }
        public string Content
        {
            get => content;
            set
            {
                content = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand Preview
        {
            get
            {
                return preview ?? (preview = new RelayCommand(obj =>
                {
                    Table?.Clear();
                    Table.Add(new FinansDayTable { Day = Data.Day, Sum = Data.Sum, Category = Data.Category, Product = Data.Product, Description = Data.Description });
                }));
            }
        }
        public RelayCommand Close
        {
            get
            {
                return close ?? (close = new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    window.Close();
                }));
            }
        }
        public RelayCommand Add
        {
            get
            {
                return add ?? (add = new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    MessageBox.Show(window, "Функционал программы ограничен.", "Демо-версия", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                }));
            }
        }

        public AddDataViewModel(Finans finance, string yearMonth, string type)
        {
            Init(finance, yearMonth, type);
        }

        private void Init(Finans finance, string yearMonth, string type)
        {
            categories = new CategoryViewModel();
            categories.CategoriesProductsLoad();
            this.finance = new FinanceViewModel(finance);
            Data = new Data();

            YearMonth = yearMonth;
            Data.Type = type;
            Data.Daies = new ObservableCollection<string>();
            Data.Categories = new ObservableCollection<string>();
            Data.Products = new ObservableCollection<string>();
            Data.Sum = "0" + CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0] + "00";
            AddDays();
            AddCategory("нет категории");
            AddProduct();
        }

        /// <summary>
        /// Добавление дней в месяце
        /// </summary>
        private void AddDays()
        {
            Data.Daies.Clear();
            var days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            for (int d = 1; d <= days; d++)
            {
                Data.Daies.Add(d.ToString());
            }
            Data.Day = DateTime.Now.Day.ToString();
        }

        /// <summary>
        /// Добавлениме категорий
        /// </summary>
        private void AddCategory(string name)
        {
            Data.Categories.Clear();
            Data.Categories = new ObservableCollection<string>(categories.CategoriesProducts.Categories.Select(x => x.Name).ToList()) { name };
            Data.Category = name;
        }

        /// <summary>
        /// Добавление пустого списка продукты/товары
        /// </summary>
        private void AddProduct()
        {
            Data.Products.Add("нет наименования");
            Data.Product = "нет наименования";
        }

        /// <summary>
        /// Добавление пустого списка продукты/товары
        /// </summary>
        /// <param name="category">Наименование категории</param>
        public void AddProduct(string category)
        {
            Data.Products.Clear();
            if (categories.CategoriesProducts.Categories.ToList().Find(x => x.Name == category) == null)
            {
                Data.Products = new ObservableCollection<string> {"нет наименования"};
            }
            else
            {
                Data.Products = new ObservableCollection<string>(categories.CategoriesProducts.Categories.ToList()
                    .Find(x => x.Name == category).Products.Select(x => x.Name).ToList()) { "нет наименования" };
            }

            if (!Data.Edit)
                Data.Product = "нет наименования";
        }

    }
}
