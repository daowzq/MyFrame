﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34209
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HDFrame.FrameServices {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FrameServices.ICreateUserModuleList")]
    public interface ICreateUserModuleList {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateUserModuleList/CreateModuleList", ReplyAction="http://tempuri.org/ICreateUserModuleList/CreateModuleListResponse")]
        void CreateModuleList();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICreateUserModuleListChannel : HDFrame.FrameServices.ICreateUserModuleList, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CreateUserModuleListClient : System.ServiceModel.ClientBase<HDFrame.FrameServices.ICreateUserModuleList>, HDFrame.FrameServices.ICreateUserModuleList {
        
        public CreateUserModuleListClient() {
        }
        
        public CreateUserModuleListClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CreateUserModuleListClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CreateUserModuleListClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CreateUserModuleListClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void CreateModuleList() {
            base.Channel.CreateModuleList();
        }
    }
}
