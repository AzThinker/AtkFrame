using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Atk.Tool.Cryptogram
{
    /// <summary>
    /// 对称加密
    /// </summary>
    public sealed class SymmetricEncryption
    {
        #region 构造函数

        /// <summary>
        /// 加密、解密的动态密匙Key
        /// </summary>
        private static readonly string dynamicKey = DateTime.Now.ToString("yyyyMMddHHmmssms");

        /// <summary>
        /// 构造函数(使用动态密匙,注意:在不同的网站作用域下的动态密匙会不同)
        /// </summary>
        public SymmetricEncryption() { }

        /// <summary>
        /// 构造函数(使用指定密匙)
        /// </summary>
        /// <param name="encryKey">对称加密密码</param>
        public SymmetricEncryption(string encryKey)
        {
            this._encryKey = encryKey;
        }

        #endregion

        #region 成员属性

        /// <summary>
        /// 对称加密密匙
        /// </summary>
        private string _encryKey = string.Empty;

        /// <summary>
        /// 对称加密密匙
        /// </summary>
        public string EncryKey
        {
            get
            {
                if (string.IsNullOrEmpty(this._encryKey))
                {
                    this._encryKey = dynamicKey;
                }

                return this._encryKey;
            }
        }

        /// <summary>
        /// 加密解密算法公式类
        /// </summary>
        private DESCryptoServiceProvider _desFormula = null;

        /// <summary>
        /// 加密解密算法公式类
        /// </summary>
        private DESCryptoServiceProvider DesFormula
        {
            get
            {
                if (this._desFormula == null)
                {
                    this._desFormula = new DESCryptoServiceProvider();
                    this._desFormula.Key = ASCIIEncoding.ASCII.GetBytes(MD5(this.EncryKey).Substring(0, 8));
                    this._desFormula.IV = ASCIIEncoding.ASCII.GetBytes(MD5(this.EncryKey).Substring(0, 8));
                }

                return this._desFormula;
            }
        }

        #endregion

        #region 成员方法

        /// <summary>
        /// 是否是对称加密的字符串
        /// </summary>
        /// <param name="text">加密的方本</param>
        /// <returns>是对称加密的字符串时为真</returns>
        public static bool IsSymmetricEncryptionText(string text)
        {
            if (!string.IsNullOrEmpty(text) && text.Length > 0 && text.Length % 2 == 0)
            {
                return Regex.IsMatch(text, @"^[0-9A-Z]+$");
            }
            return false;
        }

        /// <summary>
        /// 静态加密方法
        /// </summary>
        /// <param name="text">要加密的文本</param>
        /// <param name="eccryKey">加密钥</param>
        /// <returns>已经加密的文本</returns>
        public static string BizEncrypt(string text, string eccryKey = "athinker")
        {
            SymmetricEncryption se = new SymmetricEncryption(eccryKey);
            return se.Encrypt(text);
        }

        /// <summary>
        /// 静态解密方法
        /// </summary>
        /// <param name="text">要加密的文本</param>
        /// <param name="eccryKey">加密钥</param>
        /// <returns>已经解密的文本</returns>
        public static string BizDecrypt(string text, string eccryKey = "athinker")
        {
            SymmetricEncryption se = new SymmetricEncryption(eccryKey);
            return se.Decrypt(text);
        }
        /// <summary>
        /// 静态解密方法
        /// </summary>
        /// <param name="text">要加密的文本</param>
        /// <param name="realText">实际文本</param>
        /// <param name="eccryKey">加密钥</param>
        /// <returns>是否正确解密</returns>
        public static bool BizDecrypt(string text, ref string realText, string eccryKey = "athinker")
        {
            bool flag = false;
            if (!string.IsNullOrEmpty(text) && text.Length > 0 && text.Length % 2 == 0)
            {
                if (Regex.IsMatch(text, @"^[0-9A-Z]+$"))
                {
                    try
                    {
                        realText = BizDecrypt(text, eccryKey);
                        flag = true;
                    }
                    catch
                    {
                        realText = string.Empty;
                    }
                }
            }
            return flag;
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="text">要加密的文本</param>
        /// <returns>加密后的文本</returns>
        public string Encrypt(string text)
        {
            byte[] inputByteArray;
            inputByteArray = Encoding.Default.GetBytes(text);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, this.DesFormula.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();

            byte[] cryptoBytes = ms.ToArray();

            foreach (byte b in cryptoBytes)
            {
                ret.AppendFormat("{0:X2}", b);
            }

            return ret.ToString();
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="text">要解密的密文</param>
        /// <returns>解密后文本</returns>
        public string Decrypt(string text)
        {
            if (IsSymmetricEncryptionText(text))
            {
                int len;
                len = text.Length / 2;
                byte[] inputByteArray = new byte[len];
                int x, i;

                for (x = 0; x < len; x++)
                {
                    i = Convert.ToInt32(text.Substring(x * 2, 2), 16);
                    inputByteArray[x] = (byte)i;
                }
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                CryptoStream cs = new CryptoStream(ms, this.DesFormula.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Encoding.Default.GetString(ms.ToArray());
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="s">要签名的字串</param>
        /// <returns>签名</returns>
        private string MD5(string s)
        {
            string RetVal = string.Empty;
            MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bt = Encoding.Default.GetBytes(s);//将待加密字符转为 字节型数组
            byte[] resualt = md5.ComputeHash(bt);//将字节数组转为加密的字节数组

            RetVal = BitConverter.ToString(resualt).Replace("-", "");//将数字转为string 型去掉内部的无关字符

            return RetVal;
        }

        #endregion
    }
}
