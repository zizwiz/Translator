using System;
using System.Linq;
using System.Text;

namespace ConvertAll
{
    public partial class convert
    {

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //// Convert Hex String to Byte array
        /// <summary> Convert a string of hex digits (ex: E4 CA B2) to a byte array. </summary>
        /// <param name="s"> The string containing the hex digits (with or without spaces). </param>
        /// <returns> Returns an array of bytes. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static byte[] HexStringToByteArray(string s)
        {

            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;

        }

        /////////////////////////////////////////////////////////////////////////////////////////////
        ///   Convert Byte Array to Hex String 
        /// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
        /// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
        /// <returns> Returns a well formatted string of hex digits with spacing. </returns>
        /////////////////////////////////////////////////////////////////////////////////////////////

        public static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
        }


        //////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        ////                        Convert ASCII string to Hex String
        /// </summary>
        //////////////////////////////////////////////////////////////////////////////////////////

        public static string ConvertStringToHex(string asciiString)
        {
            string hex = "";
            foreach (char c in asciiString)
            {
                int tmp = c;
                hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
            }
            return hex;
        }


        //////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        ////                        Convert Hex String to ASCII string 
        /// </summary>
        //////////////////////////////////////////////////////////////////////////////////////////

        public static string ConvertHexToString(string HexValue)
        {
            string StrValue = "";
            while (HexValue.Length > 0)
            {
                StrValue += System.Convert.ToChar(System.Convert.ToUInt32(HexValue.Substring(0, 2), 16)).ToString();
                HexValue = HexValue.Substring(2, HexValue.Length - 2);
            }
            return StrValue;

            /*  if (HexValue == null)
                  throw new ArgumentNullException("hexString");
              if (HexValue.Length % 2 != 0)
                  throw new ArgumentException("hexString must have an even length", "hexString");
              var bytes = new byte[HexValue.Length / 2];
              for (int i = 0; i < bytes.Length; i++)
              {
                  string currentHex = HexValue.Substring(i * 2, 2);
                  bytes[i] = Convert.ToByte(currentHex, 16);
              }

              return Encoding.ASCII.GetString(bytes);*/

        }

        //////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        ////                        Convert Unicode to ASCII string 
        ////                convert from two byte unicode [page number, char on page].
        /// </summary>
        //////////////////////////////////////////////////////////////////////////////////////////


        public static string ConvertFromUnicode(string str)

        {
            char c = ' ';
            string rtstr = "";

            for (int i = 0; i < str.Length; i += 4)
            {
                string str1 = str.Substring(i, 4);
                c = (char)Int16.Parse(str1, System.Globalization.NumberStyles.HexNumber);
                rtstr += c;
            }
            return rtstr;

        }

        //////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        ////                        Convert ASCII String to Unicode 
        ////                convert from two byte unicode [page number, char on page].
        /// </summary>
        //////////////////////////////////////////////////////////////////////////////////////////

        public static string ConverttoUnicode(string str)
        {

            char c = ' ';

            return ((int)c).ToString("X4");
        }

        //////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        ////                        Convert binary string to byte array 
        ////                convert from two byte unicode [page number, char on page].
        /// </summary>
        //////////////////////////////////////////////////////////////////////////////////////////
        public static byte[] BinaryStringToByteArray(string binaryStr)
        {
            /* int numOfBytes = input.Length/6;
             byte[] bytes = new byte[numOfBytes];
             for (int i = 0; i < numOfBytes; ++i)
             {
                 bytes[i] = Convert.ToByte(input.Substring(6*i, 6), 2);
             }*/

            var byteArray = Enumerable.Range(0, int.MaxValue / 6)
                .Select(i => i * 6)
                .TakeWhile(i => i < binaryStr.Length)
                .Select(i => binaryStr.Substring(i, 6))
                .Select(s => Convert.ToByte(s, 2))
                .ToArray();

            return byteArray;
        }

        //////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        ////                        Convert ASCII String to Unicode 
        ////                convert from two byte unicode [page number, char on page].
        /// </summary>
        //////////////////////////////////////////////////////////////////////////////////////////

        public static string ConvertStringToUnicode(char[] characters, int end_null)

        {
            string rtstr = "";

            for (int i = 0; i < characters.Length; i += 1)
            {
                rtstr += ((int)characters[i]).ToString("X4");
            }

            if (end_null == 1)
            {
                return rtstr + "0000"; //NULL terminated strings
            }
            else
            {
                return rtstr;
            }


        }

