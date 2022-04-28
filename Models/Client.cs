using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemApp
{
    class Client
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FathersName { get; set; }
        public string SerialPass { get; set; }
        public string NumberPass { get; set; }
        public string PhoneNumber { get; set; }
        public AccountState AuthorizeStatus { get; set; }
    }
}
