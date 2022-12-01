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
    /// Логика взаимодействия для KonsultantWindow.xaml
    /// </summary>
    public partial class KonsultantWindow : Window
    {
        public KonsultantWindow()
        {
            InitializeComponent();
        }

        private void Konsultant_Show_Clients_Click(object sender, RoutedEventArgs e)
        {

            //TextBox.Text = "Hello";

            List<Clients> list = new List<Clients>();

            for (uint i = 1; i <= 5; i++)
            {
                list.Add(new Clients($"Фамилия_{i}", $"Имя_{i}", $"Отчество_{i}", $"Телефон_{i}", $"Паспорт_{i}"));
            }

            JsonClass jsonClass = new JsonClass();

            jsonClass.SerializeClientsList(list, "_listWorker.json");
            list = jsonClass.DeserializeClientsList("_listWorker.json");

            Console.WriteLine();
            foreach (var item in list)
            {
                TextBox.Text += item.PrintAll() + "\n";
            }


        }

        
    }
}
