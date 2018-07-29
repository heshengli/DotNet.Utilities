using System;
using System.Security.Cryptography;
using System.Text;

namespace DotNet.Utilities.Security.Common
{
    public class SecurityBase
    {
        /// <summary>
        /// Encrypts the specified hash algorithm.
        /// 1. Generates a cryptographic Hash Key for the provided text data.
        /// </summary>
        /// <param name="hashAlgorithm">The hash algorithm.</param>
        /// <param name="dataToHash">The data to hash.</param>
        /// <returns></returns>
        public static string Encrypt(HashAlgorithm hashAlgorithm, string dataToHash)
        {

            var tabStringHex = new string[16];
            var utf8 = new System.Text.UTF8Encoding();
            //先将要加密的字符串转换成byte数组
            byte[] data = utf8.GetBytes(dataToHash);
            //在通过加密类，并得到加密后的byte[]类型
            byte[] result = hashAlgorithm.ComputeHash(data);
            var hexResult = new StringBuilder(result.Length);

            foreach (var t in result)
            {
                //将每个byte数据转换成16进制。"X":表示大写16进制；"X2"：表示大写16进制保留2位；"x"：表示小写16进制
                hexResult.Append(t.ToString("X2"));
            }
            return hexResult.ToString();
        }

        /// <summary>
        /// Determines whether [is hash match] [the specified hash algorithm].
        /// </summary>
        /// <param name="hashAlgorithm">The hash algorithm.</param>
        /// <param name="hashedText">The hashed text.</param>
        /// <param name="unhashedText">The unhashed text.</param>
        /// <returns>
        ///   <c>true</c> if [is hash match] [the specified hash algorithm]; 
        /// otherwise, <c>false</c>.
        /// </returns>
        public static bool IsHashMatch(HashAlgorithm hashAlgorithm,
            string hashedText, string unhashedText)
        {
            string hashedTextToCompare = Encrypt(
                hashAlgorithm, unhashedText);
            return (String.CompareOrdinal(hashedText,
                        hashedTextToCompare) == 0);
        }
    }
}
