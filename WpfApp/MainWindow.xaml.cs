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
        private int movieIndex, selectedActorId;
        private List<FilmDTO> filmDTOs = new List<FilmDTO>();
        ListActorViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            Serv = new Service1Client();
            _viewModel = new ListActorViewModel();
            ActorNames = new ObservableCollection<string>();
            base.DataContext = _viewModel;
        }

        public ObservableCollection<ActorViewModel> Actors { get => actors; set => actors = value; }
        public Service1Client Serv { get => serv; set => serv = value; }
        public ObservableCollection<string> ActorNames { get => actorNames; set => actorNames = value; }
        public ObservableCollection<string> CharacterNames { get => actorNames; set => actorNames = value; }

        private void ListBoxActeurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActorViewModel tmp = null;
            foreach (var act in _viewModel.ListActors)
            {
                if (act.ActorName.Equals(listBoxActeurs.SelectedItem))
                    tmp = act;
            }
            selectedActorId = tmp.ActorDTO.ActorId;
            _viewModel.updateMovieInfo(tmp);
            Console.WriteLine("\n\nListe des films : ");
            foreach (FilmViewModel film in _viewModel.ListFilms)
            {
                Console.WriteLine(film.OriginalTitle);
            }
            dgFilms.ItemsSource = _viewModel.ListFilms;
            this.dgFilms.Items.Refresh();
        }

        private void tbActor_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.resetPageNbr();
            _viewModel.updateListActors(tbActor.Text);
            listBoxActeurs.ItemsSource = _viewModel.ListActorsName;
        }
        
        private void nextPageButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.pageNext(tbActor.Text, listBoxActeurs.Items.Count);
            listBoxActeurs.ItemsSource = _viewModel.ListActorsName;
        }

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.pagePrevious(tbActor.Text);
            listBoxActeurs.ItemsSource = _viewModel.ListActorsName;
        }
        /*
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
        }*/

        private void nextMoviePageButton_Click(object sender, RoutedEventArgs e)
        {
            if (movieIndex < filmDTOs.Count - 1)
                movieIndex++;
            //updateMovieInfo(movieIndex);
        }

        private void PreviousMoviePageButton_Click(object sender, RoutedEventArgs e)
        {
            movieIndex = (movieIndex > 0) ? --movieIndex : 0;
            //updateMovieInfo(movieIndex);
        }

        private void actorCommentButton_Click(object sender, RoutedEventArgs e)
        {
            ActorCommentModal actorCommentModal = new ActorCommentModal(selectedActorId);
            actorCommentModal.ShowDialog();
        }
    }
}
