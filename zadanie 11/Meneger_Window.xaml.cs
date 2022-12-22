using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace zadanie_11
{
    /// <summary>
    /// Логика взаимодействия для Meneger_Window.xaml
    /// </summary>
    public partial class Meneger_Window : Window
    {
        public Meneger_Window()
        {
            InitializeComponent();
        }

                

        private void Show_Clients_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Clear();

            List<Clients> list = new List<Clients>();

            for (uint i = 1; i <= 5; i++)
            {
                list.Add(new Clients($"Фамилия_{i}", $"Имя_{i}", $"Отчество_{i}", $"Телефон_{i}", $"Паспорт_{i}"));
            }

            JsonClass jsonClass = new JsonClass();


            list = jsonClass.DeserializeClientsList("_listWorker.json");

            Console.WriteLine();
            foreach (var item in list)
            {
                TextBox.Text += item.PrintAll() + "\n";
            }
        }

        private void Save_Clients_Click(object sender, RoutedEventArgs e)
        {
            List<Clients> list = new List<Clients>();
            JsonClass jsonClass = new JsonClass();
            jsonClass.SerializeClientsList(list, "_listWorker.json");
        }

        private void Add_Clients_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Main_Menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
