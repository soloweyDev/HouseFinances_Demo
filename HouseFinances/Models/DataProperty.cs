using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace HouseFinances
{
    public class DataProperty : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        /// <summary>
        /// Функция перевода числового значения в название месяца.
        /// </summary>
        public static string MonthIntToString(int Month)
        {
            switch (Month)
            {
                case 1:
                    return "январь";
                case 2:
                    return "февраль";
                case 3:
                    return "март";
                case 4:
                    return "апрель";
                case 5:
                    return "май";
                case 6:
                    return "июнь";
                case 7:
                    return "июль";
                case 8:
                    return "август";
                case 9:
                    return "сентябрь";
                case 10:
                    return "октябрь";
                case 11:
                    return "ноябрь";
                case 12:
                    return "декабрь";
                default:
                    return "";
            }
        }

        public static string LongToString(long sum)
        {
            return string.Format("{0}{1}{2}", sum / 100, CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0], sum % 100);
        }

        public static long StringToLong(string sum)
        {
            return (long)(double.Parse(sum, NumberStyles.Number) * 100);
        }

    }
}
