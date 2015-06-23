using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Transactions;

namespace FrameService.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“CreateUserModuleList”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 CreateUserModuleList.svc 或 CreateUserModuleList.svc.cs，然后开始调试。
    public class CreateUserModuleList : ICreateUserModuleList
    {
        public void CreateModuleList()
        {
            // B.Path+'/'+B.ID 可以去掉. WGM:(2015-6-13)
            string SQL = @" insert into SysUserModuleList(ID,CreateTime,ModuleID,ModuleName,UserID,UserName)
                            select NEWID() ID,GETDATE() CreateTime, T.* from  (
                            --组织结构
                            select  A.ModuleID,A.ModuleName,
                                    C.UserID,C.UserName 
                            from SysOrgAuth As A
                             left join  dbo.SysOrganization  As B
                                on  B.Path+'/'+B.ID like '%'+A.OrgID+'%'
                             left join  SysOrgUser as C
                                on C.OrgID=B.ID 
                            where C.UserID is not null
                            union
                            --角色与组
                            select A.ModuleID,A.ModuleName,
                                   C.SysUserID UserID ,C.SysUserName UserName
                                from SysGroupAuth As A
                             left join SysGroupOrRole  As B
                                on A.GroupID=B.ID
                             left join SysGroupUser as C
                                on C.SysGroupID=B.ID 
                            where C.SysUserID is not null 
                            union  
                            select  A.ModuleID,A.ModuleName,
                                    F.UserID,F.UserName
                                from SysGroupAuth As A
                             left join SysGroupOrRole  As B
                                on A.GroupID=B.ID
                             left join SysOrgRefGroupOrRole as C
                                on C.GroupOrRoleID=B.ID 
                             left join SysOrganization as D
                                on D.Path+'/'+D.ID like '%'+C.OrgID+'%'
                             left join  dbo.SysOrgUser As F
                                on F.OrgID=D.ID
                            where F.UserID is not null
                            union 
                            --人员
                            select 
                                A.ModuleID,A.ModuleName,A.ModuleID,A.UserName
                             from SysUserAuth As A
                            ) as T;";

            string UpdateSQL = @"update SysUserModuleList set ModulePath=B.Path
                                from ( select * from SysModule ) as B
                                where SysUserModuleList.ModuleID=B.ID;";
            string DeleteSQL = "delete from SysUserModuleList;";

            TransactionOptions transactionOption = new TransactionOptions();

            //设置事务隔离级别
            transactionOption.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;

            // 设置事务超时时间为60秒
            transactionOption.Timeout = new TimeSpan(0, 0, 60);

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOption))
            {
                //以上语句在执行事务,会有问题
                //SysUserModuleList.DeleteAll(); //先删除
                //Razor.DataHelper.ExecSp(DeleteSQL);//先删除
                //Razor.DataHelper.ExecSql(UpdateSQL); //更新Path

                Razor.DataHelper.ExecSql(DeleteSQL + SQL + UpdateSQL);
                scope.Complete();
            }
        }
    }
}
