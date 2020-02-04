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
            selectedActorId = -1;
        }

        public ObservableCollection<ActorViewModel> Actors { get => actors; set => actors = value; }
        public Service1Client Serv { get => serv; set => serv = value; }
        public ObservableCollection<string> ActorNames { get => actorNames; set => actorNames = value; }
        public ObservableCollection<string> CharacterNames { get => actorNames; set => actorNames = value; }

        private void ListBoxActeurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateMovieAndActorInfo();
            
        }
        private void updateMovieAndActorInfo()
        {
            float tot = 0;
            int nbCom = 0;
            ActorViewModel tmp = null;
            foreach (var act in _viewModel.ListActors)
            {
                if (act.ActorName.Equals(listBoxActeurs.SelectedItem))
                    tmp = act;
            }
            if (listBoxActeurs.SelectedItem != null)
            {
                selectedActorId = tmp.ActorDTO.ActorId;
                lblActorName.Content = tmp.ActorDTO.Name;
                foreach (CommentDTO com in tmp.ActorDTO.Comments)
                {
                    tot += com.Rate;
                    nbCom++;
                }
                if (nbCom > 0)
                {
                    tot /= nbCom;
                    lblActorComments.Content = tot.ToString("###") + " (" + nbCom + ")";
                }
                else
                    lblActorComments.Content = "/ (0)";

            }
            else
            {
                selectedActorId = -1;
                lblActorName.Content = "";
                lblActorComments.Content = "";
            }

            _viewModel.updateMovieInfo(tmp);
            Console.WriteLine("\n\nListe des films : ");
            foreach (FilmViewModel film in _viewModel.ListFilms)
            {
                Console.WriteLine(film.Title);
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

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void actorCommentButton_Click(object sender, RoutedEventArgs e)
        {
            if(selectedActorId != -1)
            {
                ActorCommentModal actorCommentModal = new ActorCommentModal(selectedActorId);
                actorCommentModal.ShowDialog();
                _viewModel.updateListActors(tbActor.Text);
                updateMovieAndActorInfo();
            }
            else
            {
                MessageBox.Show("No actor found", "Please select an actor", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
