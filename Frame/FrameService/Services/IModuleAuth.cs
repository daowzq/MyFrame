using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FrameService.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IModuleAuth”。
    [ServiceContract]
    public interface IModuleAuth
    {
        /// <summary>
        /// 权限认证
        /// </summary>
        /// <param name="UID"></param>
        /// <param name="PWD"></param>
        /// <returns></returns>
        [OperationContract]
        UserInfo ModuleAuthentication(string UID, string PWD);
    }
}
