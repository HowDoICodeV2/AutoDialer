using System;

namespace AutoDialer
{
    class Program
    {
        public enum details
        {
            companyName,
            phoneNumber,
            phoneType
        }

        private static char[] singleDigitNumbers = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
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































    }
}



// additional commentary: I would like to give 40 lines for each function, then we remove the empty space after the final merges to main