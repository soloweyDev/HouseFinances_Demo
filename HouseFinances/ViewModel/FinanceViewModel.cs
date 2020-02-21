using System;
using System.Collections.ObjectModel;
using System.IO;

namespace HouseFinances
{
    public class FinanceViewModel : DataProperty
    {
        public readonly string PathFinanceFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HouseFinances", "finance.xml");

        private Finans finansData;
        public Finans FinansData
        {
            get => finansData;
            set
            {
                finansData = value;
                OnPropertyChanged();
            }
        }

        public FinanceViewModel()
        {
        }

        public FinanceViewModel(Finans finans)
        {
            finansData = finans;
        }
        
        /// <summary>
        /// Загрузка файла finans.xml
        /// </summary>
        public void FinansLoad()
        {
            FinansData = new Finans {
                Years = new ObservableCollection<FinansYear>
                {
                    new FinansYear
                    {
                        Name = "2020",
                        Months = new ObservableCollection<FinansMonth>
                        {
                            new FinansMonth
                            {
                                Name = "февраль",
                                Days = new ObservableCollection<FinansDay>
                                {
                                    new FinansDay
                                    {
                                        Day = "1",
                                        Opiration = new Opiration
                                        {
                                            Type = "Приход",
                                            Sum = "1000000",
                                            CategoryName = "работа",
                                            ProductName = "зарплата",
                                            Description = "нет пояснений"
                                        }
                                    },
                                    new FinansDay
                                    {
                                        Day = "1",
                                        Opiration = new Opiration
                                        {
                                            Type = "Расход",
                                            Sum = "300000",
                                            CategoryName = "проезд",
                                            ProductName = "единый билет",
                                            Description = "на месяц"
                                        }
                                    },
                                    new FinansDay
                                    {
                                        Day = "1",
                                        Opiration = new Opiration
                                        {
                                            Type = "Расход",
                                            Sum = "250000",
                                            CategoryName = "содержание жилья",
                                            ProductName = "комунальные платежи",
                                            Description = "нет пояснений"
                                        }
                                    },
                                    new FinansDay
                                    {
                                        Day = "2",
                                        Opiration = new Opiration
                                        {
                                            Type = "Расход",
                                            Sum = "300000",
                                            CategoryName = "продукты",
                                            ProductName = "нет наименования",
                                            Description = "нет пояснений"
                                        }
                                    },
                                    new FinansDay
                                    {
                                        Day = "5",
                                        Opiration = new Opiration
                                        {
                                            Type = "Расход",
                                            Sum = "120000",
                                            CategoryName = "досуг",
                                            ProductName = "входной билет в парк",
                                            Description = "нет пояснений"
                                        }
                                    },
                                    new FinansDay
                                    {
                                        Day = "6",
                                        Opiration = new Opiration
                                        {
                                            Type = "Расход",
                                            Sum = "210000",
                                            CategoryName = "продукты",
                                            ProductName = "нет наименования",
                                            Description = "нет пояснений"
                                        }
                                    },
                                    new FinansDay
                                    {
                                        Day = "10",
                                        Opiration = new Opiration
                                        {
                                            Type = "Приход",
                                            Sum = "200000",
                                            CategoryName = "банк",
                                            ProductName = "проценты",
                                            Description = "нет пояснений"
                                        }
                                    },
                                    new FinansDay
                                    {
                                        Day = "11",
                                        Opiration = new Opiration
                                        {
                                            Type = "Расход",
                                            Sum = "180000",
                                            CategoryName = "продукты",
                                            ProductName = "нет наименования",
                                            Description = "нет пояснений"
                                        }
                                    },
                                    new FinansDay
                                    {
                                        Day = "15",
                                        Opiration = new Opiration
                                        {
                                            Type = "Приход",
                                            Sum = "1000000",
                                            CategoryName = "работа",
                                            ProductName = "зарплата",
                                            Description = "нет пояснений"
                                        }
                                    },
                                    new FinansDay
                                    {
                                        Day = "16",
                                        Opiration = new Opiration
                                        {
                                            Type = "Приход",
                                            Sum = "300000",
                                            CategoryName = "почта",
                                            ProductName = "почтовые отправления",
                                            Description = "нет пояснений"
                                        }
                                    },
                                    new FinansDay
                                    {
                                        Day = "16",
                                        Opiration = new Opiration
                                        {
                                            Type = "Расход",
                                            Sum = "165000",
                                            CategoryName = "продукты",
                                            ProductName = "нет наименования",
                                            Description = "нет пояснений"
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
        
    }
}
