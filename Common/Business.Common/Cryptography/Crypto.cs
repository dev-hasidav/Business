using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Cryptography
{
    [NumClass(2)]
    public class Crypto
    {
        #region  ==========  Шифрование  ==========

        private static readonly byte[] Key1 = new byte[] { 0x13, 0xff, 0x15, 0xb4, 0x59, 0x00, 0xde, 0xff,
                                      0x7a, 0xcd, 0xc4, 0x5e, 0x83, 0x30, 0xd1, 0xf3 ,
                                      0xbc, 0x6a, 0xc4, 0x33, 0x00, 0x45, 0x6d, 0x6e};
        private static readonly byte[] IV1 = new byte[] { 0x5e, 0x45, 0x99, 0x0e, 0x7a, 0xed, 0xb1, 0xe0 };

        /// <summary>
        /// Шифрует string
        /// </summary>
        /// <param name="Data">Данные для шифрования</param>
        /// <returns></returns>
        public static byte[] Encryptor(string Data)
        {
            System.IO.MemoryStream ms = null;
            System.Security.Cryptography.CryptoStream strim = null;
            try
            {
                System.Security.Cryptography.TripleDESCryptoServiceProvider cs =
                    new System.Security.Cryptography.TripleDESCryptoServiceProvider
                    {
                        Key = Key1,
                        IV = IV1
                    };
                ms = new System.IO.MemoryStream();
                strim = new System.Security.Cryptography.CryptoStream(ms, cs.CreateEncryptor(),
                    System.Security.Cryptography.CryptoStreamMode.Write);
                byte[] bb = System.Text.Encoding.UTF8.GetBytes(Data);
                strim.Write(bb, 0, bb.Length);
                strim.FlushFinalBlock();
            }
            catch (Exception) { throw; }
            finally
            {
                strim?.Close();
                ms?.Close();
            }
            return ms.ToArray();

        }

        /// <summary>
        /// Шифрует string
        /// </summary>
        /// <param name="Data">Данные для шифрования</param>
        /// <returns></returns>
        public static byte[] EncryptorByte(byte[] Data)
        {
            System.IO.MemoryStream ms = null;
            System.Security.Cryptography.CryptoStream strim = null;
            try
            {
                System.Security.Cryptography.TripleDESCryptoServiceProvider cs =
                    new System.Security.Cryptography.TripleDESCryptoServiceProvider
                    {
                        Key = Key1,
                        IV = IV1
                    };
                ms = new System.IO.MemoryStream();
                strim = new System.Security.Cryptography.CryptoStream(ms, cs.CreateEncryptor(),
                    System.Security.Cryptography.CryptoStreamMode.Write);
                strim.Write(Data, 0, Data.Length);
                strim.FlushFinalBlock();
            }
            catch (Exception) { throw; }
            finally
            {
                strim?.Close();
                ms?.Close();
            }
            return ms.ToArray();

        }

        /// <summary>
        /// Дешифровует набор байтов
        /// </summary>
        /// <param name="Data">Донные для дешифрования</param>
        /// <returns>Выходная строка или NULL если ошибка</returns>
        public static string Decryptor(byte[] Data)
        {
            System.IO.MemoryStream ms = null;
            System.Security.Cryptography.CryptoStream strim = null;
            string s_red = null;
            try
            {
                System.Security.Cryptography.TripleDESCryptoServiceProvider cs =
                    new System.Security.Cryptography.TripleDESCryptoServiceProvider
                    {
                        Key = Key1,
                        IV = IV1
                    };
                ms = new System.IO.MemoryStream(Data)
                {
                    Position = 0
                };
                strim = new System.Security.Cryptography.CryptoStream(ms, cs.CreateDecryptor(),
                System.Security.Cryptography.CryptoStreamMode.Read);
                byte[] bb = new byte[1024];
                int n1 = strim.Read(bb, 0, bb.Length);
                s_red = System.Text.Encoding.UTF8.GetString(bb, 0, n1);

            }
            catch (Exception) { throw; }
            finally
            {
                strim?.Close();
                ms?.Close();
            }
            return s_red;
        }

        /// <summary>
        /// Дешифровует набор байтов
        /// </summary>
        /// <param name="Data">Донные для дешифрования</param>
        /// <returns>Выходная строка или NULL если ошибка</returns>
        public static byte[] DecryptorByte(byte[] Data)
        {
            System.IO.MemoryStream ms = null;
            System.Security.Cryptography.CryptoStream strim = null;
            byte[] s_red = null;
            try
            {
                System.Security.Cryptography.TripleDESCryptoServiceProvider cs =
                    new System.Security.Cryptography.TripleDESCryptoServiceProvider
                    {
                        Key = Key1,
                        IV = IV1
                    };
                ms = new System.IO.MemoryStream(Data)
                {
                    Position = 0
                };
                strim = new System.Security.Cryptography.CryptoStream(ms, cs.CreateDecryptor(),
                    System.Security.Cryptography.CryptoStreamMode.Read);
                byte[] bb = new byte[1024];
                int n1 = strim.Read(bb, 0, bb.Length);
                s_red = new byte[n1];
                for (int n2 = 0; n2 < n1; n2++)
                {
                    s_red[n2] = bb[n2];
                }
            }
            catch (Exception) { throw; }
            finally
            {
                strim?.Close();
                ms?.Close();
            }
            return s_red;
        }

        #endregion
    }
}
