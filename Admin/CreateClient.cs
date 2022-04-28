using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystemApp;

namespace BankSystemApp.Admin
{
    class CreateClient<T1>
    {
        private ClientsCollections clientsCollections;
        private Random random;
        private GroundData groundData;
        private PersonalDataParameters personalDataParameters;

        private T1 _clientObject;

        public CreateClient(T1 _clientObject, int count)
        {
            Client client = null;

            this._clientObject = _clientObject;

            if (_clientObject is Client)
            {
                client = _clientObject as Client;
            }

            clientsCollections = new ClientsCollections();
            random = new Random();
            groundData = new GroundData();
            personalDataParameters = new PersonalDataParameters(4, 6, 8);

            for (int i = 1; i < count; i++)
            {
                int id = i;
                string login = LoginGenerate(client.Login);
                string password = PasswordGenerate(client.Password);

                string name = PersonalDataGenerate(client.Name, 0);
                string surname = PersonalDataGenerate(client.Surname, 1);
                string fathname = PersonalDataGenerate(client.Surname, 2);

                string serialPass = OtherPersonalDataGenerate(client.SerialPass, personalDataParameters.SerialPassLength);
                string numberPass = OtherPersonalDataGenerate(client.NumberPass, personalDataParameters.NumberPassLength);
                string phoneNumber = OtherPersonalDataGenerate(client.PhoneNumber, personalDataParameters.PhoneNumberLength);

                clientsCollections.clients.Add(new Client()
                {
                    Id = id,
                    Login = login,
                    Password = password,
                    Name = name,
                    Surname = surname,
                    FathersName = fathname,
                    SerialPass = serialPass,
                    NumberPass = numberPass,
                    PhoneNumber = phoneNumber,
                });
            }

            JsonBroker(clientsCollections);
        }

        private string LoginGenerate(string login)
        {
            int maxlength = 3;
            int rand = random.Next(0, 6);
            int count = 0;

            string[] parts1 =
            {
                "tys",
                "fis",
                "res",
                "kim",
                "oul",
                "fig",
                "stig",
                "rim",
            };

            login = GeneratePasswordOrLogin(parts1, rand, count, login, maxlength, 6);

            return login;
        }

        private string PasswordGenerate(string password)
        {
            int maxLength = 12;
            int rand = random.Next(0, 20);
            var passwordData = "Q,W,E,R,T,Y,U,I,O,P,A,S,D,F,G,H,J,K,L,Z,X,C,V,B,N,M,1,2,3,4,5,6,7,8,9,0";
            var passwordArray = passwordData.Split(',');

            int passwordLength = 0;

            password = GeneratePasswordOrLogin(passwordArray, rand, passwordLength, password, maxLength, 20);

            return password;
        }

        private string GeneratePasswordOrLogin(string[] array, int rand, int length, string returnedData, int maxLength, int maxDiap)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (rand == i)
                {
                    length += 1;
                    returnedData += array[i];
                    rand = random.Next(0, maxDiap);
                    i = 0;
                }

                else if (length >= maxLength)
                {
                    break;
                }
            }

            return returnedData;
        }

        private string PersonalDataGenerate(string data, int pos)
        {
            int rand = random.Next(0, 8);
            string[][] name = groundData.GetGroundData();

            data = name[pos][rand];

            return data;
        }

        private string OtherPersonalDataGenerate(string data, int maxLength)
        {
            int rand = random.Next(0, 9);

            for (int i = 0; i < maxLength; i++)
            {
                data += rand;
                rand = random.Next(0, 9);
            }

            return data;
        }

        private void JsonBroker(ClientsCollections clients)
        {
            IJsonCreate jsonInteraction = new JsonParse();
            jsonInteraction.SerializableObjectsToJson(clients);
        }

    }
}

