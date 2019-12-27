using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using WpfApp.ServiceReference1;

namespace WpfApp
{
    public class ActorViewModel: FullActorDTO, INotifyPropertyChanged 
    {
        FullActorDTO _acteur;
        public ActorViewModel()
        {
            _acteur = new FullActorDTO();
        }

        public ActorViewModel(FullActorDTO act)
        {
            _acteur = new FullActorDTO();
            _acteur.Name = act.Name;
            _acteur.ActorId = act.ActorId;
            _acteur.Characters = act.Characters;
            _acteur.Comments = act.Comments;
            _acteur.Films = act.Films;
        }

        public FullActorDTO ActorDTO
        {
            get { return _acteur; }
            set { _acteur = value; }
        }

        public string ActorName
        {
            get { return _acteur.Name; }
            set 
            {
                if(_acteur.Name != value)
                {
                    _acteur.Name = value;
                    RaisePropertyChanged("Name");
                }
                
            }
        }


        public  event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(propertyName != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
