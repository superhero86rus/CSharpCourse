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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.btnClick.Click += BtnClick_Click1;
        }

        // Дополнительное событие
        private void BtnClick_Click1(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Ты нажал на кнопку!");
        }

        // Основное событие кнопки
        private void BtnClick_Click(object sender, RoutedEventArgs e)
        {
            string result = string.Format("Привет, {0}!", txtName.Text);
            labelResult.Content = result;
        }

        private void BtnClick1_Click(object sender, RoutedEventArgs e)
        {
            long sum = 0;
            for (int i = 1; i <= 1000000000; i++)
                sum += i;

            labelResult.Content = sum.ToString();
        }
    }
}
