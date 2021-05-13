using System;
using System.Threading;

namespace AutoDialer
{
    class Program
    {

        private static char[] singleDigitNumbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static void Main(string[] args)
        { 

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

            Print(phoneList);

            while (true)
            {
                for (int i = 0; i < phoneList.Length; i++)
                {
                    ConsoleKeyInfo keypress = new ConsoleKeyInfo();
                    Console.WriteLine();
                    Thread.Sleep(100);
                    Console.WriteLine("Welcome to the Auto Dialer program");

                    while (keypress.Key != ConsoleKey.Y || keypress.Key != ConsoleKey.N)
                    {
                        Console.WriteLine("Want to add new numbers, (y)es or (n)o?");
                        //string numbertype = Console.ReadLine();
                        keypress = Console.ReadKey();
                        if (keypress.Key == ConsoleKey.Y)
                        {
                            Console.Clear();
                            string companyName = CompanyName();
                            string phoneNumber = FullNumber();
                            bool numberType = NumberType();
                            if (!numberType)
                            { phoneList[i] = new CellPhone(companyName, phoneNumber, "2"); }
                            else
                            { phoneList[i] = new HomePhone(companyName, phoneNumber, "1"); }
                        }
                        else if (keypress.Key == ConsoleKey.N)
                        {
                            Console.Clear();
                            Print(phoneList);
                            Console.WriteLine("Press any key to exit.");
                            Console.ReadKey();
                            return;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter the character Y or the character N to proceed to scamming.");
                        }
                    }
                    Print(phoneList);
                }
                Console.WriteLine();
            }
        }
       
        public static string CompanyName()
        {
            string companyName = "";

            Console.WriteLine("Please enter the name of the business you wish to dial: ");
            while (companyName.Length == 0)
            { companyName = Console.ReadLine(); }

            return companyName;
        }
        public static string FullNumber()
        {
            string fullNumber = "";

            while (StringtoNumber(fullNumber).Length != 10)
            {
                Console.WriteLine("Please enter the number you wish to dial: ");
                fullNumber = Console.ReadLine();
            }
            fullNumber = NumberBuilder(fullNumber);

            return fullNumber;
        }
        public static bool NumberType()
        {
            //string numberType = "0";

            ConsoleKeyInfo keypress = new ConsoleKeyInfo();
            while (keypress.Key != ConsoleKey.D1 || keypress.Key != ConsoleKey.D2)
            {
                Console.WriteLine("Is this number a Land Line (1) or a Cell Phone (2): ");
                keypress = Console.ReadKey();
                Console.WriteLine();

                //numberType = Console.ReadLine();
                if (keypress.Key == ConsoleKey.D1)
                { return true; }
                else if (keypress.Key == ConsoleKey.D2)
                { return false; }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Hey... There are two options here... pick (1) for Land Line or (2) for Cell Phone.");
                }
            }
            return false;
        }

        // print function
        public static void Print(Phone[] phoneList)
        {
            for (int i = 0; i < phoneList.Length; i++)
            {
                if (!(phoneList[i] == null))
                { Console.WriteLine(phoneList[i].Dial()); }
                phoneList[i] = null;
            }
        }

        // interperet input
        public static string NumberBuilder(string phoneNumber)
        {
            phoneNumber = StringtoNumber(phoneNumber);
            string areaCode = "(" + phoneNumber.Substring(0, 3) + ")";
            //                                   \\
            string threeDigitSet = phoneNumber.Substring(3, 3);
            //                                  \\
            string fourDigitSet = phoneNumber.Substring(6, 4);
            return areaCode + " " + threeDigitSet + "-" + fourDigitSet;
        }

        private static string StringtoNumber(string phoneNumber)
        {
            int earliestNum;
            string builtNumber = "";
            while(phoneNumber.Length != 0)
            {

                earliestNum = phoneNumber.IndexOfAny(singleDigitNumbers);
                if(earliestNum == -1)
                {
                    return builtNumber;
                }
                phoneNumber = phoneNumber.Remove(0, earliestNum);
                builtNumber = builtNumber + phoneNumber.Substring(0, 1);
                phoneNumber = phoneNumber.Remove(0, 1);
            }
            return builtNumber;
        }

  }
}