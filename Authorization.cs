using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using BankSystemApp.Admin;
using Newtonsoft.Json;
using System.IO;

namespace BankSystemApp
{
    class Authorization
    {
        public void SignIn(User user)
        {
            string login = user.GetLogin();
            string password = user.GetPassword();

            CheckCorrectly(login, password);
        }

        protected void CheckCorrectly(string log, string pass)
        {
            GetDataForAuth getDataForAuth = new GetDataForAuth();
            GetData(getDataForAuth, out List<Client> clients);

            foreach (Client item in getDataForAuth)
            {
                if (item.Login == log && item.Password == pass)
                {
                    AccountState accountState = AccountState.Autorized;

                    if(accountState == AccountState.Autorized)
                    {
                        item.AuthorizeStatus = accountState;
                        getDataForAuth.SerializableObjectsToJson(getDataForAuth);
                        break;
                    }
                }

                else { continue; }
            }
        }

        private void GetData(GetDataForAuth getDataForAuth, out List<Client> clients)
        {
            getDataForAuth.DerializableObjectsFromJson();
            clients = getDataForAuth.ReturnedDeserializableData();
        }
    }

    class GetDataForAuth : ClientsCollections, IJsonCreate
    {
        JsonParse jsCreate = new JsonParse();

        public void DerializableObjectsFromJson()
        {
            string json = File.ReadAllText(@"ClientsJsonDb.json");

            var myList = JsonConvert.DeserializeObject<List<Client>>(json);
            clients = myList.ToList<Client>();
        }

        public void SerializableObjectsToJson(ClientsCollections clients)
        {
            string json = JsonConvert.SerializeObject(clients);
            jsCreate.SaveJsonData(json);
        }

        public List<Client> ReturnedDeserializableData()
        {
            return clients;
        }
    }
}
