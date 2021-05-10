using System;

namespace AutoDialer
{
    class Program
    {


       static void Main(string[] args)
        { // empty space is to prevent merge conflicts on the same line
            Phone[] phoneList = new Phone[10];
            phoneList[0] = new HomePhone("CompuTest", "(303) 985-5060", "1");
            phoneList[1] = new CellPhone("Curtis Manufacturing", "(603) 532-4123", "2");
            phoneList[2] = new HomePhone("Data Functions", "(800) 876-2524", "1");
            phoneList[3] = new HomePhone("Donnay Repair", "(708) 397-3330", "1");
            phoneList[4] = new HomePhone("ErgoNomic Inc", "(360) 434-3894", "1");
            phoneList[5] = new HomePhone("ErgoSource", "(800) 969-4374", "1");
            phoneList[6] = new CellPhone("Fox Bay Industries", "(800) 874-8527", "2");
            phoneList[7] = new CellPhone("Glare-Guard", "(800) 545-6254", "2");
            phoneList[8] = new CellPhone("Hazard Comm Specialists", "(407)783-6641", "2");
            phoneList[9] = new CellPhone("Komfort Support", "(714) 472-4409", "2");


            // need explanation for user here
            for (int i = 0; i < phoneList.Length; i++)
            { 
                Print(phoneList[i]);
                phoneList[i] = null;
            }


            string companyName;
            string areaCode;
            string phoneNumber;
            string numberType;
            string fullNumber;
            Console.WriteLine("Welcome to the Auto Dialer program");
            Console.WriteLine("Please enter the name of the business you wish to dial: ");
            companyName = Console.ReadLine();
            Console.WriteLine("Please enter the area code for the number you wish to dial: ");
            areaCode = Console.ReadLine();
            Console.WriteLine("Please enter the number you wish to dial like this 'XXX-XXXX': ");
            phoneNumber = Console.ReadLine();
            Console.WriteLine("Is this number a Land Line (1) or a Cell Phone (2): ");
            numberType = Console.ReadLine();
            fullNumber = "(" + areaCode + ") " + phoneNumber;
            if (numberType.Equals("1"))
            {
                phoneList[0] = new HomePhone(companyName, fullNumber, numberType);
            }
            else
            {
                phoneList[0] = new CellPhone(companyName, fullNumber, numberType);
            }
            



















        }
        // print function
        public static void Print(Phone phone)
        {
                Console.WriteLine(phone.Dial());
        }

































    }
}



// additional commentary: I would like to give 40 lines for each function, then we remove the empty space after the final merges to main