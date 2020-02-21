using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HouseFinances
{
    public class MainViewModel : DataProperty
    {
        private readonly string DirApp = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HouseFinances");
        private readonly string DirBackup = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HouseFinances", "Backup");
        private readonly string DirUpdate = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HouseFinances", "Update");
        private readonly string PathBalanceFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HouseFinances", "balance.xml");
        private readonly string PathFinanceFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HouseFinances", "finance.xml");
        private readonly string PathCategoryFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HouseFinances", "category.xml");
        private readonly string PathBackupFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HouseFinances", "Update", "backup.txt");
        private readonly string PathBackupVersionFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HouseFinances", "update.ver");

        private string currentYear, currentMonth;
        private string yearMonth;
        private List<string> listYearsMonths;
        private int index;
        private MonthBalance monthBalance;
        private ObservableCollection<FinansDayAll> listAll;
        private ObservableCollection<FinansDayTable> listIncoming;
        private ObservableCollection<FinansDayTable> listExpense;
        private FinanceViewModel finance;
        private CategoryViewModel categories;

        public string YearMonth
        {
            get => yearMonth;
            set
            {
                yearMonth = value;
                OnPropertyChanged();
            }
        }
        public List<string> ListYearsMonths
        {
            get => listYearsMonths;
            set
            {
                listYearsMonths = value;
                OnPropertyChanged();
            }
        }
        public int Index
        {
            get => index;
            set
            {
                index = value;
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
        public ObservableCollection<FinansDayAll> ListAll
        {
            get => listAll;
            set
            {
                listAll = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<FinansDayTable> ListIncoming
        {
            get => listIncoming;
            set
            {
                listIncoming = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<FinansDayTable> ListExpense
        {
            get => listExpense;
            set
            {
                listExpense = value;
                OnPropertyChanged();
            }
        }
        public FinanceViewModel Finance
        {
            get => finance;
            set
            {
                finance = value;
                OnPropertyChanged();
            }
        }
        public CategoryViewModel Categories
        {
            get => categories;
            set
            {
                categories = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand demo;
        private RelayCommand close;
        private RelayCommand about;
        private RelayCommand web;
        private RelayCommand category;
        private RelayCommand addIncoming;
        private RelayCommand addExpense;
        private RelayCommand diagramIncoming;
        private RelayCommand diagramExpense;
        public RelayCommand Demo
        {
            get
            {
                return demo ?? (demo = new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    MessageBox.Show(window, "Функционал программы ограничен.", "Демо-версия", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
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
        public RelayCommand Web
        {
            get
            {
                return web ?? (web = new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    try
                    {
                        System.Diagnostics.Process.Start("www.adistudiya.ru");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(window, "Не найдено ни одного Интернет браузера.\nУстановите программу для открытия ссылки на сайт.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                    }
                }));
            }
        }
        public RelayCommand About
        {
            get
            {
                return about ?? (about = new RelayCommand(obj =>
                {
                    About about = new About();
                    about.ShowDialog();
                }));
            }
        }
        public RelayCommand Category
        {
            get
            {
                return category ?? (category = new RelayCommand(obj =>
                {
                    CategoryWindow cw = new CategoryWindow(Categories);
                    cw.ShowDialog();
                }));
            }
        }
        public RelayCommand AddIncoming
        {
            get
            {
                return addIncoming ?? (addIncoming = new RelayCommand(obj =>
                {
                    ComboBox comboBox = obj as ComboBox;
                    AddData add = new AddData(Finance.FinansData, MonthBalance, comboBox.Text, "Приход");
                    add.ShowDialog();
                }));
            }
        }
        public RelayCommand AddExpense
        {
            get
            {
                return addExpense ?? (addExpense = new RelayCommand(obj =>
                {
                    ComboBox comboBox = obj as ComboBox;
                    AddData add = new AddData(Finance.FinansData, MonthBalance, comboBox.Text, "Расход");
                    add.ShowDialog();
                }));
            }
        }
        public RelayCommand DiagramIncoming
        {
            get
            {
                return diagramIncoming ?? (diagramIncoming = new RelayCommand(obj =>
                {
                    DataGrid dataGrid = obj as DataGrid;
                    var diagr = new Diagram(dataGrid);
                    diagr.Show();
                }));
            }
        }
        public RelayCommand DiagramExpense
        {
            get
            {
                return diagramExpense ?? (diagramExpense = new RelayCommand(obj =>
                {
                    DataGrid dataGrid = obj as DataGrid;
                    var diagr = new Diagram(dataGrid, false);
                    diagr.Show();
                }));
            }
        }

        public MainViewModel()
        {
            Categories = new CategoryViewModel();
            Finance = new FinanceViewModel();
            MonthBalance = new MonthBalance(115000, 2500000, 1525000, 1090000);
            ListYearsMonths = new List<string>();
            listAll = new ObservableCollection<FinansDayAll>();
            listIncoming = new ObservableCollection<FinansDayTable>();
            listExpense = new ObservableCollection<FinansDayTable>();

            LoadDateApp();
        }

        private void LoadDateApp()
        {
            // создаем необходимые папки
            Directory.CreateDirectory(DirApp);
            Log("Создание необходимых папок", false);
            Directory.CreateDirectory(DirBackup);
            Directory.CreateDirectory(DirUpdate);
            Log(" - завершено", true);

            // Получение текущей даты
            Log("Получение текущей даты", false);
            currentYear = "2020";
            currentMonth = "февраль";
            YearMonth = $"{currentYear} {currentMonth}";
            Log(" - завершено", true);

            // Получения списка временных интервалов
            Log("Получения списка временных интервалов", false);
            ListYearsMonths = MonthYearLoad();
            Log(" - завершено", true);

            // Получения финансовой информации
            Log("Получения финансовой информации", false);
            Finance.FinansLoad();
            var list = FinansMonthLoad(YearMonth);
            GetFinansAll(list);
            GetFinansTable(list, "Приход");
            GetFinansTable(list, "Расход");
            Log(" - завершено", true);

            // Загрузка файла категорий
            Log("Загрузка файла категорий", false);
            Categories.CategoriesProductsLoad(); // тут
            Log(" - завершено", true);

            // завершение работы всех процессов
            Log("Загрузка программы завершена", true);
        }

        /// <summary>
        /// Логирование
        /// </summary>
        /// <param name="text">Cодержимое лога</param>
        /// <param name="isEndLine">Перенос строки</param>
        private void Log(string text, bool isEndLine)
        {
#if LOG
            var file = Path.Combine(DirApp, @"HouseFinances.log");
            if (!File.Exists(file))
            {
                var temp = File.Create(file);
                temp.Close();
            }

            using (StreamWriter sw = new StreamWriter(file, true))
            {
                if (isEndLine)
                    sw.WriteLine(text);
                else
                    sw.Write(text);
            }
#endif
        }

        /// <summary>
        /// Функция получения списка месяц+год в файле XML
        /// </summary>
        /// <returns>Список в формате "год месяц"</returns>
        public List<string> MonthYearLoad()
        {
            return new List<string> { YearMonth };
        }

        /// <summary>
        /// Получения приходов и расходов по датам для таблицы
        /// </summary>
        /// <param name="days">Выборка данных по дням за указанный месяц</param>
        public void GetFinansAll(ObservableCollection<FinansDay> days)
        {
            listAll.Clear();

            if (days == null) return;

            var temp = days.GroupBy(x => x.Day);

            foreach (var day in temp)
            {
                long incoming = 0, expense = 0;

                foreach (var el in day)
                {
                    if (el.Opiration.Type == "Приход")
                        incoming += long.Parse(el.Opiration.Sum);
                    else if (el.Opiration.Type == "Расход")
                        expense += long.Parse(el.Opiration.Sum);
                }

                listAll.Add(new FinansDayAll()
                {
                    Day = day.Key,
                    Incoming = $"{incoming / 100}{CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]}{incoming % 100}",
                    Expense = $"{expense / 100}{CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]}{expense % 100}"
                });
            }
        }

        /// <summary>
        /// Получения приходов или расходов по датам для таблицы
        /// </summary>
        /// <param name="days">Выборка данных по дням за указанный месяц</param>
        /// <param name="type">Тип операции ("Приход" или "Расход")</param>
        public void GetFinansTable(ObservableCollection<FinansDay> days, string type)
        {
            if (type == "Приход")
            {
                listIncoming.Clear();

                if (days != null)
                {
                    foreach (var day in days)
                    {
                        if (day.Opiration.Type == type)
                        {
                            long sum = long.Parse(day.Opiration.Sum);
                            listIncoming.Add(new FinansDayTable()
                            {
                                Day = day.Day,
                                Sum = string.Format("{0}{1}{2}", sum / 100, CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0], sum % 100),
                                Category = day.Opiration.CategoryName,
                                Product = day.Opiration.ProductName,
                                Description = day.Opiration.Description
                            });
                        }
                    }
                }
            }
            else
            {
                listExpense.Clear();

                if (days != null)
                {
                    foreach (var day in days)
                    {
                        if (day.Opiration.Type == type)
                        {
                            long sum = long.Parse(day.Opiration.Sum);
                            listExpense.Add(new FinansDayTable()
                            {
                                Day = day.Day,
                                Sum = string.Format("{0}{1}{2}", sum / 100, CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0], sum % 100),
                                Category = day.Opiration.CategoryName,
                                Product = day.Opiration.ProductName,
                                Description = day.Opiration.Description
                            });
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Получения списка приходов и расходов по датам
        /// </summary>
        /// <param name="data">Дата в формате: "год месяц"</param>
        /// <returns>Списка приходов и расходов по датам</returns>
        public ObservableCollection<FinansDay> FinansMonthLoad(string data)
        {
            var list = new ObservableCollection<FinansDay>();
            string[] yearAndMonth = data.Trim().Split(' ');

            if (Finance.FinansData == null) return list;

            var temp = Finance.FinansData.Years.ToList().Find(x => x.Name == yearAndMonth[0])?.Months?.ToList().Find(y => y.Name == yearAndMonth[1]);
            if (temp != null)
                list = temp.Days;

            return list;
        }
    }
}
