using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace HDFrame.Common
{
    public class PagingStruct
    {

        private static int temp_limit;
        private static int temp_page;
        private static int temp_start;
        public static int PageSize
        {
            get
            {
                if (HttpContext.Current.Request["limit"] == null)
                {
                    return 0;
                }
                else
                {
                    temp_limit = int.Parse(HttpContext.Current.Request["limit"] + "");
                    return temp_limit;
                }
            }
            set
            {
                PageSize = value;
            }
        }

        /// <summary>
        /// 第几页
        /// </summary>
        public static int Page
        {
            get
            {
                if (HttpContext.Current.Request["page"] == null)
                {
                    return 0;
                }
                else
                {
                    temp_page = int.Parse(HttpContext.Current.Request["page"] + "");
                    return temp_page;
                }
            }
            set
            {
                Page = value;
            }
        }

        /// <summary>
        /// 数据开始的位置
        /// </summary>
        public static int Start
        {
            get
            {
                if (HttpContext.Current.Request["start"] == null)
                {
                    return 0;
                }
                else
                {
                    temp_start = int.Parse(HttpContext.Current.Request["start"] + "");
                    return temp_start;
                }
            }
            set
            {
                Start = value;
            }
        }

        /// <summary>
        /// 数据结束的位置
        /// </summary>
        public static int End
        {
            get
            {
                return Start + temp_limit;
            }
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        public static string search
        {
            get
            {
                if (HttpContext.Current.Request["search"] == null)
                {
                    return null;
                }
                else
                {
                    return HttpContext.Current.Request["search"] + "";
                }
            }
        }
    }
}