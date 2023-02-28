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
            clientsGrid.Items.Clear();
        }

        private void Konsultant_Show_Clients_Click(object sender, RoutedEventArgs e)
        {

            List<Clients> list = new List<Clients>();

            JsonClass jsonClass = new JsonClass();


            list = jsonClass.DeserializeClientsList("_listWorker.json");

            clientsGrid.ItemsSource = list;
        }

        private void Konsultant_Save_Clients_Click(object sender, RoutedEventArgs e)
        {

            List<Clients> listOld = new List<Clients>();

            var listChange = clientsGrid.ItemsSource as List<Clients>;

            JsonClass jsonClass = new JsonClass();
            listOld = jsonClass.DeserializeClientsList("_listWorker.json");
            string dataCH = "";
            string typeCH = "";
            int length = listOld.Count;
            for (int i = 0; i < length; i++)
            {
                dataCH = "";
                typeCH = "";
                
                if (listOld[i].Familiya != listChange[i].Familiya)
                {
                    dataCH += "Familiya";
                    typeCH += "Familiya";
                }
                if (listOld[i].Name != listChange[i].Name)
                {
                    dataCH += " Name";
                    typeCH += " Name";
                }
                if (listOld[i].Othestvo != listChange[i].Othestvo)
                {
                    dataCH += " Othestvo";
                    typeCH += " Othestvo";
                }
                if (listOld[i].Pasport != listChange[i].Pasport & listChange[i].Pasport != "******")
                {
                    dataCH += " Pasport";
                    typeCH += " Pasport";
                }
                if (listOld[i].Phone != listChange[i].Phone)
                {
                    listOld[i].Phone = listChange[i].Phone;
                    dataCH += " Phone";
                    typeCH += " Phone";
                }

                if (dataCH != "" | typeCH != "")
                {
                    listOld[i].Time = DateTime.Now.ToString();
                    listOld[i].DataChange = dataCH;
                    listOld[i].TypeChange = typeCH;
                    listOld[i].WhoChange = "Менеджер";
                }

            }
            jsonClass.SerializeClientsList(listOld, "_listWorker.json");
        }

        private void Back_Main_Menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }


        //Генерирует новый json файл и отображает его
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            List<Clients> list = new List<Clients>();

            for (uint i = 1; i <= 5; i++)
            {
                list.Add(new Clients($"Фамилия_{i}", $"Имя_{i}", $"Отчество_{i}", $"Телефон_{i}", $"Паспорт_{i}"));
            }

            JsonClass jsonClass = new JsonClass();

            jsonClass.SerializeClientsList(list, "_listWorker.json");
            list = jsonClass.DeserializeClientsList("_listWorker.json");

            
            clientsGrid.ItemsSource = list;
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
             if (TextBox_Familiya.Text != "" & TextBox_Name.Text != "" & TextBox_Othestvo.Text != "" & TextBox_Pasport.Text != "" & TextBox_Phone.Text != "")
             {
                List<Clients> list = new List<Clients>();
                JsonClass jsonClass = new JsonClass();
                list = jsonClass.DeserializeClientsList("_listWorker.json");
                list.Add(new Clients(DateTime.Now.ToString(),"Добвален новый клиент","Добавление","Менеджер",$"{TextBox_Familiya.Text}", $"{TextBox_Name.Text}", $"{TextBox_Othestvo.Text}", $"{TextBox_Phone.Text}", $"{TextBox_Pasport.Text}"));
                
                jsonClass.SerializeClientsList(list, "_listWorker.json");
                

                MessageBox.Show("Клиент добвален и сохранен! Чтобы отобразить изменения нажмите кнопку Показать клиентов.");
                TextBox_Familiya.Text = "";
                TextBox_Name.Text = "";
                TextBox_Othestvo.Text = "";
                TextBox_Pasport.Text = "";
                TextBox_Phone.Text = "";
             }
             else
                MessageBox.Show("Заполните все поля для добваления");
        }

        private void DelClient_Click_1(object sender, RoutedEventArgs e)
        {            
            var listChange = clientsGrid.ItemsSource as List<Clients>;

            var index = clientsGrid.SelectedIndex;
            if (index != -1) 
            {
                if (MessageBox.Show("Клиент будет удален! Вы уверены что хотите удалить? " + index.ToString(), "", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {                    
                    List<Clients> list = new List<Clients>();

                    JsonClass jsonClass = new JsonClass();

                    listChange.RemoveAt(index);
                    jsonClass.SerializeClientsList(listChange, "_listWorker.json");

                    list = jsonClass.DeserializeClientsList("_listWorker.json");

                    clientsGrid.ItemsSource = list;
                }                    
            }            
        }
    }
}
