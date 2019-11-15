using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Utility
{
    public sealed class CipherUtility
    {
        private static string Default_Key = "P@ssw0rd";
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            return Encrypt(toEncrypt, useHashing, Default_Key);
        }
        public static string Encrypt(string toEncrypt, bool useHashing, string key)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            //If hashing use get hashcode regards to your key
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(string cipherString, bool useHashing)
        {
            return Decrypt(cipherString, useHashing, Default_Key);
        }
        public static string Decrypt(string cipherString, bool useHashing, string key)
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        public static string DecryptToLarge(string cipherString, bool useHashing)
        {
            return DecryptToLarge(cipherString, useHashing, Default_Key);
        }
        public static string DecryptToLarge(string cipherString, bool useHashing, string key)
        {
            byte[] keyArray;
            //get the byte code of the string
            string stringToDecrypt = cipherString.Replace(" ", "+");
            byte[] toEncryptArray = Convert.FromBase64String(stringToDecrypt);

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        public static string GetMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
        public static bool VerifyMd5Hash(string input, string hash)
        {
            // Hash the input. 
            string hashOfInput = GetMd5Hash(input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string GenneralToken(int? lenghtRand = 6)
        {
            int randLen = lenghtRand ?? 6;
            string randTemp = "9";
            if (lenghtRand != null && lenghtRand >= 3)
            {
                randTemp = randTemp.PadRight(randLen, '9');
            }
            string tokenTemp = string.Empty;
            var random = new Random();
            int rand = random.Next(0, int.Parse(randTemp));
            tokenTemp = rand.ToString().PadLeft(randLen, '0');
            return tokenTemp;
        }
        public static string RandomCustomerAccout(int? lenStr1 = 2, int? lenNum2 = 6, int? lenStr3 = 1)
        {

            int numStart = 1000;
            int numEnd = 9999;
            if (lenNum2 != null && lenNum2 >= 3)
            {
                string numStr1 = "1";
                string numStr2 = "9";
                numStr1 = numStr1.PadRight((int)lenNum2, '0');
                numStr2 = numStr2.PadRight((int)lenNum2, '9');
                int.TryParse(numStr1, out numStart);
                int.TryParse(numStr2, out numEnd);
            }
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString((int)lenStr1, true));
            builder.Append(RandomNumber(numStart, numEnd));
            builder.Append(RandomString((int)lenStr3, false));
            return builder.ToString().ToUpper();
        }
        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        private static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
    }

    public sealed class CryptoStreamUtility
    {
        private static readonly string PasswordHash = "P@@SMSC@2@m8cua7G2LPsKwGdpY7fjXSqZDCpbdMwfwK43RWb2mxbacdfpCq95AK622Qn6u95KkEDbe7PeFPhrV";
        private static readonly string SaltKey = "S@LVHST&KEYa5mVkkxReEXSyzgAm3VHmXvJDC9K4uLRCKSBGaUJ2SheGnJBjBG95A1SkQjVjkKW9QdQ7hr5VJC3sf9";
        private static readonly string VIKey = "@xXrT9wzhrVbgMFR";
        
        public static string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }

        public static string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }
    }

    public sealed class GenerateQRCode
    {
        private const string keyInput = @"|F8F8E1LV9190FF84EEBFE9B5MSC10DC9E812A95F905B99A15LACVIET95A1814A6E589D0C8671";
        private const string keyLevel2 = @"WqbmXSqnd4cMwMKGzJkVSL3FF8208C-5234-4EA0-AF09-CE846915628B";
        public static string Encrypt(string input)
        {
            string result = string.Empty;
            try
            {
                var ecrlv1 = CryptoStreamUtility.Encrypt(input + keyInput);
                result = CipherUtility.Encrypt(ecrlv1, true, keyLevel2);
            }
            catch { }
            return result;
        }

        public static string Decrypt(string encryptedText)
        {
            string result = string.Empty;
            try
            {
                var codeDecryptMD5 = CipherUtility.DecryptToLarge(encryptedText, true, keyLevel2);
                var codeDecryptCrypto = CryptoStreamUtility.Decrypt(codeDecryptMD5);
                var words = codeDecryptCrypto.Split('|');
                if (words.Length > 0)
                {
                    result = words[0];
                }
            }
            catch { }
            return result;
        }
    }
}
