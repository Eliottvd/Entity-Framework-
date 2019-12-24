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
        private int pageNumber = 0;
        private int pageSize = 10;
        private int movieIndex;
        private FullActorDTO selectedActor;
        private List<FilmDTO> filmDTOs = new List<FilmDTO>();
        public MainWindow()
        {
            InitializeComponent();
            Serv = new Service1Client();
            ActorNames = new ObservableCollection<string>();
        }

        public ObservableCollection<ActorViewModel> Actors { get => actors; set => actors = value; }
        public Service1Client Serv { get => serv; set => serv = value; }
        public ObservableCollection<string> ActorNames { get => actorNames; set => actorNames = value; }
        public ObservableCollection<string> CharacterNames { get => actorNames; set => actorNames = value; }

        private void ListBoxActeurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = 0;
            movieIndex = 0;


            if (listBoxActeurs.SelectedItem != null)
            {
                Console.WriteLine(listBoxActeurs.SelectedItem);
                foreach (var avm in Actors)
                {
                    if (avm.Name == listBoxActeurs.SelectedItem.ToString())
                    {
                        id = avm.ActorId;
                        break;
                    }
                }

                selectedActor = Serv.GetFullActorDetailsByIdActor(id);
                Console.WriteLine("fa : " + selectedActor.ActorId);

                actorNameLabel.Content = selectedActor.Name;
                if ((selectedActor.Comments != null))
                {
                    int nbComments = selectedActor.Comments.Count;
                    if (nbComments > 0)
                    {
                        float total = 0;
                        foreach (CommentDTO comment in selectedActor.Comments)
                        {
                            total += comment.Rate;
                        }
                        actorNameLabel.Content = selectedActor.Name + String.Format(" {0} ({1})", (total / nbComments).ToString("0.00"), nbComments);
                    }

                }
                    

                filmDTOs = Serv.FindListFilmByPartialActorName(selectedActor.Name);
                Console.WriteLine(filmDTOs.Count());
                updateMovieInfo(movieIndex);
            }
        }

        private void tbActor_TextChanged(object sender, TextChangedEventArgs e)
        {
            pageNumber = 0;
            updateActorBox();
        }

        private void nextPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxActeurs.Items.Count >= pageSize)
                pageNumber++;
            updateActorBox();
        }

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            pageNumber = (pageNumber > 0) ? --pageNumber : 0;
            updateActorBox();
        }

        private void updateActorBox()
        {
            List<ActorDTO> actorDTOs = serv.FindListActorByPartialActorName(tbActor.Text, pageNumber, pageSize);
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
            listBoxActeurs.ItemsSource = ActorNames;
        }

        private void updateMovieInfo(int movieIndex)
        {
            List<CharacterDTO> characterDTOs = Serv.GetListCharacterByIdActorAndIdFilm(selectedActor.ActorId, filmDTOs[movieIndex].FilmId);
            FilmDTO film = filmDTOs[movieIndex];

            titleLabel.Content = film.OriginalTitle;
            releaseDateLabel.Content = film.ReleaseDate;
            // Duration
            TimeSpan ts = TimeSpan.FromMinutes(film.Runtime);
            durationLabel.Content = string.Format("{0}h{1}", ts.Hours, ts.Minutes);

            if (!String.IsNullOrWhiteSpace(film.Posterpath))
            {
                var imageURL = @" http://image.tmdb.org/t/p/w185";
                imageURL += film.Posterpath;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imageURL, UriKind.Absolute);
                bitmap.EndInit();

                movieImage.Source = bitmap;
            }

            charactorListBox.ItemsSource = characterDTOs;
        }

        private void nextMoviePageButton_Click(object sender, RoutedEventArgs e)
        {
            if (movieIndex < filmDTOs.Count - 1)
                movieIndex++;
            updateMovieInfo(movieIndex);
        }

        private void PreviousMoviePageButton_Click(object sender, RoutedEventArgs e)
        {
            movieIndex = (movieIndex > 0) ? --movieIndex : 0;
            updateMovieInfo(movieIndex);
        }

        private void actorCommentButton_Click(object sender, RoutedEventArgs e)
        {
            ActorCommentModal actorCommentModal = new ActorCommentModal(selectedActor.ActorId);
            actorCommentModal.ShowDialog();
        }
    }
}
