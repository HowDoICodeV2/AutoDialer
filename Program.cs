using System;

namespace AutoDialer
{
    class Program
    {

        private static char[] singleDigitNumbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
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
                        goto Continue;
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

            Continue:
                string companyName;
                string numberType = "";
                string fullNumber = "";


                Console.WriteLine("Welcome to the Auto scam-Dialer program");
                Console.WriteLine("Please enter the name of the business you wish to dial: ");
                companyName = Console.ReadLine();
                while (fullNumber.Length < 10)
                {
                    Console.WriteLine("Please enter the number you wish to dial: ");
                    fullNumber = Console.ReadLine();
                    
                }
                    fullNumber = numberBuilder(fullNumber);
                while (keypress.Key != ConsoleKey.D1 || keypress.Key != ConsoleKey.D2)
                {
                    Console.WriteLine("Is this number a Land Line (1) or a Cell Phone (2): ");
                    keypress = Console.ReadKey();

                    numberType = Console.ReadLine();
                    if (keypress.Key == ConsoleKey.D1)
                    {
                        phoneList[0] = new HomePhone(companyName, fullNumber, numberType);
                        break;
                    }
                    else if (keypress.Key == ConsoleKey.D2)
                    {
                        phoneList[0] = new CellPhone(companyName, fullNumber, numberType);
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Hey... There are two options here... pick (1) for Land Line or (2) for Cell Phone.");
                    }
                }
            }
            Print(phoneList);
            goto Restart;

            string companyName;
            string numberType;
            string fullNumber;

            ConsoleKeyInfo keypress = Console.ReadKey();
            Console.WriteLine("Welcome to the Auto Dialer program");
            Console.WriteLine("Please enter the name of the business you wish to dial: ");
            companyName = Console.ReadLine();
            Console.WriteLine("Please enter the number you wish to dial: ");
            fullNumber = Console.ReadLine();
            while (keypress.Key != ConsoleKey.D1 || keypress.Key != ConsoleKey.D2)
            {
                Console.WriteLine("Is this number a Land Line (1) or a Cell Phone (2): ");
                keypress = Console.ReadKey();

                numberType = Console.ReadLine();
                if (keypress.Key == ConsoleKey.D1)
                {
                    phoneList[0] = new HomePhone(companyName, fullNumber, numberType);
                    break;
                }
                else if (keypress.Key == ConsoleKey.D2)
                {
                    phoneList[0] = new CellPhone(companyName, fullNumber, numberType);
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Hey... There are two options here... pick (1) for Land Line or (2) for Cell Phone.");
                }
            }
            











        

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

            int earliestNum = FindFirstNumber(phoneNumber);
            phoneNumber.Trim();
            string areaCode = "(" + phoneNumber.Substring(earliestNum, 3) + ")";
            phoneNumber = phoneNumber.Remove(0, earliestNum + 3);
            //                                   \\
            earliestNum = FindFirstNumber(phoneNumber);
            string threeDigitSet = phoneNumber.Substring(earliestNum, 3);
            phoneNumber = phoneNumber.Remove(0, earliestNum + 3);
            //                                  \\
            earliestNum = FindFirstNumber(phoneNumber);
            string fourDigitSet = phoneNumber.Substring(earliestNum, 4);
            return areaCode + " " + threeDigitSet + "-" + fourDigitSet;
        }
        private static int FindFirstNumber(string input)
        {
            int earliestNum = input.IndexOfAny(singleDigitNumbers);
            return earliestNum;
        }
        private static string StringtoNumber(string phoneNumber)
        {
            int earliestNum;
            string builtNumber = "";
            for(int i = 0; i < phoneNumber.Length; i++)
            {
                earliestNum = FindFirstNumber(phoneNumber);
                phoneNumber = phoneNumber.Remove(0, earliestNum);
                builtNumber = builtNumber + phoneNumber.Substring(earliestNum, 1);
            }
            return builtNumber;
        }































    }
}



// additional commentary: I would like to give 40 lines for each function, then we remove the empty space after the final merges to main