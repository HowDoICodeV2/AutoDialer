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
        private string _companyName;
        private string _phoneType;



        public Phone(string phoneNumber, string companyName, string phoneType)
        {
            _phoneNumber    =  phoneNumber;
            _companyName    =  companyName;
            _phoneType      =  phoneType;
        }

        public string Dial(string number)
        {
            return _companyName + " is being dialed using" + number;
        }
    }
}
