using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace BankSystemApp.Admin
{
    class JsonParse : IJsonCreate
    {
        public void SerializableObjectsToJson(ClientsCollections clients)
        {
            string json = JsonConvert.SerializeObject(clients);

            SaveJsonData(json);
        }

        public void SaveJsonData(string json) => File.WriteAllText(@"ClientsJsonDb.json", json);

        public void DerializableObjectsFromJson()
        {

        }
    }
}
