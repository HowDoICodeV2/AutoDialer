using System;

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

        Restart:
            for (int i = 0; i < phoneList.Length; i++)
            {
                ConsoleKeyInfo keypress = Console.ReadKey();

                while (keypress.Key != ConsoleKey.Y || keypress.Key != ConsoleKey.N)
                {

                    Console.WriteLine("Want to add new numbers, (y)es or (n)o?");
                    //string numbertype = Console.ReadLine();
                    keypress = Console.ReadKey();
                    if (keypress.Key == ConsoleKey.Y)
                    {
                        Console.Clear();
                         // enter name of proper function
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


            }
            Print(phoneList);
            goto Restart;

            











        

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
        public static string numberBuilder(string phoneNumber)
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
























                //        while (StringtoNumber(fullNumber).Length != 10)
                //{
                //    Console.WriteLine("Please enter the number you wish to dial: ");
                //    fullNumber = Console.ReadLine();
                    
                //}






}
}



// additional commentary: I would like to give 40 lines for each function, then we remove the empty space after the final merges to main