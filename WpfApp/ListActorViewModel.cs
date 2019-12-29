using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.ServiceReference1;

namespace WpfApp
{
    
    public class ListActorViewModel : INotifyPropertyChanged
    {
        private List<ActorViewModel> listActors;
        private List<FilmViewModel> listFilms;
        private Service1Client serv;
        private int pageNumber = 0;
        private int pageSize = 10;
        private int movieIndex = 0;
        public ListActorViewModel()
        {
            Serv = new Service1Client();
            ListActors = new List<ActorViewModel>();
            listFilms = new List<FilmViewModel>();
        }
        public Service1Client Serv { get => serv; set => serv = value; }

        public List<string> ListActorsName
        {
            get
            {
                List<string> listActorsName = new List<string>();
                foreach(var actor in ListActors)
                {
                    listActorsName.Add(actor.ActorName);
                }
                return listActorsName;
            }
        }

        public List<FilmViewModel> ListFilms
        {
            get { return listFilms; }
        }

        public List<string> ListFilmsTitle
        {
            get
            {
                List<string> listFilmTitle = new List<string>();
                foreach (var film in listFilms)
                {
                    listFilmTitle.Add(film.OriginalTitle);
                }
                return listFilmTitle;
            }
        }

        public List<ActorViewModel> ListActors { get => listActors;
            set
            {
                if (listActors != value)
                {
                    listActors = value;
                    //RaisePropertyChanged("listActors");
                }
            }
        }

        public void resetPageNbr()
        {
            pageNumber = 0;
        }
        public void updateListActors(string partialName)
        {
            List<ActorDTO> actorDTOs = serv.FindListActorByPartialActorName(partialName, pageNumber, pageSize);
            ListActors.Clear();
            foreach (var actor in actorDTOs)
            {
                ListActors.Add(new ActorViewModel(Serv.GetFullActorDetailsByIdActor(actor.ActorId)));
            }
        }

        public void pageNext(string partialName, int lbCount)
        {
            if (lbCount >= pageSize)
                pageNumber++;
            updateListActors(partialName);
        }

        public void pagePrevious(string partialName)
        {
            pageNumber = (pageNumber > 0) ? --pageNumber : 0;
            updateListActors(partialName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (propertyName != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        public void updateMovieInfo(ActorViewModel actor)
        {
            if(actor != null)
            {
                List<FilmDTO> filmDTOs = Serv.FindListFilmByPartialActorName(actor.ActorName);
                if(filmDTOs.Count > 0)
                {
                    List<CharacterDTO> characterDTOs = Serv.GetListCharacterByIdActorAndIdFilm(actor.ActorDTO.ActorId, filmDTOs[movieIndex].FilmId);

                    listFilms.Clear();
                    foreach(FilmDTO film in filmDTOs)
                    {
                        TimeSpan ts = TimeSpan.FromMinutes(film.Runtime);
                        string.Format("{0}h{1}", ts.Hours, ts.Minutes);
                        FilmViewModel fvm = new FilmViewModel(film.OriginalTitle, film.ReleaseDate.ToString(), string.Format("{0}h{1}", ts.Hours, ts.Minutes), film.Posterpath);
                        listFilms.Add(fvm);
                    }
                }
                
            }
            
        }

    }
}
