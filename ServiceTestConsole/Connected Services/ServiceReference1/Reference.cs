﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceTestConsole.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/WcfService")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
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
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetListFilmsByIdActor", ReplyAction="http://tempuri.org/IService1/GetListFilmsByIdActorResponse")]
        DTO.FilmDTO[] GetListFilmsByIdActor(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetListFilmsByIdActor", ReplyAction="http://tempuri.org/IService1/GetListFilmsByIdActorResponse")]
        System.Threading.Tasks.Task<DTO.FilmDTO[]> GetListFilmsByIdActorAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetListCharacterByIdActorAndIdFilm", ReplyAction="http://tempuri.org/IService1/GetListCharacterByIdActorAndIdFilmResponse")]
        DTO.CharacterDTO[] GetListCharacterByIdActorAndIdFilm(int idfilm, int idactor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetListCharacterByIdActorAndIdFilm", ReplyAction="http://tempuri.org/IService1/GetListCharacterByIdActorAndIdFilmResponse")]
        System.Threading.Tasks.Task<DTO.CharacterDTO[]> GetListCharacterByIdActorAndIdFilmAsync(int idfilm, int idactor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/FindListFilmByPartialActorName", ReplyAction="http://tempuri.org/IService1/FindListFilmByPartialActorNameResponse")]
        DTO.FilmDTO[] FindListFilmByPartialActorName(string nomActor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/FindListFilmByPartialActorName", ReplyAction="http://tempuri.org/IService1/FindListFilmByPartialActorNameResponse")]
        System.Threading.Tasks.Task<DTO.FilmDTO[]> FindListFilmByPartialActorNameAsync(string nomActor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetFullActorDetailsByIdActor", ReplyAction="http://tempuri.org/IService1/GetFullActorDetailsByIdActorResponse")]
        DTO.FullActorDTO GetFullActorDetailsByIdActor(int i);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetFullActorDetailsByIdActor", ReplyAction="http://tempuri.org/IService1/GetFullActorDetailsByIdActorResponse")]
        System.Threading.Tasks.Task<DTO.FullActorDTO> GetFullActorDetailsByIdActorAsync(int i);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/InsertCommentOnActorId", ReplyAction="http://tempuri.org/IService1/InsertCommentOnActorIdResponse")]
        void InsertCommentOnActorId(DTO.CommentDTO comment, int ActorId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/InsertCommentOnActorId", ReplyAction="http://tempuri.org/IService1/InsertCommentOnActorIdResponse")]
        System.Threading.Tasks.Task InsertCommentOnActorIdAsync(DTO.CommentDTO comment, int ActorId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        ServiceTestConsole.ServiceReference1.CompositeType GetDataUsingDataContract(ServiceTestConsole.ServiceReference1.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<ServiceTestConsole.ServiceReference1.CompositeType> GetDataUsingDataContractAsync(ServiceTestConsole.ServiceReference1.CompositeType composite);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : ServiceTestConsole.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<ServiceTestConsole.ServiceReference1.IService1>, ServiceTestConsole.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public DTO.FilmDTO[] GetListFilmsByIdActor(int id) {
            return base.Channel.GetListFilmsByIdActor(id);
        }
        
        public System.Threading.Tasks.Task<DTO.FilmDTO[]> GetListFilmsByIdActorAsync(int id) {
            return base.Channel.GetListFilmsByIdActorAsync(id);
        }
        
        public DTO.CharacterDTO[] GetListCharacterByIdActorAndIdFilm(int idfilm, int idactor) {
            return base.Channel.GetListCharacterByIdActorAndIdFilm(idfilm, idactor);
        }
        
        public System.Threading.Tasks.Task<DTO.CharacterDTO[]> GetListCharacterByIdActorAndIdFilmAsync(int idfilm, int idactor) {
            return base.Channel.GetListCharacterByIdActorAndIdFilmAsync(idfilm, idactor);
        }
        
        public DTO.FilmDTO[] FindListFilmByPartialActorName(string nomActor) {
            return base.Channel.FindListFilmByPartialActorName(nomActor);
        }
        
        public System.Threading.Tasks.Task<DTO.FilmDTO[]> FindListFilmByPartialActorNameAsync(string nomActor) {
            return base.Channel.FindListFilmByPartialActorNameAsync(nomActor);
        }
        
        public DTO.FullActorDTO GetFullActorDetailsByIdActor(int i) {
            return base.Channel.GetFullActorDetailsByIdActor(i);
        }
        
        public System.Threading.Tasks.Task<DTO.FullActorDTO> GetFullActorDetailsByIdActorAsync(int i) {
            return base.Channel.GetFullActorDetailsByIdActorAsync(i);
        }
        
        public void InsertCommentOnActorId(DTO.CommentDTO comment, int ActorId) {
            base.Channel.InsertCommentOnActorId(comment, ActorId);
        }
        
        public System.Threading.Tasks.Task InsertCommentOnActorIdAsync(DTO.CommentDTO comment, int ActorId) {
            return base.Channel.InsertCommentOnActorIdAsync(comment, ActorId);
        }
        
        public ServiceTestConsole.ServiceReference1.CompositeType GetDataUsingDataContract(ServiceTestConsole.ServiceReference1.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<ServiceTestConsole.ServiceReference1.CompositeType> GetDataUsingDataContractAsync(ServiceTestConsole.ServiceReference1.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
    }
}
