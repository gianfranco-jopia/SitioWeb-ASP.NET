using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Minimarket.Clases
{
    public class clsGeneral
    {
        static string saltValue = "hytbdgdej";
        static string hashAlgorithm = "MD5";
        static int passwordIterations = 1;
        static string initVector = "@1B2c3D4e5F6g7H8";
        static int keySize = 192;

        private clsGeneral()
        {
        }

        public static QueryString EncryptQueryString(QueryString queryString)
        {
            QueryString newQueryString = new QueryString();
            string nm = String.Empty;
            string val = String.Empty;
            foreach (string name in queryString)
            {
                nm = name;
                val = System.Web.HttpUtility.UrlEncode(queryString[name]);
                newQueryString.Add(clsGeneral.Encrypt(nm, "%jetsbdh"), clsGeneral.Encrypt(val, "%jetsbdh"));
            }
            return newQueryString;
        }

        public static QueryString DecryptQueryString(QueryString queryString)
        {
            QueryString newQueryString = new QueryString();
            string nm;
            string val;
            foreach (string name in queryString)
            {
                nm = clsGeneral.DecryptString(name, "%jetsbdh");
                val = System.Web.HttpUtility.UrlDecode(clsGeneral.DecryptString(queryString[name], "%jetsbdh"));
                newQueryString.Add(nm, val);
            }
            return newQueryString;
        }

        private static string Encrypt(string plainText, string passPhrase)
        {
            byte[] initVectorBytes;
            initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes;
            saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] plainTextBytes;
            plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password;
            password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes;
            keyBytes = password.GetBytes((keySize / 8));
            RijndaelManaged symmetricKey;
            symmetricKey = new RijndaelManaged();
            symmetricKey.Padding = PaddingMode.Zeros;
            //  It is reasonable to set encryption mode to Cipher Block Chaining
            //  (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor;
            encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream;
            memoryStream = new MemoryStream();
            CryptoStream cryptoStream;
            cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

            //  Start encrypting.
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            //  Finish encrypting.
            cryptoStream.FlushFinalBlock();


            byte[] cipherTextBytes;
            cipherTextBytes = memoryStream.ToArray();

            //  Close both streams.
            cryptoStream.Close();
            memoryStream.Close();

            // Get the data back from the memory stream, and into a string
            StringBuilder ret = new StringBuilder();

            byte[] b = cipherTextBytes;

            int I;
            for (I = 0; (I <= b.Length - 1); I++)
            {
                // Format as hex
                ret.AppendFormat("{0:X2}", b[I]);
            }
            return ret.ToString();

        }

        private static string DecryptString(string cipherText, string passPhrase)
        {
            if ((cipherText == String.Empty))
            {
                return "";
            }
            else
            {
                byte[] initVectorBytes;
                initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes;
                saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

                byte[] cipherTextBytes = new byte[Convert.ToInt32(cipherText.Length / 2)];

                int X;
                for (X = 0; (X <= (cipherTextBytes.Length - 1)); X++)
                {
                    Int32 IJ = Convert.ToInt32(cipherText.Substring((X * 2), 2), 16);
                    System.ComponentModel.ByteConverter BT = new System.ComponentModel.ByteConverter();
                    cipherTextBytes[X] = new byte();
                    cipherTextBytes[X] = ((byte)(BT.ConvertTo(IJ, typeof(byte))));
                }

                PasswordDeriveBytes password;
                password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);


                byte[] keyBytes;
                keyBytes = password.GetBytes((keySize / 8));

                RijndaelManaged symmetricKey;
                symmetricKey = new RijndaelManaged();
                symmetricKey.Padding = PaddingMode.Zeros;

                symmetricKey.Mode = CipherMode.CBC;

                ICryptoTransform decryptor;
                decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

                MemoryStream memoryStream;
                memoryStream = new MemoryStream(cipherTextBytes);

                CryptoStream cryptoStream;
                cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

                byte[] plainTextBytes = new byte[cipherTextBytes.Length];

                int decryptedByteCount;
                decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);


                StringBuilder ret = new StringBuilder();
                byte[] B = memoryStream.ToArray();
                //  Close both streams.
                memoryStream.Close();
                cryptoStream.Close();

                string plainText;
                plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

                return plainText;
            }
        }
    }
}