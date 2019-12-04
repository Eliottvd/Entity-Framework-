using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BLL;
using DTO;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private BLLManager _bllmanager;

        public BLLManager bllManager { get => _bllmanager; set => _bllmanager = value; }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public Service1()
        {
            bllManager = new BLLManager();
        }

        public List<FilmDTO> GetListFilmsByIdActor(int id)
        {
            return bllManager.GetListFilmsByIdActor(id);
        }

        public List<CharacterDTO> GetListCharacterByIdActorAndIdFilm(int idfilm, int idactor)
        {
            return bllManager.GetListCharacterByIdActorAndIdFilm(idfilm, idactor);
        }

        public List<FilmDTO> FindListFilmByPartialActorName(string nomActor)
        {
            return bllManager.FindListFilmByPartialActorName(nomActor);
        }


        public FullActorDTO GetFullActorDetailsByIdActor(int i)
        {
            return bllManager.GetFullActorDetailsByIdActor(i);
        }

        public void InsertCommentOnActorId(CommentDTO comment)
        {
            bllManager.InsertCommentOnActorId(comment);
        }
    }
}
