using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace HouseFinances
{
    /// <summary>
    /// класс катерогии и продуктов, для работы с файлом category.xml
    /// </summary>
    [Serializable]
    [XmlRoot("КатегорииПродукты")]
    public sealed class CategoriesProducts
    {
        [XmlArray("Категории")]
        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();
    }

    /// <summary>
    /// класс категорий, для работы с файлом category.xml
    /// </summary>
    [Serializable]
    [XmlType("Категория")]
    public class Category : DataProperty
    {
        [NonSerialized]
        private string name;

        [XmlElement("Название")]
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        [XmlArray("Продукты")]
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
    }

    /// <summary>
    /// класс продукт, для работы с файлом category.xml
    /// </summary>
    [Serializable]
    [XmlType("Продукт")]
    public class Product : DataProperty
    {
        [NonSerialized]
        private string name;

        [XmlElement("Название")]
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        [XmlIgnore]
        public string Parent;
    }
}
