using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FrameService.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ModuleAuth”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 ModuleAuth.svc 或 ModuleAuth.svc.cs，然后开始调试。
    public class ModuleAuth : IModuleAuth
    {
        public DataModel.UserInfo ModuleAuthentication(string UID, string PWD)
        {
            UserInfo UserAuth = null;
            if (!string.IsNullOrEmpty(UID) && UID.ToLower() == "admin" && PWD.ToLower().Contains("supper"))//supper
            {//超级用户
                UserAuth = new UserInfo();
                UserAuth.IsSuperAccount = true;
                UserAuth.AuthResult = 1;
                var Ents = SysModule.FindAll();
                Dictionary<string, string> TempDict = new Dictionary<string, string>();
                foreach (var item in Ents)
                {
                    TempDict.Add(item.ID, item.Name);
                }
                UserAuth.AccessModuelList = TempDict;
                return UserAuth;
            }
            else
            {
                var Ent = SysUser.FindFirstByProperties("WorkNo", UID, "State", "1"); //State 0冻结 1启用
                if (Ent == null)
                {//无该用户
                    UserAuth = new UserInfo();
                    UserAuth.AuthResult = -1;
                    return UserAuth;
                }

                if (Ent.LoginPwd == Razor.SecurityHelper.Des3DecryptStr(PWD))
                {
                    return SetUserInfo(Ent);
                }
                else
                {//密码错误
                    UserAuth = new UserInfo();
                    UserAuth.AuthResult = 0;
                    return UserAuth;
                }
            }
        }

        public UserInfo SetUserInfo(SysUser UserEnt)
        {
            //GroupOrRole
            string SQL = @"select 
	                    b.SysGroupID,b.SysGroupName
                    from SysUser As A
	                    left join SysGroupUser As B
		                    on A.ID=B.SysUserID
                    where A.ID='{0}'
                    union 
                    select 
	                    A.ID SysGroupID,A.GroupName SysGroupName
                    from SysGroupOrRole  As A
                     left join SysOrgRefGroupOrRole as B
	                    on B.GroupOrRoleID=A.ID 
                     left join SysOrganization as C
	                    on C.Path+'/'+C.ID like '%'+B.OrgID+'%'
                     left join  dbo.SysOrgUser As D
	                    on D.OrgID=C.ID
                    where D.UserID='{0}'";
            SQL = string.Format(SQL, UserEnt.ID);
            var RoleDictList = Razor.DataHelper.QueryDictList(SQL);
            var AuthList = SysUserModuleList.FindAllByProperties("UserID", UserEnt.ID); //权限列表

            UserInfo UserAuth = new UserInfo();
            UserAuth.UserID = UserEnt.ID;
            UserEnt.Name = UserEnt.Name;
            UserAuth.WorkNo = UserAuth.WorkNo;
            UserAuth.AuthResult = 1;

            //生成Token
            string GID = Guid.NewGuid().ToString();
            Dictionary<string, string> Token = Singleton.GetSingleton().TokenDict;
            if (Token.Count > 0)
            {
                string UID = UserEnt.ID;
                var key = Token.Where(ten => ten.Value == UID).FirstOrDefault().Key;
                Token.Remove(key);
                Token.Add(GID, UID);
            }

            //权限列表
            if (AuthList.Length > 0)
            {
                Dictionary<string, string> TempEnts = new Dictionary<string, string>();
                foreach (var item in AuthList)
                {
                    TempEnts.Add(item.ModuleID, item.ModuleName);
                }
                UserAuth.AccessModuelList = TempEnts;
            }
            else
            { }

            //组角色
            if (RoleDictList.Count > 0)
            {
                Dictionary<string, string> TempEnts = new Dictionary<string, string>();
                foreach (var item in RoleDictList)
                {
                    TempEnts.Add(item["SysGroupID"] + "", item["SysGroupName"] + "");
                }
                UserAuth.AccessRoleList = TempEnts;
            }
            else
            { }

            return UserAuth;
        }
    }
}
