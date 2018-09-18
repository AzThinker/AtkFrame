using System;
using System.Collections.Generic;


namespace Atk.DataPortal
{
    /// <summary>
    /// 参数结果类
    /// </summary>
    [Serializable]
    public sealed class OperateState
    {
        /// <summary>
        /// 错误信息集
        /// </summary>
        private Dictionary<string, string> _error;

        /// <summary>
        /// 错误信息集
        /// </summary>
        public Dictionary<string, string> Error
        {
            get { return _error; }
            set { _error = value; }
        }


        /// <summary>
        /// 操作SqlCommand所受影响的行数
        /// </summary>
        private int _affectedRows;

        /// <summary>
        /// 操作SqlCommand所受影响的行数
        /// </summary>
        public int AffectedRows
        {
            get { return _affectedRows; }
            set { _affectedRows = value; }
        }

        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool IsSuccess
        {
            get
            {
                return Error.Count == 0;
            }
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        public OperateState()
        {
            Error = new Dictionary<string, string>();
            AffectedRows = 0;
        }

        /// <summary>
        /// 操作失败状态
        /// </summary>
        /// <param name="errmsg">错误消息</param>
        /// <returns>失败状态</returns>
        public static OperateState FailState(string errmsg)
        {
            var result = new OperateState();

            result.Error.Add("调用失败！", errmsg);

            return result;
        }
    }

}
