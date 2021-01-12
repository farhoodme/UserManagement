using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UserManagement.Utilities
{
    public static class UserTCKN
    {
        /// <summary>
        /// Validate the User TCKN 
        /// </summary>
        /// <param name="TCKNCode">Input TCKN Code</param>
        /// <returns>
        /// return <c>true</c> if input is a valid TCKN code and return <c>false</c> if input is not valid code
        /// </returns>
        public static bool IsValidCode(string TCKNCode)
        {
            //Check the code in null or empty
            if (String.IsNullOrEmpty(TCKNCode))
                throw new Exception("Please enter the TCKN code");

            //Check if the code is in length 11 and all are digits and first digit not zero
            var isValid = new Regex("^((?!(0))[0-9]{11})$");
            if (!isValid.IsMatch(TCKNCode))
                throw new Exception("Please enter a valid code");


            //Convert valid input string to char array
            var charArray = TCKNCode.ToCharArray();
            int[] digits = new int[11];
            for (int i = 0; i < 11; i++)
            {
                digits[i] = int.Parse(charArray[i].ToString());
            }


            //Check the 10th and 11th digits acording to TCKN algorithm
            int d10 = (((digits[0] + digits[2] + digits[4] + digits[6] + digits[8]) * 7) - (digits[1] + digits[3] + digits[5] + digits[7])) % 10;
            int d11 = (digits[0] + digits[1] + digits[2] + digits[3] + digits[4] + digits[5] + digits[6] + digits[7] + digits[8] + digits[9]) % 10;

            if (digits[9] != d10 || digits[10] != d11)
                return false;

            return true;
        }

        /// <summary>
        /// Generate random TCKN code
        /// </summary>
        /// <returns>
        /// return a valid random TCKN code is string format
        /// </returns>
        public static string GenerateCode()
        {
            Random random = new Random();
            var digits = new int[11];

            //Generate a none zero random digit for first item
            digits[0] = random.Next(1, 10);

            //Generate a random digit for second to ninth
            for (int i = 1; i < 9; i++)
            {
                digits[i] = random.Next(0, 10);
            }

            //Generate 10th and 11th digits acording to the TCKN algorithm
            digits[9] = (((digits[0] + digits[2] + digits[4] + digits[6] + digits[8]) * 7) - (digits[1] + digits[3] + digits[5] + digits[7])) % 10;
            digits[10] = (digits[0] + digits[1] + digits[2] + digits[3] + digits[4] + digits[5] + digits[6] + digits[7] + digits[8] + digits[9]) % 10;

            string TCKN = "";

            //Convert array to readable string
            for (int i = 0; i < 11; i++)
            {
                TCKN += digits[i].ToString();
            }

            return TCKN;
        }
    }
}
