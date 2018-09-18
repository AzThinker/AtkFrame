using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Atk.CustomExpression
{
    /// <summary>
    /// 表达式操作枚举
    /// </summary>
    internal enum ExpUnion : byte
    {
        /// <summary>
        /// 与操作
        /// </summary>
        And,
        /// <summary>
        /// 或操作
        /// </summary>
        Or,
        /// <summary>
        /// 排序操作
        /// </summary>
        OrderBy
    }

    /// <summary>
    /// 表别名
    /// </summary>
    public enum Alias
    {
        /// <summary>
        /// 别名为 [a0]
        /// </summary>
        a0,
        /// <summary>
        /// 别名为 [a1]
        /// </summary>
        a1,
        /// <summary>
        /// 别名为 [a2]
        /// </summary>
        a2,
        /// <summary>
        /// 别名为 [a3]
        /// </summary>
        a3,
        /// <summary>
        /// 别名为 [a4]
        /// </summary>
        a4,
        /// <summary>
        /// 别名为 [a5]
        /// </summary>
        a5,
        /// <summary>
        /// 别名为 [a6]
        /// </summary>
        a6,
        /// <summary>
        /// 别名为 [a7]
        /// </summary>
        a7,
        /// <summary>
        /// 别名为 [a8]
        /// </summary>
        a8,
        /// <summary>
        /// 无别名时的值
        /// </summary>
        a99_empty
    }

    /// <summary>
    /// Lambda转SQL语句
    /// </summary>
    /// <typeparam name="T">查询类</typeparam>
    [Serializable]
    public sealed class ExpConditions<T>
    {

        #region 外部访问方法


        private string _accessFetch;

        /// <summary>
        /// 附加的多表查询方式,用于 Get 方法的附加
        /// <example> 
        /// SELECT     DishesID, DishesName, DishesUnit
        /// FROM dbo.Aidb_DishesItems As [a0] 
        /// inner join (select DishesTypeID from dbo.Aidb_DishesType where IsShow=1) as [a1] 
        /// on [a0].DishesTypeID=[a1].DishesTypeID
        /// 中的 “inner join (select DishesTypeID from dbo.Aidb_DishesType where IsShow=1) as [a1] 
        /// on [a0].DishesTypeID=[a1].DishesTypeID”就是本属性可以的一种形式
        /// </example>
        /// </summary>

        public string AccessFetch
        {
            get { return _accessFetch; }
            set { _accessFetch = value; }
        }


        private string _accessFetchList;

        /// <summary>
        /// 附加的多表查询方式,用于 GetList 的附加
        /// <example> 
        /// SELECT     DishesID, DishesName, DishesUnit
        /// FROM dbo.Aidb_DishesItems As [a0] 
        /// inner join (select DishesTypeID from dbo.Aidb_DishesType where IsShow=1) as [a1] 
        /// on [a0].DishesTypeID=[a1].DishesTypeID
        /// 中的 “inner join (select DishesTypeID from dbo.Aidb_DishesType where IsShow=1) as [a1] 
        /// on [a0].DishesTypeID=[a1].DishesTypeID”就是本属性可以的一种形式
        /// </example>
        /// </summary>
        public string AccessFetchList
        {
            get { return _accessFetchList; }
            set { _accessFetchList = value; }
        }


        /// <summary>
        /// 获取当前表达式中的更新字段语句
        /// 内部方法，处部程序员不宜使用
        /// </summary>
        /// <returns>更新字段语句</returns>
        public string UpdateFields()
        {
            IEnumerable<KeyValuePair<string, string>> atkfl = _atkUpdateListField.Distinct();

            if (atkfl.Count() == 0)
            {
                return string.Empty;
            }

            string result = string.Empty;

            foreach (var item in atkfl)
            {
                if (string.IsNullOrEmpty(result))
                {
                    result = item.Key + " = @" + item.Value;
                }
                else
                {
                    result = result + "," + item.Key + " = @" + item.Value;
                }
            }
            return result;
        }

        /// <summary>
        /// 获取增加语句
        /// 内部程序调用，外部程度员不要使用 
        /// </summary>
        /// <returns>增加语句</returns>
        public string InsertFields()
        {
            IEnumerable<KeyValuePair<string, string>> atkfl = _atkUpdateListField.Distinct();

            if (atkfl.Count() == 0)
            {
                return string.Empty;
            }

            string result1 = string.Empty;
            string result2 = string.Empty;

            foreach (var item in atkfl)
            {
                if (string.IsNullOrEmpty(result1))
                {
                    result1 = "(" + "[" + item.Value + "]";
                    result2 = ") Values (@" + item.Value;
                }
                else
                {
                    result1 = result1 + "," + item.Key;
                    result2 = result2 + ",@" + item.Value;

                }
            }
            return result1 + result2 + ")";
        }

        /// <summary>
        /// 获取 Where 条件语句
        /// </summary>
        /// <param name="AddCinditionKey">是否加Where词</param>
        /// <returns>Where条件语句</returns>
        public string Where(bool AddCinditionKey = true)
        {
            if (string.IsNullOrWhiteSpace(_atkWhereStr))
            {
                return string.Empty;
            }

            if (AddCinditionKey)
            {
                return " Where " + _atkWhereStr;
            }
            else
            {
                return _atkWhereStr;
            }
        }



        /// <summary>
        /// 获取 OrderBy 条件语句
        /// </summary>
        /// <param name="AddCinditionKey">是否加Order By词</param>
        /// <returns>OrderBy 条件语句</returns>
        public string OrderBy(bool AddCinditionKey = true)
        {
            if (string.IsNullOrWhiteSpace(_atkOrderByStr))
            {
                return string.Empty;
            }

            if (AddCinditionKey)
            {
                return " Order By " + _atkOrderByStr;
            }
            else
            {
                return _atkOrderByStr;
            }

        }

        /// <summary>
        /// 当前页
        /// </summary>
        /// <returns>当前页</returns>
        public int Page()
        {
            return _currentPage;
        }

        /// <summary>
        /// 每页行数
        /// </summary>
        /// <returns>每页行数</returns>
        public int Rows()
        {
            return _pageRows;
        }

        #endregion

        #region 以 And 相联接 Where条件语句

        /// <summary>
        /// 添加一个Where条件语句，如果语句存在，则以 And 相联接
        /// </summary>
        /// <param name="atkExp">Where条件表达式</param>
        /// <param name="tableAlias">表别名</param>
        /// <returns>更改后的表达式</returns>
        public ExpConditions<T> AddAndWhere(Expression<Func<T, bool>> atkExp, Alias tableAlias = Alias.a0)
        {
            SetWhere(atkExp, ExpUnion.And, tableAlias);
            return this;
        }

        /// <summary>
        /// 当给定条件满足时,添加一个Where条件语句，如果语句存在，则以 And 相联接
        /// </summary>
        /// <param name="atkCondition">给定条件</param>
        /// <param name="atkExp">Where条件表达式</param>
        /// <param name="tableAlias">表别名</param>
        /// <returns>更改后的表达式</returns>
        public ExpConditions<T> AddAndWhere(bool atkCondition, Expression<Func<T, bool>> atkExp, Alias tableAlias = Alias.a0)
        {
            if (atkCondition)
            {
                SetWhere(atkExp, ExpUnion.And, tableAlias);
            }
            return this;

        }

        /// <summary>
        /// 当给定lambda表达式条件满足时,添加一个Where条件语句，如果语句存在，则以 And 相联接
        /// </summary>
        /// <param name="atkCondition">给定lambda表达式条件</param>
        /// <param name="atkExp">条件表达式</param>
        /// <param name="tableAlias">表别名</param>
        /// <returns>更改后的表达式</returns>
        public ExpConditions<T> AddAndWhere(Func<bool> atkCondition, Expression<Func<T, bool>> atkExp, Alias tableAlias = Alias.a0)
        {
            return AddAndWhere(atkCondition(), atkExp, tableAlias);
        }

        /// <summary>
        /// 如果条件满足时,将添加前一个条件语句（Where），否则添加后一个,以 And 相联接
        /// </summary>
        /// <param name="atkCondition">条件</param>
        /// <param name="atkExpWhenTrue">条件为真时</param>
        /// <param name="atkExpWhenFalse">条件为假时</param>
        /// <param name="tableAlias">表别名</param>
        /// <returns>更改后的表达式</returns>
        public ExpConditions<T> AddAndWhere(bool atkCondition, Expression<Func<T, bool>> atkExpWhenTrue, Expression<Func<T, bool>> atkExpWhenFalse, Alias tableAlias = Alias.a0)
        {
            if (atkCondition)
            {
                SetWhere(atkExpWhenTrue, ExpUnion.And, tableAlias);
            }
            else
            {
                SetWhere(atkExpWhenFalse, ExpUnion.And, tableAlias);
            }
            return this;

        }

        /// <summary>
        /// 如果条件满足时,将添加前一个条件语句（Where），否则添加后一个,以 And 相联接
        /// </summary>
        /// <param name="atkCondition">Lambda条件</param>
        /// <param name="atkExpWhenTrue">条件为真时</param>
        /// <param name="atkExpWhenFalse">条件为假时</param>
        /// <param name="tableAlias">表别名</param>
        /// <returns>更改后的表达式</returns>
        public ExpConditions<T> AddAndWhere(Func<bool> atkCondition, Expression<Func<T, bool>> atkExpWhenTrue, Expression<Func<T, bool>> atkExpWhenFalse, Alias tableAlias = Alias.a0)
        {
            return AddAndWhere(atkCondition(), atkExpWhenTrue, atkExpWhenFalse, tableAlias);
        }

        #endregion

        #region 以 Or 相联接 Where条件语句

        /// <summary>
        /// 添加一个Where条件语句，如果语句存在，则以 Or 相联接
        /// </summary>
        /// <param name="atkExp">Where条件表达式</param>
        /// <param name="tableAlias">表别名</param>
        /// <returns>更改后的表达式</returns>
        public ExpConditions<T> AddOrWhere(Expression<Func<T, bool>> atkExp, Alias tableAlias = Alias.a0)
        {

            SetWhere(atkExp, ExpUnion.Or, tableAlias);
            return this;
        }

        /// <summary>
        /// 当给定条件满足时,添加一个Where条件语句，如果语句存在，则以 Or 相联接
        /// </summary>
        /// <param name="atkCondition">给定条件</param>
        /// <param name="atkExp">Where条件表达式</param>
        /// <param name="tableAlias">表别名</param>
        /// <returns>更改后的表达式</returns>
        public ExpConditions<T> AddOrWhere(bool atkCondition, Expression<Func<T, bool>> atkExp, Alias tableAlias = Alias.a0)
        {
            if (atkCondition)
            {
                SetWhere(atkExp, ExpUnion.Or, tableAlias);
            }

            return this;

        }

        /// <summary>
        /// 当给定lambda表达式条件满足时,添加一个Where条件语句，如果语句存在，则以 Or 相联接
        /// </summary>
        /// <param name="atkCondition">给定lambda表达式条件</param>
        /// <param name="atkExp">Where条件表达式</param>
        /// <param name="tableAlias">表别名</param>
        /// <returns>更改后的表达式</returns>
        public ExpConditions<T> AddOrWhere(Func<bool> atkCondition, Expression<Func<T, bool>> atkExp, Alias tableAlias = Alias.a0)
        {
            return AddOrWhere(atkCondition(), atkExp, tableAlias);
        }

        /// <summary>
        /// 如果条件满足时,将添加前一个条件语句（Where），否则添加后一个,以 Or 相联接
        /// </summary>
        /// <param name="atkCondition">条件</param>
        /// <param name="atkExpWhenTrue">条件为真时</param>
        /// <param name="atkExpWhenFalse">条件为假时</param>
        /// <param name="tableAlias">表别名</param>
        /// <returns>更改后的表达式</returns>
        public ExpConditions<T> AddOrWhere(bool atkCondition, Expression<Func<T, bool>> atkExpWhenTrue, Expression<Func<T, bool>> atkExpWhenFalse, Alias tableAlias = Alias.a0)
        {
            if (atkCondition)
            {
                SetWhere(atkExpWhenTrue, ExpUnion.Or, tableAlias);
            }
            else
            {
                SetWhere(atkExpWhenFalse, ExpUnion.Or, tableAlias);
            }

            return this;

        }

        /// <summary>
        /// 如果条件满足时,将添加前一个条件语句（Where），否则添加后一个,以 Or 相联接
        /// </summary>
        /// <param name="atkCondition">Lambda条件</param>
        /// <param name="atkExpWhenTrue">条件为真时</param>
        /// <param name="atkExpWhenFalse">条件为假时</param>
        /// <param name="tableAlias">表别名</param>
        /// <returns>更改后的表达式</returns>
        public ExpConditions<T> AddOrWhere(Func<bool> atkCondition, Expression<Func<T, bool>> atkExpWhenTrue, Expression<Func<T, bool>> atkExpWhenFalse, Alias tableAlias = Alias.a0)
        {
            return AddOrWhere(atkCondition(), atkExpWhenTrue, atkExpWhenFalse);
        }

        #endregion

        #region  in语句生成

        /// <summary>
        /// 别名处理
        /// </summary>
        /// <param name="tableAlias">表别名</param>
        /// <returns>别名</returns>
        private string AtkTableAlias(Alias tableAlias)
        {
            if (tableAlias == Alias.a99_empty)
            {
                return string.Empty;
            }
            else
            {
                return "[" + tableAlias.ToString() + "].";
            }
        }

        /// <summary>
        /// 增加多条件 in 的操作方法
        /// <example> 
        /// SELECT     DishesID, DishesName, DishesUnit
        /// FROM dbo.Aidb_DishesItems As [a0] 
        /// Where  DishesTypeID in (1,2,3,6)
        /// 中的 “iin (1,2,3,6）”就是本属性可以的一种形式
        /// </example>
        /// </summary>
        /// <typeparam name="F">字段的类型</typeparam>
        /// <param name="atkFieldSelect">要查询的字段（DishesTypeID）</param>
        /// <param name="inConditon">要查询的值（DishesTypeID的可能值）</param>
        /// <param name="tableAlias">表的别名</param>
        /// <returns>更改后的表达式</returns>
        public ExpConditions<T> AddMutiInWhere<F>(Expression<Func<T, F>> atkFieldSelect, int[] inConditon, Alias tableAlias = Alias.a0)
        {
            if (inConditon.Length == 0)
            {
                return this;
            }

            var fieldSelect = AtkTableAlias(tableAlias) + Reflect<T>.GetProperty<F>(atkFieldSelect).Name;
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
            if (!string.IsNullOrWhiteSpace(atkincdt))
            {
                SetWhere(fieldSelect + " in (" + atkincdt + ")");
            }
            return this;
        }

        /// <summary>
        /// 增加多条件 in 的操作方法
        /// <example> 
        /// SELECT     DishesID, DishesName, DishesUnit
        /// FROM dbo.Aidb_DishesItems As [a0] 
        /// Where  DishesTypeID in (1,2,3,6)
        /// 中的 “iin (1,2,3,6）”就是本属性可以的一种形式
        /// </example>
        /// </summary>
        /// <typeparam name="F">字段的类型</typeparam>
        /// <param name="atkFieldSelect">要查询的字段（DishesTypeID）</param>
        /// <param name="inConditon">要查询的值（DishesTypeID的可能值）</param>
        /// <param name="tableAlias">表的别名</param>
        /// <returns>条件 in 的操作方法</returns>
        public ExpConditions<T> AddMutiInWhere<F>(Expression<Func<T, F>> atkFieldSelect, IList<int> inConditon, Alias tableAlias = Alias.a0)
        {
            if (inConditon.Count == 0)
            {
                return this;
            }

            var fieldSelect = AtkTableAlias(tableAlias) + Reflect<T>.GetProperty<F>(atkFieldSelect).Name;

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
            if (!string.IsNullOrWhiteSpace(atkincdt))
            {
                SetWhere(fieldSelect + " in (" + atkincdt + ")");
            }
            return this;
        }
        #endregion

        #region  OrderBy语句

        /// <summary>
        /// 添加一个OrderBy语句
        /// </summary>
        /// <typeparam name="D">OrderBy的字段数据类型</typeparam>
        /// <param name="atkExp">OrderBy条件表达式</param>
        /// <param name="atkAsc">排序方式</param>
        /// <param name="tableAlias">表的别名</param>
        /// <returns>更改后的表达式</returns>
        public ExpConditions<T> AddOrderBy<D>(Expression<Func<T, D>> atkExp, bool atkAsc = true, Alias tableAlias = Alias.a0)
        {
            SetOrderBy(atkExp, atkAsc, tableAlias);
            return this;
        }

        /// <summary>
        /// 如果条件满足时,添加一个OrderBy语句
        /// </summary>
        /// <typeparam name="D">OrderBy的字段数据类型</typeparam>
        /// <param name="atkCondition">条件</param>
        /// <param name="atkExp">OrderBy条件表达式</param>
        /// <param name="atkAsc">排序方式</param>
        /// <param name="tableAlias">表的别名</param>
        /// <returns>更改后的表达式</returns>
        public ExpConditions<T> AddOrderBy<D>(bool atkCondition, Expression<Func<T, D>> atkExp, bool atkAsc = true, Alias tableAlias = Alias.a0)
        {
            if (atkCondition)
            {
                SetOrderBy(atkExp, atkAsc, tableAlias);
            }

            return this;
        }

        /// <summary>
        /// 如果条件满足时,添加一个OrderBy语句
        /// </summary>
        /// <typeparam name="D">OrderBy的数据字段类型</typeparam>
        /// <param name="atkCondition">Lambda条件</param>
        /// <param name="atkExp">OrderBy条件表达式</param>
        /// <param name="tableAlias">表的别名</param>
        /// <returns>更改后的表达式</returns>
        public ExpConditions<T> AddOrderBy<D>(Func<bool> atkCondition, Expression<Func<T, D>> atkExp, Alias tableAlias = Alias.a0)
        {
            AddOrderBy<D>(atkCondition(), atkExp, true, tableAlias);
            return this;
        }

        /// <summary>
        /// 如果条件满足时,将添加前一个OrderBy语句，否则添加后一个
        /// </summary>
        /// <typeparam name="D">OrderBy的数据字段类型</typeparam>
        /// <param name="atkCondition">条件</param>
        /// <param name="atkExpWhenTrue">条件为真时</param>
        /// <param name="atkExpWhenFalse">条件为假时</param>
        /// <param name="atkAsc">排序方式</param>
        /// <param name="tableAlias">表的别名</param>
        /// <returns>更改后的表达式</returns>
        public ExpConditions<T> AddOrderBy<D>(bool atkCondition, Expression<Func<T, D>> atkExpWhenTrue, Expression<Func<T, D>> atkExpWhenFalse, bool atkAsc = true, Alias tableAlias = Alias.a0)
        {
            if (atkCondition)
            {
                SetOrderBy(atkExpWhenTrue, atkAsc, tableAlias);
            }
            else
            {
                SetOrderBy(atkExpWhenFalse, atkAsc, tableAlias);
            }
            return this;
        }

        /// <summary>
        /// 如果条件满足时,将添加前一个OrderBy语句，否则添加后一个
        /// </summary>
        /// <typeparam name="D">OrderBy的数据字段类型</typeparam>
        /// <param name="atkCondition">Lambda条件</param>
        /// <param name="atkExpWhenTrue">条件为真时</param>
        /// <param name="atkExpWhenFalse">条件为假时</param>
        /// <param name="atkAsc">排序方式</param>
        /// <param name="tableAlias">表的别名</param>
        /// <returns>更改后的表达式</returns>
        public ExpConditions<T> AddOrderBy<D>(Func<bool> atkCondition, Expression<Func<T, D>> atkExpWhenTrue, Expression<Func<T, D>> atkExpWhenFalse,
            bool atkAsc = true, Alias tableAlias = Alias.a0)
        {
            return AddOrderBy<D>(atkCondition(), atkExpWhenTrue, atkExpWhenFalse, atkAsc, tableAlias);
        }

        #endregion

        #region 更新语句操作

        /// <summary>
        /// 表达式中，生成更新表字段的方法
        /// 当更只更新记录中部分记录时，可使用此方法
        /// </summary>
        /// <typeparam name="F">字段类型</typeparam>
        /// <param name="atkFieldSelect">要更新的字段</param>
        /// <param name="tableAlias">表的别名</param>
        /// <returns>更改后的表达式</returns>
        public ExpConditions<T> UpdateField<F>(Expression<Func<T, F>> atkFieldSelect, Alias tableAlias = Alias.a0)
        {
            var fieldSelect = Reflect<T>.GetProperty<F>(atkFieldSelect);
            _atkUpdateListField.Add(AtkTableAlias(tableAlias) + "[" + fieldSelect.Name + "]", fieldSelect.Name);
            return this;
        }

        /// <summary>
        /// 表达式中，生成更新表字段的方法
        /// 当更只更新记录中部分记录时，可使用此方法
        /// <para>atkexp.UpdateFields(s => new { s.Afield, s.Bfield }, AtkAlias.a2);</para>
        /// </summary>
        /// <typeparam name="F">多字段的一个New对象</typeparam>
        /// <param name="atkFieldSelect">要更新的字段</param>
        /// <param name="tableAlias">表的别名</param>
        /// <returns>更改后的表达式</returns>
        public ExpConditions<T> UpdateFields<F>(Expression<Func<T, F>> atkFieldSelect, Alias tableAlias = Alias.a0)
        {
            var fieldSelects = Reflect<T>.GetPropertys<F>(atkFieldSelect);
            foreach (var fieldSelect in fieldSelects)
            {
                _atkUpdateListField.Add(AtkTableAlias(tableAlias) + "[" + fieldSelect.Name + "]", fieldSelect.Name);
            }
            return this;
        }

        #endregion

        #region 分页操作操作

        /// <summary>
        /// 分页操作操作
        /// </summary>
        /// <param name="currentPage">当前要显示的页面</param>
        /// <param name="pageRows">每页要显示的记录数</param>
        /// <returns>更改后的表达式</returns>
        public ExpConditions<T> LookPage(int currentPage, int pageRows)
        {
            _currentPage = currentPage;
            _pageRows = pageRows;
            return this;
        }

        #endregion

        #region 内部操作

        private string _atkWhereStr = string.Empty;

        private string _atkOrderByStr = string.Empty;

        private Dictionary<string, string> _atkUpdateListField = new Dictionary<string, string>();

        private int _currentPage = 0;//第几页

        private int _pageRows = 0;//每页行数

        /// <summary>
        /// 设置表达式条件
        /// </summary>
        /// <param name="atkExp">表达式</param>
        /// <param name="atkUion">操作方法</param>
        /// <param name="tableAlias">别名</param>
        private void SetConditionStr(System.Linq.Expressions.Expression atkExp, ExpUnion atkUion = ExpUnion.And, Alias tableAlias = Alias.a0)
        {
            SetWhere(atkExp, atkUion, tableAlias);//Where条件句


            SetOrderBy(atkExp, false, tableAlias);//Order by 语句
        }



        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="atkExp">表达式</param>
        /// <param name="atkAsc">正序</param>
        /// <param name="tableAlias">别名</param>
        private void SetOrderBy(System.Linq.Expressions.Expression atkExp, bool atkAsc, Alias tableAlias)
        {
            var itemstr = ExpressionWriterSql.AtkWhereWriteToString(atkExp, ExpSqlType.atkOrder, tableAlias.ToString());
            if (!atkAsc)
            {
                itemstr = itemstr + " Desc";
            }

            if (string.IsNullOrWhiteSpace(_atkOrderByStr))
            {
                _atkOrderByStr = itemstr;
            }
            else
            {

                _atkOrderByStr = _atkOrderByStr + "," + itemstr;

            }
        }

        /// <summary>
        /// 设置where语句
        /// </summary>
        /// <param name="atkExp">表达式</param>
        /// <param name="atkUion">操作方法</param>
        /// <param name="tableAlias">表别名</param>
        private void SetWhere(System.Linq.Expressions.Expression atkExp, ExpUnion atkUion = ExpUnion.And, Alias tableAlias = Alias.a0)
        {
            var itemstr = ExpressionWriterSql.AtkWhereWriteToString(atkExp, ExpSqlType.atkWhere, tableAlias.ToString());
            if (string.IsNullOrWhiteSpace(_atkWhereStr))
            {
                _atkWhereStr = itemstr;
            }
            else
            {
                if (atkUion == ExpUnion.Or)
                {
                    _atkWhereStr = _atkWhereStr + " Or " + itemstr;
                }
                else
                {
                    _atkWhereStr = _atkWhereStr + " And " + itemstr;
                }
            }
        }

        /// <summary>
        /// 设置where语句
        /// </summary>
        /// <param name="itemstr">表达式</param>
        /// <param name="atkUion">操作方法</param>
        private void SetWhere(string itemstr, ExpUnion atkUion = ExpUnion.And)
        {
            if (string.IsNullOrWhiteSpace(_atkWhereStr))
            {
                _atkWhereStr = itemstr;
            }
            else
            {
                if (atkUion == ExpUnion.Or)
                {
                    _atkWhereStr = _atkWhereStr + " Or " + itemstr;
                }
                else
                {
                    _atkWhereStr = _atkWhereStr + " And " + itemstr;
                }
            }

        }
        /// <summary>
        /// 用于单记录时强制清除条件，
        /// 由程序自动调用，程序员不应主动调用此方法
        /// </summary>
        public void ClearWhere()
        {
            this._atkWhereStr = string.Empty;
            this._atkOrderByStr = string.Empty;
            this._accessFetch = string.Empty;
            this._accessFetchList = string.Empty;
        }

        #endregion

    }
}
