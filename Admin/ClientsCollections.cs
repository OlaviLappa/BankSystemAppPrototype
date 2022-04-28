using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemApp.Admin
{
    class ClientsCollections : IEnumerable
    {
        public List<Client> clients = new List<Client>();

        public IEnumerator GetEnumerator() => clients.GetEnumerator();
    }
}
