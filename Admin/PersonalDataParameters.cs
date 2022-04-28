using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemApp.Admin
{
    struct PersonalDataParameters
    {
        public PersonalDataParameters(int SerialPassLength, int NumberPassLength, int PhoneNumberLength)
        {
            this.SerialPassLength = SerialPassLength;
            this.NumberPassLength = NumberPassLength;
            this.PhoneNumberLength = PhoneNumberLength;
        }

        public int SerialPassLength { get; set; }
        public int NumberPassLength { get; set; }
        public int PhoneNumberLength { get; set; }
    }
}
