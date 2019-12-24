using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using System.Windows.Shapes;
using WpfApp.ServiceReference1;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ActorCommentModal.xaml
    /// </summary>
    public partial class ActorCommentModal : Window
    {
        public ActorCommentModal(int actorId)
        {
            InitializeComponent();
            ActorId = actorId;
            Serv = new Service1Client();
            updateCommentTable();
        }

        public int ActorId { get; }
        public Service1Client Serv { get; }

        private void addCommentButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(addCommentTextBox.Text) && !String.IsNullOrWhiteSpace(rateCommentTextBox.Text))
            {
                float rate = float.TryParse(rateCommentTextBox.Text, out rate) == false ? rate = 0 : rate;
                CommentDTO comment = new CommentDTO(addCommentTextBox.Text, rate, "Daniel", DateTime.Now);
                Serv.InsertCommentOnActorId(comment, ActorId);
                updateCommentTable();
                addCommentTextBox.Text = "";
                rateCommentTextBox.Text = "";
            }

        }

        private void updateCommentTable()
        {
            FullActorDTO fullActor = Serv.GetFullActorDetailsByIdActor(ActorId);
            commentDataGrid.ItemsSource = fullActor.Comments.OrderByDescending(c => c.Date);
        }

        private void addCommentTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                addCommentButton_Click(sender, e);
            }
        }

        private void rateCommentTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                addCommentButton_Click(sender, e);
            }
        }
    }
}
