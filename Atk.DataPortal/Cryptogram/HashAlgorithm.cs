using System;
using System.Security.Cryptography;
using System.Text;

namespace Atk.Tool.Cryptogram
{
    /// <summary>
    /// Hash算法
    /// </summary>
    public static class HashAlgorithm
    {
        /// <summary>
        /// 验证模版
        /// </summary>
        private static  string xtvalidateTemp = "{0}_{1}_";

        /// <summary>
        /// 将字符串用HASH512的算法加密
        /// </summary>
        /// <param name="strPlain">要加密的字串</param>
        /// <returns>加密后字串</returns>
        public static string SHA512(string strPlain)
        {
            SHA512Managed sha512 = new SHA512Managed();
            string strHash = string.Empty;
            byte[] btHash = sha512.ComputeHash(UnicodeEncoding.Unicode.GetBytes(strPlain));
            for (int i = 0; i < btHash.Length; i++)
            {
                strHash = strHash + Convert.ToString(btHash[i], 16);
            }
            return strHash;
        }

        /// <summary>
        /// 生成数字签名验证码
        /// </summary>
        /// <param name="parameters">要签名的对象</param>
        /// <returns>签名</returns>
        public static string CreateValidateCode(params object[] parameters)
        {
            if (parameters != null && parameters.Length > 0)
            {
                StringBuilder codeBuilder = new StringBuilder();

                for (int i = 0; i < parameters.Length; i++)
                {
                    codeBuilder.Append(string.Format(xtvalidateTemp, i, parameters[i]));
                }

                return SHA512(codeBuilder.ToString());
            }
            else
            {
                throw new Exception("生成数字签名至少传入一个参数");
            }
        }

        /// <summary>
        /// 比对数字签名
        /// </summary>
        /// <param name="sourceCode">源</param>
        /// <param name="parameters">参数</param>
        /// <returns>相同为真</returns>
        public static bool EqualsValidateCode(string sourceCode, params object[] parameters)
        {
            if (!string.IsNullOrEmpty(sourceCode))
            {
                string newCode = CreateValidateCode(parameters);

                return sourceCode.Equals(newCode);
            }

            return false;
        }
    }
}
