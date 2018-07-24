﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Club.Services.PushServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SendMessage", Namespace="http://schemas.datacontract.org/2004/07/PushConsumer.Services.Module")]
    [System.SerializableAttribute()]
    public partial class SendMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int BadgeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TokenField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Badge {
            get {
                return this.BadgeField;
            }
            set {
                if ((this.BadgeField.Equals(value) != true)) {
                    this.BadgeField = value;
                    this.RaisePropertyChanged("Badge");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Token {
            get {
                return this.TokenField;
            }
            set {
                if ((object.ReferenceEquals(this.TokenField, value) != true)) {
                    this.TokenField = value;
                    this.RaisePropertyChanged("Token");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PushServiceReference.IPushService")]
    public interface IPushService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPushService/PushMessageForIOS", ReplyAction="http://tempuri.org/IPushService/PushMessageForIOSResponse")]
        void PushMessageForIOS(string certName, string certPassword, string token, string message, int badge);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPushService/PushMessageForIOS", ReplyAction="http://tempuri.org/IPushService/PushMessageForIOSResponse")]
        System.Threading.Tasks.Task PushMessageForIOSAsync(string certName, string certPassword, string token, string message, int badge);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPushService/PushMessageForIOSNoPWD", ReplyAction="http://tempuri.org/IPushService/PushMessageForIOSNoPWDResponse")]
        void PushMessageForIOSNoPWD(string token, string message, int badge);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPushService/PushMessageForIOSNoPWD", ReplyAction="http://tempuri.org/IPushService/PushMessageForIOSNoPWDResponse")]
        System.Threading.Tasks.Task PushMessageForIOSNoPWDAsync(string token, string message, int badge);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPushService/PushMessageForAndroidNoPWD", ReplyAction="http://tempuri.org/IPushService/PushMessageForAndroidNoPWDResponse")]
        void PushMessageForAndroidNoPWD(string token, string message, int badge);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPushService/PushMessageForAndroidNoPWD", ReplyAction="http://tempuri.org/IPushService/PushMessageForAndroidNoPWDResponse")]
        System.Threading.Tasks.Task PushMessageForAndroidNoPWDAsync(string token, string message, int badge);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPushService/PushMessagesForIOS", ReplyAction="http://tempuri.org/IPushService/PushMessagesForIOSResponse")]
        void PushMessagesForIOS(string certName, string certPassword, Club.Services.PushServiceReference.SendMessage[] messages);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPushService/PushMessagesForIOS", ReplyAction="http://tempuri.org/IPushService/PushMessagesForIOSResponse")]
        System.Threading.Tasks.Task PushMessagesForIOSAsync(string certName, string certPassword, Club.Services.PushServiceReference.SendMessage[] messages);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPushService/UMPushMessageIOSWithAll", ReplyAction="http://tempuri.org/IPushService/UMPushMessageIOSWithAllResponse")]
        void UMPushMessageIOSWithAll(string message, int badge, string function, int itemId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPushService/UMPushMessageIOSWithAll", ReplyAction="http://tempuri.org/IPushService/UMPushMessageIOSWithAllResponse")]
        System.Threading.Tasks.Task UMPushMessageIOSWithAllAsync(string message, int badge, string function, int itemId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPushService/UMPushMessageAndroidWithAll", ReplyAction="http://tempuri.org/IPushService/UMPushMessageAndroidWithAllResponse")]
        void UMPushMessageAndroidWithAll(string title, string ticker, string text, string function, int itemId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPushService/UMPushMessageAndroidWithAll", ReplyAction="http://tempuri.org/IPushService/UMPushMessageAndroidWithAllResponse")]
        System.Threading.Tasks.Task UMPushMessageAndroidWithAllAsync(string title, string ticker, string text, string function, int itemId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPushService/UMPushMessageIOSWithUni", ReplyAction="http://tempuri.org/IPushService/UMPushMessageIOSWithUniResponse")]
        void UMPushMessageIOSWithUni(string token, string message, int badge, string function, int itemId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPushService/UMPushMessageIOSWithUni", ReplyAction="http://tempuri.org/IPushService/UMPushMessageIOSWithUniResponse")]
        System.Threading.Tasks.Task UMPushMessageIOSWithUniAsync(string token, string message, int badge, string function, int itemId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPushService/UMPushMessageAndroidWithUni", ReplyAction="http://tempuri.org/IPushService/UMPushMessageAndroidWithUniResponse")]
        void UMPushMessageAndroidWithUni(string token, string title, string ticker, string text, string function, int itemId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPushService/UMPushMessageAndroidWithUni", ReplyAction="http://tempuri.org/IPushService/UMPushMessageAndroidWithUniResponse")]
        System.Threading.Tasks.Task UMPushMessageAndroidWithUniAsync(string token, string title, string ticker, string text, string function, int itemId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPushServiceChannel : Club.Services.PushServiceReference.IPushService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PushServiceClient : System.ServiceModel.ClientBase<Club.Services.PushServiceReference.IPushService>, Club.Services.PushServiceReference.IPushService {
        
        public PushServiceClient() {
        }
        
        public PushServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PushServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PushServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PushServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void PushMessageForIOS(string certName, string certPassword, string token, string message, int badge) {
            base.Channel.PushMessageForIOS(certName, certPassword, token, message, badge);
        }
        
        public System.Threading.Tasks.Task PushMessageForIOSAsync(string certName, string certPassword, string token, string message, int badge) {
            return base.Channel.PushMessageForIOSAsync(certName, certPassword, token, message, badge);
        }
        
        public void PushMessageForIOSNoPWD(string token, string message, int badge) {
            base.Channel.PushMessageForIOSNoPWD(token, message, badge);
        }
        
        public System.Threading.Tasks.Task PushMessageForIOSNoPWDAsync(string token, string message, int badge) {
            return base.Channel.PushMessageForIOSNoPWDAsync(token, message, badge);
        }
        
        public void PushMessageForAndroidNoPWD(string token, string message, int badge) {
            base.Channel.PushMessageForAndroidNoPWD(token, message, badge);
        }
        
        public System.Threading.Tasks.Task PushMessageForAndroidNoPWDAsync(string token, string message, int badge) {
            return base.Channel.PushMessageForAndroidNoPWDAsync(token, message, badge);
        }
        
        public void PushMessagesForIOS(string certName, string certPassword, Club.Services.PushServiceReference.SendMessage[] messages) {
            base.Channel.PushMessagesForIOS(certName, certPassword, messages);
        }
        
        public System.Threading.Tasks.Task PushMessagesForIOSAsync(string certName, string certPassword, Club.Services.PushServiceReference.SendMessage[] messages) {
            return base.Channel.PushMessagesForIOSAsync(certName, certPassword, messages);
        }
        
        public void UMPushMessageIOSWithAll(string message, int badge, string function, int itemId) {
            base.Channel.UMPushMessageIOSWithAll(message, badge, function, itemId);
        }
        
        public System.Threading.Tasks.Task UMPushMessageIOSWithAllAsync(string message, int badge, string function, int itemId) {
            return base.Channel.UMPushMessageIOSWithAllAsync(message, badge, function, itemId);
        }
        
        public void UMPushMessageAndroidWithAll(string title, string ticker, string text, string function, int itemId) {
            base.Channel.UMPushMessageAndroidWithAll(title, ticker, text, function, itemId);
        }
        
        public System.Threading.Tasks.Task UMPushMessageAndroidWithAllAsync(string title, string ticker, string text, string function, int itemId) {
            return base.Channel.UMPushMessageAndroidWithAllAsync(title, ticker, text, function, itemId);
        }
        
        public void UMPushMessageIOSWithUni(string token, string message, int badge, string function, int itemId) {
            base.Channel.UMPushMessageIOSWithUni(token, message, badge, function, itemId);
        }
        
        public System.Threading.Tasks.Task UMPushMessageIOSWithUniAsync(string token, string message, int badge, string function, int itemId) {
            return base.Channel.UMPushMessageIOSWithUniAsync(token, message, badge, function, itemId);
        }
        
        public void UMPushMessageAndroidWithUni(string token, string title, string ticker, string text, string function, int itemId) {
            base.Channel.UMPushMessageAndroidWithUni(token, title, ticker, text, function, itemId);
        }
        
        public System.Threading.Tasks.Task UMPushMessageAndroidWithUniAsync(string token, string title, string ticker, string text, string function, int itemId) {
            return base.Channel.UMPushMessageAndroidWithUniAsync(token, title, ticker, text, function, itemId);
        }
    }
}