using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace zadanie_11
{
    public class Clients : INotifyPropertyChanged
    {
        /// <summary>
        /// Создание клиента
        /// </summary>
        /// <param name="Familiya">Фамилия</param>
        /// <param name="Name">Имя</param>
        /// <param name="Othestvo">Отчество</param>
        ///  <param name="Phone">Номер телефона</param>
        ///   <param name="Pasport">Серия, номер паспорта</param>
        public Clients(string Familiya, string Name, string Othestvo, string Phone, string Pasport)
        {
            this.familiya = Familiya;
            this.name = Name;
            this.othestvo = Othestvo;
            this.phone = Phone;
            this.pasport = Pasport;
        }
        public Clients(string Time, string DataChange, string TypeChange, string WhoChange, string Familiya, string Name, string Othestvo, string Phone, string Pasport)
        {
            this.time = Time;
            this.dataChange = DataChange;
            this.typeChage = TypeChange;
            this.whoChange = WhoChange;

            this.familiya = Familiya;
            this.name = Name;
            this.othestvo = Othestvo;
            this.phone = Phone;
            this.pasport = Pasport;
        }

        public string familiya; // Поле Фамилия
        public string name;  // Поле Имя
        public string othestvo; // Поле Отчество
        public string phone; // Поле Номер телефона
        public string pasport; // Поле Серия, номер паспорта

        public string time; // дата и время изменения записи
        public string dataChange; // какие данные изменены
        public string typeChage; // тип изменений
        public string whoChange; // кто изменил данные

        public Clients() { }

        #region Методы

        public string PrintAll()
        {
            return $"{this.familiya,15} {this.name,15} {this.othestvo,15} {this.phone,15} {this.pasport,10}";
        }

        #endregion

        /// <summary>
        /// дата и время изменения записи
        /// </summary>
        public string Time { get { return this.time; } set { time = value; OnPropertyChanged("Time"); } }

        /// <summary>
        /// какие данные изменены
        /// </summary>
        public string DataChange { get { return this.dataChange; } set { dataChange = value; OnPropertyChanged("DataChange"); } }

        /// <summary>
        /// тип изменений
        /// </summary>
        public string TypeChange { get { return this.typeChage; } set { typeChage = value; OnPropertyChanged("TypeChange"); } }

        /// <summary>
        /// кто изменил данные
        /// </summary>
        public string WhoChange { get { return this.whoChange; } set { whoChange = value; OnPropertyChanged("WhoChange"); } }


        /// <summary>
        /// Фамилия
        /// </summary>
        public string Familiya { get { return this.familiya; } set { familiya = value; OnPropertyChanged("Familiya"); } }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get { return this.name; } set { name = value; OnPropertyChanged("Name"); } }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Othestvo { get { return this.othestvo; } set { othestvo = value; OnPropertyChanged("Othestvo"); } }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get { return this.phone; } set { phone = value; OnPropertyChanged("Phone"); } }

        /// <summary>
        /// Паспорт
        /// </summary>
        public string Pasport { get { return this.pasport; } set { pasport = value; OnPropertyChanged("Pasport"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
                //this.Time = DateTime.Now.ToString();                
            }
                
        }
    }
}
