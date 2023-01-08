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
            lsClients.Items.Clear();
            List<Clients> list = new List<Clients>();

            for (uint i = 1; i <= 5; i++)
            {
                list.Add(new Clients($"Фамилия_{i}", $"Имя_{i}", $"Отчество_{i}", $"Телефон_{i}", $"Паспорт_{i}"));
            }

            JsonClass jsonClass = new JsonClass();

            jsonClass.SerializeClientsList(list, "_listWorker.json");
            list = jsonClass.DeserializeClientsList("_listWorker.json");
                        
            //lsClients.ItemsSource = list;
            
            
            foreach (var item in list)
            {
                if (item.Pasport == null)
                    lsClients.Items.Add(item);
                if (item.Pasport != null)
                {
                    item.pasport = "******";                    
                    lsClients.Items.Add(item);
                }                
            }


        }

        private void Konsultant_Save_Clients_Click(object sender, RoutedEventArgs e)
        {
            //List<Clients> list = new List<Clients>();
            //list = (List<Clients>)lsClients.ItemsSource;

            //JsonClass jsonClass = new JsonClass();
            //jsonClass.SerializeClientsList(list, "_listWorker.json");

            /////////////////////////////////////////////////////////////////////

            List<Clients> listOld = new List<Clients>();
            List<Clients> listChange = new List<Clients>();
            listChange = (List<Clients>)lsClients.ItemsSource;
            JsonClass jsonClass = new JsonClass();
            listOld = jsonClass.DeserializeClientsList("_listWorker.json");
            
            int length = listOld.Count;
            for (int i = 0; i < length; i++)
            {
                listOld[i].Phone = listChange[i].Phone;
                
            }
            jsonClass.SerializeClientsList(listOld, "_listWorker.json");
        }

        private void Back_Main_Menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
