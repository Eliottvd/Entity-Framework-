using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.ServiceReference1;
using DTO;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<ActorViewModel> actors = new ObservableCollection<ActorViewModel>();
        private Service1Client serv;
        private ObservableCollection<string> actorNames;
        public MainWindow()
        {
            InitializeComponent();
            Serv = new Service1Client();
            ActorNames = new ObservableCollection<string>();
            /*
            ActorDTO[] actorDTOs = serv.GetAllActors();
            foreach (var actor in actorDTOs)
            {
                Actors.Add(new ActorViewModel
                {
                    Name = actor.Name
                });
                ActorsIDs.Add(actor.Name);
            }
            //dgActors.ItemsSource = Actors;
            ListBoxActeurs.ItemsSource = ActorsIDs;*/
        }

        public ObservableCollection<ActorViewModel> Actors { get => actors; set => actors = value; }
        public Service1Client Serv { get => serv; set => serv = value; }
        public ObservableCollection<string> ActorNames { get => actorNames; set => actorNames = value; }

        private void tbActor_KeyUp(object sender, KeyEventArgs e)
        {
          
            List<ActorDTO> actorDTOs = serv.FindListActorByPartialActorName(tbActor.Text);
            ActorNames.Clear();
            Actors.Clear();
            foreach (var actor in actorDTOs)
            {
                Actors.Add(new ActorViewModel
                {
                    ActorId = actor.ActorId,
                    Name = actor.Name
                });
                ActorNames.Add(actor.Name);
            }
            //dgActors.ItemsSource = Actors;
            ListBoxActeurs.ItemsSource = ActorNames;

        }

        private void ListBoxActeurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = 0;
            FullActorDTO fa;
            ObservableCollection<FilmDTO> filmDTOs = new ObservableCollection<FilmDTO>();
            if(ListBoxActeurs.SelectedItem != null)
            {
                Console.WriteLine(ListBoxActeurs.SelectedItem);
                foreach (var avm in Actors)
                {
                    if (avm.Name == ListBoxActeurs.SelectedItem.ToString())
                    {
                        id = avm.ActorId;
                        //break;
                    }
                }

                fa = Serv.GetFullActorDetailsByIdActor(id);
                Console.WriteLine("fa : " + fa.ActorId);
                dgActors.ItemsSource = fa.Films;
            }
        }
    }
}
