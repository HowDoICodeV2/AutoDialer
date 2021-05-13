using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDialer
{
    public class Phone
    {
        protected string _phoneNumber;
        protected string _companyName;
        protected string _phoneType;



        public Phone(string companyName, string phoneNumber, string phoneType)
        {
            _phoneNumber    =  phoneNumber;
            _companyName    =  companyName;
            _phoneType      =  phoneType;
        }

        public virtual string Dial()
        {
            return _companyName + " is being dialed using " + _phoneNumber;
        }
    }
}
