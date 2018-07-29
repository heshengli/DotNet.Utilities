using System;
using System.Security.Cryptography;

namespace DotNet.Utilities.Security.Common
{
    public static class Md5
    {
        /// <summary>
        /// 使用MD5对字符串进行加密
        /// </summary>
        /// <param name="str">需要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string Md5Encrypts(string str)
        {
            return SecurityBase.Encrypt(MD5.Create(), str);
        }

        /// <summary>
        /// 用未加密的值匹配加密过的值
        /// </summary>
        /// <param name="hashedText">The hashed text.</param>
        /// <param name="unhashedText">The unhashed text.</param>
        /// <returns>
        /// </returns>
        public static bool IsMd5Match(
            string hashedText, string unhashedText)
        {
            string hashedTextToCompare = Md5Encrypts(unhashedText);
            return (String.CompareOrdinal(hashedText,
                        hashedTextToCompare) == 0);
        }
    }
}
