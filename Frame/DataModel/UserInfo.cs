using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel
{
    /// <summary>
    /// 用户权限信息
    /// </summary>
    [Serializable]
    public class UserInfo
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string WorkNo { get; set; }

        /// <summary>
        /// 超级管理员用户
        /// </summary>
        public bool IsSuperAccount { get; set; }
        /// <summary>
        /// 授权结果 0 密码错误 -1 无该用户 1 用户密码正确
        /// </summary>
        public int AuthResult { get; set; }

        /// <summary>
        /// 授权标识ID
        /// </summary>
        public string AuthTokenID { get; set; }

        /// <summary>
        /// 可访问的模块
        /// </summary>
        public Dictionary<string, string> AccessModuelList { get; set; }

        /// <summary>
        /// 所在组角色
        /// </summary>
        public Dictionary<string, string> AccessRoleList { get; set; }

    }
}
