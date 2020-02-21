using System.Reflection;
using System.Windows;

namespace HouseFinances
{
    public class AboutViewModel
    {
        private readonly Assembly assembly;
        private RelayCommand close;

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

        public AboutViewModel()
        {
            assembly = Assembly.GetExecutingAssembly();
        }

        public string Version => assembly.GetName().Version.ToString();

        public string Copyright
        {
            get
            {
                object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string Company
        {
            get
            {
                object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        public string Product
        {
            get
            {
                object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }
    }
}
