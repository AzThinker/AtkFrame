using System;

namespace Atk.DataPortal.UiServer
{
    /// <summary>
    /// 分页Json结果
    /// </summary>
    public class JsonObjectResult
    {
        private object _bizJsonObject;
        /// <summary>
        /// 结果
        /// </summary>
        public object JsonObject { get { return _bizJsonObject; } }

        private int _bizTotleCount;
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotleCount { get { return _bizTotleCount; } }

        private int _bizPageCount;
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get { return _bizPageCount; } }

        private int _bizPage;
        /// <summary>
        /// 页码
        /// </summary>
        public int Page { get { return _bizPage; } }

        private int _bizRows;

        /// <summary>
        /// 每页分行数
        /// </summary>
        public int BizRows { get { return _bizRows; } }

        private JsonObjectResult(Object data, int Count, int Page, int Row)
        {

            _bizJsonObject = data;
            _bizPage = Page;
            _bizTotleCount = Count;
            _bizRows = Row;
            if (Row > 0)
            {
                _bizPageCount = Count % Row == 0 ? Count / Row : Count / Row + 1;
            }
            else
            {
                _bizPageCount = 0;
            }
        }

        /// <summary>
        /// 获取可用于JSON化的结果集
        /// </summary>
        /// <param name="data">结果集</param>
        /// <param name="Count">结果总记录数</param>
        /// <param name="Page">当前页</param>
        /// <param name="Row">每页分行数</param>
        /// <returns>返回结果</returns>
        public static JsonObjectResult Get(Object data, int Count, int Page, int Row)
        {
            return new JsonObjectResult(data, Count, Page, Row);
        }
    }
}
