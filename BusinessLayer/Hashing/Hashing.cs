using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Hashing
{
    public class Hashing
    {
        public string DecryptString(string encrString)
        {
            byte[] hash;
            string decrypted;
            try
            {
                hash = Convert.FromBase64String(encrString);
                decrypted = Encoding.ASCII.GetString(hash);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }
        public string EncrytString(string strEncrypeted)
        {
            byte[] hash;
            string encrypted;
            hash = Encoding.ASCII.GetBytes(strEncrypeted);
            encrypted = Convert.ToBase64String(hash);
            return encrypted;
        }
    }
}
