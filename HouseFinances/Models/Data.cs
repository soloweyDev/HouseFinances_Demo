using System.Collections.ObjectModel;

namespace HouseFinances
{
    public class Data : DataProperty
    {
        private string type;
        private string day;
        private ObservableCollection<string> daies;
        private string sum;
        private ObservableCollection<string> categories;
        private ObservableCollection<string> products;
        private string description;
        private bool edit;
        private MonthBalance monthBalance;
        private string category;
        private string product;
        private int dayIndex;
        private int categoryIndex;
        private int productIndex;

        public string Type
        {
            get => type;
            set
            {
                type = value;
                OnPropertyChanged();
            }
        }
        public string Day
        {
            get => day;
            set
            {
                day = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<string> Daies
        {
            get => daies;
            set
            {
                daies = value;
                OnPropertyChanged();
            }
        }
        public string Sum
        {
            get => sum;
            set
            {
                sum = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<string> Categories
        {
            get => categories;
            set
            {
                categories = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<string> Products
        {
            get => products;
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }
        public bool Edit
        {
            get => edit;
            set
            {
                edit = value;
                OnPropertyChanged();
            }
        }
        public MonthBalance MonthBalance
        {
            get => monthBalance;
            set
            {
                monthBalance = value;
                OnPropertyChanged();
            }
        }
        public string Category
        {
            get => category;
            set
            {
                category = value;
                OnPropertyChanged();
            }
        }
        public string Product
        {
            get => product;
            set
            {
                product = value;
                OnPropertyChanged();
            }
        }
        public int DayIndex
        {
            get => dayIndex;
            set
            {
                dayIndex = value;
                OnPropertyChanged();
            }
        }
        public int CategoryIndex
        {
            get => categoryIndex;
            set
            {
                categoryIndex = value;
                OnPropertyChanged();
            }
        }
        public int ProductIndex
        {
            get => productIndex;
            set
            {
                productIndex = value;
                OnPropertyChanged();
            }
        }
    }
}
