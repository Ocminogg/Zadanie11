using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_11
{
    class JsonClass
    {
        #region SerializeClientsList
        public void SerializeClientsList(List<Clients> СoncreteClientsList, string Path)
        {            
                                    
            string json = JsonConvert.SerializeObject(СoncreteClientsList);
            
            File.WriteAllText(Path, json);
            
        }
        #endregion
        

        #region DeserializeClientsList
        public List<Clients> DeserializeClientsList( string Path)
        {
            string json = File.ReadAllText(Path);

            List<Clients> list = new List<Clients>();
            list = JsonConvert.DeserializeObject<List<Clients>>(json);

            
            return list;
        }
        #endregion
    }
}
