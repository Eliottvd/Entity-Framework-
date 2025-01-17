﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DTO;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        List<FilmDTO> GetListFilmsByIdActor(int id);

        [OperationContract]
        List<CharacterDTO> GetListCharacterByIdActorAndIdFilm(int idfilm, int idactor);

        [OperationContract]
        List<FilmDTO> FindListFilmByPartialActorName(String nomActor);

        [OperationContract]
        FullActorDTO GetFullActorDetailsByIdActor(int i);

        [OperationContract]
        void InsertCommentOnActorId(CommentDTO comment, int ActorId);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        List<ActorDTO> GetAllActors();

        [OperationContract]
        List<ActorDTO> FindListActorByPartialActorName(String name, int pageNumber, int pageSize);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
