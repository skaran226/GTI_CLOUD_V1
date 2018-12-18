using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;


namespace GTICLOUD
{
    public class Cryptography
    {
        public static string GetEncryptedSitekey(string key)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[key.Length];
            encode = Encoding.UTF8.GetBytes(key);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;

        }

        public static string Decrypt(string prm)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(prm);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd; 
        }

        public static string GetK_Encryption(string key) {

            Thread.Sleep(50);
            
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@$%^*()[]{},?";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            
            var finalString = new String(stringChars);

            var laststring = String.Format("{0:X}", Convert.ToInt32(key) + 1500);
            return finalString+laststring;

            
           }

        public static string GetK_Decrypt(string key)
        {

            string str = key.Substring(8);
            int dec = Convert.ToInt32(str, 16);
            int id = dec - 1500;
            return id.ToString();

            


        }

        
    }
}