﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDialer
{
    public class CellPhone : Phone
    {
        public CellPhone(string phoneNumber, string companyName, string phoneType) : base(phoneNumber, companyName, phoneType)
        {

        }
        public override string Dial(string number)
        {
            return "1+" + base.Dial(number);
        }
    }
}
