using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DotNet.Utilities.Security.Common
{
    public static class Des
    {

        public static string Key = "DotNet.Utilities";//加密密钥必须为8位

        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="pToEncrypt"></param>
        /// <returns></returns>
        public static string DesEncrypt(string pToEncrypt)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            des.Key = Encoding.ASCII.GetBytes(Key);
            des.IV = Encoding.ASCII.GetBytes(Key);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();

        }

        /// <summary>
        /// 解密算法
        /// </summary>
        /// <param name="pToDecrypt"></param>
        /// <returns></returns>
        public static string DesDecrypt(string pToDecrypt)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }
            des.Key = Encoding.ASCII.GetBytes(Key);
            des.IV = Encoding.ASCII.GetBytes(Key);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            return System.Text.Encoding.ASCII.GetString(ms.ToArray());
        }
    }
}
