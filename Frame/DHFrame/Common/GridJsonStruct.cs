using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace HDFrame.Common
{
    /// <summary>
    /// Grid需要的Json数据结构
    /// </summary>
    public class GridJsonStruct
    {
        private int _total;
        private object _items;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="_total">数据条数</param>
        public GridJsonStruct(DataTable dt, int _total)
        {
            if (dt != null)
                this.items = dt;
            this.total = _total;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj">数据集对象</param>
        /// <param name="_total">数据条数</param>
        public GridJsonStruct(object obj, int _total)
        {
            if (obj != null)
                this.items = obj;
            this.total = _total;
        }

        /// <summary>
        /// 获取条数
        /// </summary>
        public int total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
            }
        }
        /// <summary>
        /// 获取数据集
        /// </summary>
        public object items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
            }
        }
        /// <summary>
        /// 用于扩展
        /// </summary>
        public string extend { get; set; }
    }
}