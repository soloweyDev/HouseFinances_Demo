using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Xml.Serialization;

namespace HouseFinances
{
    /// <summary>
    /// Класс вывода данных категории-продукты в виде дерева
    /// </summary>
    public class CategoryViewModel : DataProperty
    {
        public readonly string PathCategoryFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HouseFinances", "category.xml");

        private CategoriesProducts сategoriesProducts;
        private string selectName;
        private RelayCommand close;
        private RelayCommand add;
        private RelayCommand edit;
        private RelayCommand del;

        public CategoriesProducts CategoriesProducts {
            get => сategoriesProducts;
            set
            {
                сategoriesProducts = value;
                OnPropertyChanged();
            }
        }
        public string SelectName
        {
            get => selectName;
            set
            {
                selectName = value;
                OnPropertyChanged();
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
        public RelayCommand Edit
        {
            get
            {
                return edit ?? (edit = new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    MessageBox.Show(window, "Функционал программы ограничен.", "Демо-версия", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                }));
            }
        }
        public RelayCommand Del
        {
            get
            {
                return del ?? (del = new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    MessageBox.Show(window, "Функционал программы ограничен.", "Демо-версия", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                }));
            }
        }

        public CategoryViewModel()
        {
            CategoriesProducts = new CategoriesProducts();
        }
                
        /// <summary>
        /// Загрузка данных из файла category.xml
        /// </summary>
        public void CategoriesProductsLoad()
        {
            if (File.Exists(PathCategoryFile))
            {
                using (var sr = new StreamReader(PathCategoryFile, Encoding.Default))
                {
                    var xml = new XmlSerializer(typeof(CategoriesProducts));
                    CategoriesProducts = xml.Deserialize(sr) as CategoriesProducts;
                }
            }

            if (CategoriesProducts == null) return;

            foreach (var category in CategoriesProducts.Categories)
            {
                foreach (var product in category.Products)
                {
                    product.Parent = category.Name;
                }
            }
        }        
    }
}
