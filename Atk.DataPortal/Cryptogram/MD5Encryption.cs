using System;
using System.Security.Cryptography;
using System.Text;

namespace Atk.Tool.Cryptogram
{
    /// <summary>
    /// MD5加密算法
    /// </summary>
    public static class MD5Encryption
    {
        /// <summary>
        /// 获取某个字符串的MD5值
        /// </summary>
        /// <param name="str">要签名的字串</param>
        /// <returns>签名结果</returns>
        public static string MD5(string str)
        {
            MD5 m = new MD5CryptoServiceProvider();
            byte[] s = m.ComputeHash(UnicodeEncoding.UTF8.GetBytes(str));
            return BitConverter.ToString(s).Replace("-", "");
        }

        /// <summary>
        /// 返回文件流的MD5值
        /// </summary>
        /// <param name="fileBytes">要签名的文件</param>
        /// <returns>签名</returns>
        public static string FileMD5(byte[] fileBytes)
        {
            MD5 m = new MD5CryptoServiceProvider();
            byte[] s = m.ComputeHash(fileBytes);
            return BitConverter.ToString(s).Replace("-", "");
        }
    }
}