        //////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Receives string and returns the string with its letters reversed.
        /// </summary>
        /// //////////////////////////////////////////////////////////////////////////////////////

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        //////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Receives Binary string and returns the string with its letters reversed.
        /// </summary>
        /// //////////////////////////////////////////////////////////////////////////////////////

        public static string ReverseBinaryString(string bin_data)
        {
            string[] bytes = new string[bin_data.Length];

            for (int i = 0; i < bin_data.Length; i = i + 2)
            {
                bytes[i] = bin_data.Substring(i, 2);
            }
            Array.Reverse(bytes, 0, bytes.Length);
            return string.Join("", bytes);
        }

        //////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Convert byte array to ASCII string.
        /// </summary>
        /// //////////////////////////////////////////////////////////////////////////////////////

        public static string ConvertByteArraytoString(byte[] data)
        {
            char[] characters = data.Select(b => (char)b).ToArray();
            return new string(characters);
        }

       

        //////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Convert string array to ASCII string.
        /// </summary>
        /// //////////////////////////////////////////////////////////////////////////////////////

        static string ConvertStringArrayToString(string[] array)
        {
            // Concatenate all the elements into a StringBuilder.
            StringBuilder builder = new StringBuilder(); foreach (string value in array) { builder.Append(value); builder.Append('.'); }
            return builder.ToString();
        }

        //////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Remove non numeric from string.
        /// </summary>
        /// //////////////////////////////////////////////////////////////////////////////////////

        private static string GetNumbers(string input)
        {
            //return new string(input.Where(c => char.IsDigit(c)).ToArray());

            // int lastDigit = input.LastIndexOf(input.Last(char.IsDigit));

            return input.Substring(0, (input.LastIndexOf(input.Last(char.IsDigit))) + 1);
        }

        //////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Convert ASCII to Unicode.
        /// </summary>
        /// //////////////////////////////////////////////////////////////////////////////////////

        private string convert_ASCII_to_unicode(string input)
        {
            //------------------------------------------------------------------------
            // Convert to 2 byte Unicode
            // The return is always 2 bytes.
            //-----------------------------------------------------------------------

            StringBuilder ubuilder = new StringBuilder();
            string utext = input.Replace(" ", "");

            char[] stringChars = Encoding.Unicode.GetChars(Encoding.Unicode.GetBytes(utext));

            Array.ForEach(stringChars, c => ubuilder.AppendFormat("{0:x4} ", (int)c));

            return ubuilder.ToString();
        }

        //////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Convert ASCII to UTF8.
        /// </summary>
        /// //////////////////////////////////////////////////////////////////////////////////////


        private string convert_ASCII_to_utf8(string input)
        {
            //------------------------------------------------------------------------
            // Convert to UTF8
            // The return will be either 1 byte, 2 bytes or 3 bytes.
            //-----------------------------------------------------------------------

            UTF8Encoding utf8 = new UTF8Encoding();
            StringBuilder builder = new StringBuilder();

            string utext = input.Replace(" ", "");

            for (int text_index = 0; text_index < utext.Length; text_index++) //do one char at a time

            {
                byte[] encodedBytes = utf8.GetBytes(utext.Substring(text_index, 1));

                for (int index = 0; index < encodedBytes.Length; index++)

                {
                    builder.AppendFormat("{0}", Convert.ToString(encodedBytes[index], 16));
                }

                builder.Append(" ");
            }

            return builder.ToString();
        }

        //////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Convert UTF8 to ASCII.
        /// </summary>
        /// //////////////////////////////////////////////////////////////////////////////////////

        private string convert_UTF8_to_ASCII(string input)
        {
            string ans = "";

            //split into 2 char chunks, then into bytes, then into string.
            Encoding utf8 = Encoding.UTF8;
            string utext = input.Replace(" ", ""); //get string and remove spaces.
            ans =
                Encoding.UTF8.GetString(
                    Enumerable.Range(0, utext.Length / 2)
                        .Select(i => Convert.ToByte(utext.Substring(i * 2, 2), 16))
                        .ToArray());
            return ans;


        }

        //////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Convert Unicode to ASCII
        /// </summary>
        /// //////////////////////////////////////////////////////////////////////////////////////

        private string convert_Unicode_to_ASCII(string input)
        {
            String utext = input.Replace(" ", ""); //get string and remove spaces.

            char c = ' ';
            string rtstr = "";

            for (int i = 0; i < utext.Length; i += 4)
            {
                string str1 = utext.Substring(i, 4);
                c = (char)Int16.Parse(str1, System.Globalization.NumberStyles.HexNumber);
                rtstr += c;
            }

            return rtstr;
        }

       
    }
}
