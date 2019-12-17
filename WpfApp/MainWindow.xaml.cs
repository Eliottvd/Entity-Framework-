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
        private ServiceReference1.Service1Client serv;
        public MainWindow()
        {
            InitializeComponent();
            Serv = new ServiceReference1.Service1Client();

            ActorDTO[] actorDTOs = serv.GetAllActors();
            foreach (var actor in actorDTOs)
            {
                Actors.Add(new ActorViewModel
                {
                    Name = actor.Name
                });
            }
            dgActors.ItemsSource = Actors;
        }

        public ObservableCollection<ActorViewModel> Actors { get => actors; set => actors = value; }
        public Service1Client Serv { get => serv; set => serv = value; }
    }
}
