using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace HouseFinances
{
    /// <summary>
    /// класс баланса, для работы с файлом balans.xml
    /// </summary>
    [Serializable]
    [XmlRoot("баланс")]
    public sealed class Balance
    {
        [XmlArray("годы")]
        public ObservableCollection<BalanceYear> Years { get; set; }
    }

    /// <summary>
    /// класс год, для работы с файлом balans.xml
    /// </summary>
    [Serializable]
    [XmlType("год")]
    public class BalanceYear
    {
        [XmlElement("Название")]
        public string Name { get; set; }

        [XmlArray("месяца")]
        public ObservableCollection<BalanceMonth> Months { get; set; }
    }

    /// <summary>
    /// класс месяц, для работы с файлом balans.xml
    /// </summary>
    [Serializable]
    [XmlType("месяц")]
    public class BalanceMonth
    {
        [XmlElement("Название")]
        public string Name { get; set; }

        [XmlElement("Остаток")]
        public long OldMonth { get; set; }

        [XmlElement("Приход")]
        public long Incoming { get; set; }

        [XmlElement("Расход")]
        public long Expense { get; set; }

        [XmlElement("Баланс")]
        public long Balance { get; set; }
    }
}
