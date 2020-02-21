using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;


namespace HouseFinances
{
    /// <summary>
    /// класс финансов, для работы с файлом finans.xml
    /// </summary>
    [Serializable]
    [XmlRoot("финансы")]
    public sealed class Finans
    {
        [XmlArray("годы")]
        public ObservableCollection<FinansYear> Years { get; set; }
    }

    /// <summary>
    /// класс год, для работы с файлом finans.xml 
    /// </summary>
    [Serializable]
    [XmlType("год")]
    public class FinansYear
    {
        [XmlElement("Название")]
        public string Name { get; set; }

        [XmlArray("месяца")]
        public ObservableCollection<FinansMonth> Months { get; set; }
    }

    /// <summary>
    /// класс месяца, для работы с файлом finans.xml
    /// </summary>
    [Serializable]
    [XmlType("месяц")]
    public class FinansMonth
    {
        [XmlElement("Название")]
        public string Name { get; set; }

        [XmlArray("дни")]
        public ObservableCollection<FinansDay> Days { get; set; }
    }

    /// <summary>
    /// класс день, для работы с файлом finans.xml
    /// </summary>
    [Serializable]
    [XmlType("День")]
    public class FinansDay
    {
        [XmlElement("Название")]
        public string Day { get; set; }

        [XmlElement("Операция")]
        public Opiration Opiration { get; set; }
    }

    /// <summary>
    /// класс операции, для работы с файлом finans.xml
    /// </summary>
    [Serializable]
    public class Opiration
    {
        [XmlElement("Тип")]
        public string Type { get; set; }

        [XmlElement("Сумма")]
        public string Sum { get; set; }

        [XmlElement("Категория")]
        public string CategoryName { get; set; }

        [XmlElement("Наименование")]
        public string ProductName { get; set; }

        [XmlElement("Пояснение")]
        public string Description { get; set; }
    }

    /// <summary>
    /// класс данных прихода и расхода по дням для отображения таблице
    /// </summary>
    public sealed class FinansDayAll
    {
        public string Day { get; set; }
        public string Incoming { get; set; }
        public string Expense { get; set; }
    }

    /// <summary>
    /// класс данных прихода или расхода по дням для отображения таблице
    /// </summary>
    public sealed class FinansDayTable
    {
        public string Day { get; set; }
        public string Sum { get; set; }
        public string Category { get; set; }
        public string Product { get; set; }
        public string Description { get; set; }
    }
}
