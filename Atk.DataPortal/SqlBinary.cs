using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.Script.Serialization;


namespace Atk.DataPortal
{
    /// <summary>
    /// 对业务中多信息但以后并不提供条件查询时,
    /// 保存在一个二进制字段中
    /// </summary>
    public static class SqlBinary
    {
        /// <summary>
        /// 将当前对像序列化并转成字节流
        /// </summary>
        /// <param name="XtObject">要序列化的对像</param>
        /// <returns>字节流</returns>
        public static byte[] XtClassToMem(Object XtObject)
        {



            using (MemoryStream strm = new MemoryStream())
            {
                //序列化对像
                BinaryFormatter f = new BinaryFormatter();
                f.Serialize(strm, XtObject);
                strm.Position = 0;
                return strm.ToArray();
            }




        }

        /// <summary>
        /// 将已序列化的对象，反序列化
        /// </summary>
        /// <typeparam name="T">反序列化类型</typeparam>
        /// <param name="SqlValue">SQL查询的值</param>
        /// <returns>反序列化对象</returns>
        public static T XtMemToClass<T>(byte[] SqlValue)
        {
            using (MemoryStream strm = new MemoryStream(SqlValue))
            {
                BinaryFormatter f = new BinaryFormatter();
                return (T)f.Deserialize(strm);
            }
        }

        /// <summary>
        /// 装对象转换为JOSN
        /// </summary>
        /// <param name="bizObject">要转换的JOSN的对象</param>
        /// <returns>OSN的对象</returns>
        public static string BizObjectToJosn(Object bizObject)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(bizObject);
        }

        /// <summary>
        /// 将JOSN转换成 对象
        /// </summary>
        /// <typeparam name="T">返回的对象类型</typeparam>
        /// <param name="bizJosn">确定的对象JOSN</param>
        /// <returns>返回的对象</returns>
        public static T BizJosnToObject<T>(string bizJosn)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Deserialize<T>(bizJosn);

        }
    }
}
