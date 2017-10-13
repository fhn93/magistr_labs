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

namespace lab5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PersonsList.ItemsSource = new List<string> { "John", "Mary", "Andy" };
            ColorList.ItemsSource = new List<string> { "Red", "Green", "Yellow" };
            SizeList.ItemsSource = new List<string> { "10", "20", "30" };         
        }
           
    }
}
