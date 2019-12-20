using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace WPF_INotifyChange
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Calculate : INotifyPropertyChanged
    {
        private string num1;
        private string num2;
        private string sum;
        private string difference;
        private string product;
        private string quotient;

        private void NotifyXAndUpdateAll(string x)
        {
            OnPropertyChanged(x);
            OnPropertyChanged("Sum");
            OnPropertyChanged("Difference");
            OnPropertyChanged("Product");
            OnPropertyChanged("Quotient");
        }

        public string Num1
        {
            get { return num1; }
            set
            {
                int number;
                bool res = int.TryParse(value, out number);
                if (res)
                {
                    num1 = value;
                }
                NotifyXAndUpdateAll("Num1");
            }
        }
        public string Num2
        {
            get { return num2; }
            set
            {
                int number;
                bool res = int.TryParse(value, out number);
                if (res)
                {
                    num2 = value;
                }
                NotifyXAndUpdateAll("Num2");
            }
        }
        public string Sum
        {
            get
            {
                return (int.Parse(Num1) + int.Parse(Num2)).ToString();
            }
            set
            {
                sum = (int.Parse(Num1) + int.Parse(Num2)).ToString();
                OnPropertyChanged("Sum");
            }
        }

        public string Difference
        {
            get
            {
                return (int.Parse(Num1) - int.Parse(Num2)).ToString();
            }
            set
            {
                difference = (int.Parse(Num1) - int.Parse(Num2)).ToString();
                OnPropertyChanged("Difference");
            }
        }
        public string Product
        {
            get
            {
                return (int.Parse(Num1) * int.Parse(Num2)).ToString();
            }
            set
            {
                product = (int.Parse(Num1) * int.Parse(Num2)).ToString();
                OnPropertyChanged("Product");
            }
        }
        public string Quotient
        {
            get
            {
                return (double.Parse(Num1) / double.Parse(Num2)).ToString();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
    public partial class MainWindow : Window
    {
        public Calculate SumObject { set; get; }
        public MainWindow()
        {
            InitializeComponent();
            SumObject = new Calculate { Num1 = "1", Num2 = "2" };
            this.DataContext = SumObject;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
