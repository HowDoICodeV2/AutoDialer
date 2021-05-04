using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDialer
{
    class Phone
    {
        private string _phoneNumber;


        public Phone(string phoneNumber)
        {
            _phoneNumber = phoneNumber;
        }

        public string Dial(string number)
        {
            return number;
        }
    }
}
