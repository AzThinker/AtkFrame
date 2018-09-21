using System;

namespace Atk.DataPortal.UiServer
{
    /// <summary>
    /// WebDto的基类
    /// </summary>
    public abstract partial class BaseEntity
    {



        /// <summary>
        /// 实例类型Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 相等
        /// </summary>
        /// <param name="obj">判断对象</param>
        /// <returns>相等时为真</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as BaseEntity);
        }

        /// <summary>
        /// 是否使用事务
        /// </summary>
        /// <param name="obj">业务类</param>
        /// <returns>返回结果</returns>
        private static bool IsTransient(BaseEntity obj)
        {
            return obj != null && Equals(obj.Id, default(int));
        }

        /// <summary>
        /// 获取类型字串（NOP）
        /// </summary>
        /// <returns>返回结果</returns>
        private Type GetUnproxiedType()
        {
            return GetType();
        }

        /// <summary>
        /// 获取特性类型字串（NOP）
        /// </summary>
        /// <returns>返回结果</returns>
        public virtual string GetUnproxiedEntityType()
        {
            return "BaseEntity";
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="other">对比对象</param>
        /// <returns>相等是为真</returns>
        public virtual bool Equals(BaseEntity other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (!IsTransient(this) &&
                !IsTransient(other) &&
                Equals(Id, other.Id))
            {
                var otherType = other.GetUnproxiedType();
                var thisType = GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) ||
                        otherType.IsAssignableFrom(thisType);
            }

            return false;
        }

        /// <summary>
        /// 获取哈希值
        /// </summary>
        /// <returns>返回结果</returns>
        public override int GetHashCode()
        {
            if (Equals(Id, default(int)))
                return base.GetHashCode();
            return Id.GetHashCode();
        }

        /// <summary>
        /// 重载相等（NOP）
        /// </summary>
        /// <param name="x">实例对象X</param>
        /// <param name="y">实例对象Y</param>
        /// <returns>相等是为真</returns>
        public static bool operator ==(BaseEntity x, BaseEntity y)
        {
            return Equals(x, y);
        }

        /// <summary>
        /// 重载不不等操作（NOP）
        /// </summary>
        /// <param name="x">实例对象X</param>
        /// <param name="y">实例对象Y</param>
        /// <returns>返回结果</returns>
        public static bool operator !=(BaseEntity x, BaseEntity y)
        {
            return !(x == y);
        }


        /// <summary>
        /// 路踪路径，用于检查数据来源
        /// </summary>
        private string _accessPath;

        /// <summary>
        /// 路踪路径，用于检查数据来源
        /// </summary>
        public void SetAccessPath(string accessPath)
        {
            _accessPath = accessPath;
        }


        /// <summary>
        /// 路踪路径，用于检查数据来源
        /// </summary>
        public string GetAccessPath()
        {
            return _accessPath;
        }

        /// <summary>
        /// 访问地址
        /// </summary>
        private string _accessAddress;


        /// <summary>
        /// 访问地址
        /// </summary>
        public void SetAccessAddress(string accessAddress)
        {
            _accessAddress = accessAddress;
        }

        /// <summary>
        /// 访问地址
        /// </summary>
        public string GetAccessAddress()
        {
            return _accessAddress;
        }
    }
}
