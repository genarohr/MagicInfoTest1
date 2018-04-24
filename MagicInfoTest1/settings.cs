using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Configuration;

using MagicInfoTest1.Properties;

/*
 Based on https://msdn.microsoft.com/en-us/library/ms995355.aspx



     */
namespace MagicInfoTest1
{
    class settings
    {
        static byte [] s_aditionalEntropy = { 9, 8, 7, 6, 5 };

        public settings()
        {

        }


        public void setSettings(string strServer, string strUser, string strPass)
        {
            Settings.Default.username = strUser;
            Settings.Default.password = strPass;
            Settings.Default.server = strServer;
        }


        public string cypher(string text)
        {
            string cyphered;

            cyphered = Protect(text).ToString();
                
            return cyphered;
        }

        public static byte[] Protect(string password)
        {
            byte[] toEncrypt = UnicodeEncoding.ASCII.GetBytes(password);

            try
            {
                // Encrypt the data using DataProtectionScope.CurrentUser. The result can be decrypted
                //  only by the same current user.
                return ProtectedData.Protect(toEncrypt, s_aditionalEntropy, DataProtectionScope.CurrentUser);
            }
            catch (CryptographicException e)
            {

                MessageBox.Show(e.ToString(), "Data was not encrypted. An error occurred." , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public static string Unprotect(string encrypted)
        {
            byte[] toDecrypt = UnicodeEncoding.ASCII.GetBytes(encrypted);

            try
            {
                //Decrypt the data using DataProtectionScope.CurrentUser.
                byte[] data = ProtectedData.Unprotect(toDecrypt, s_aditionalEntropy, DataProtectionScope.CurrentUser);
                return UnicodeEncoding.ASCII.GetString(data);
            }
            catch (CryptographicException e)
            {
                MessageBox.Show(e.ToString(), "Data was not decrypted. An error occurred." , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }


    }
}
