using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atk.CustomExpression
{
    /// <summary>
    /// 表达式工具
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// 增加 In 条件语句（注意加入的条件不益太多，否则会超过SQL语句的限制
        /// </summary>
        /// <param name="inConditon">条件组</param>
        /// <returns>In 条件语句</returns>
        public static string MutiInWhere(int[] inConditon)
        {

            string atkincdt = string.Empty;
            foreach (var item in inConditon)
            {
                if (string.IsNullOrWhiteSpace(atkincdt))
                {
                    atkincdt = item.ToString();
                }
                else
                {
                    atkincdt = atkincdt + "," + item.ToString();
                }
            }

            return atkincdt;
        }

        /// <summary>
        /// 增加 In 条件语句（注意加入的条件不益太多，否则会超过SQL语句的限制
        /// </summary>
        /// <param name="inConditon">条件组</param>
        /// <returns>In 条件语句</returns>
        public static string MutiInWhere(IList<int> inConditon)
        {
            string atkincdt = string.Empty;
            foreach (var item in inConditon)
            {
                if (string.IsNullOrWhiteSpace(atkincdt))
                {
                    atkincdt = item.ToString();
                }
                else
                {
                    atkincdt = atkincdt + "," + item.ToString();
                }
            }
            return atkincdt;
        }
    }
}
