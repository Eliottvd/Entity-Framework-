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

            // Create table and columns
            //List<String> columnNameList = new List<String>(new String[] { "Date", "Commentaire", "Note", "Avatar" });
            //People = new DataTable("Comments");
            //foreach (String columnName in columnNameList)
            //{
            //    People.Columns.Add(new DataColumn(columnName));
            //}
            updateCommentTable();
        }

        public int ActorId { get; }
        public Service1Client Serv { get; }

        private void addCommentButton_Click(object sender, RoutedEventArgs e)
        {
            CommentDTO comment = new CommentDTO(addCommentTextBox.Text, 5, "test", DateTime.Now);
            Serv.InsertCommentOnActorId(comment, ActorId);
        }

        private void updateCommentTable()
        {
            ObservableCollection<CommentDTO> commentDTO = new ObservableCollection<CommentDTO>();
            FullActorDTO fullActor = Serv.GetFullActorDetailsByIdActor(ActorId);
            //if (fullActor.Comments != null)
            //    foreach (CommentDTO comment in fullActor.Comments)
            //    {
            //        DataRow dataRow = People.NewRow();
            //        dataRow["Date"] = comment.Date;
            //        dataRow["Commentaire"] = comment.Content;
            //        dataRow["Note"] = comment.Rate;
            //        dataRow["Avatar"] = comment.Avatar;
            //        commentDataGrid.Items.Add(dataRow);
            //    }
            List<CommentDTO> items = new List<CommentDTO>();
            items.Add(new CommentDTO("test", 5, "moi", DateTime.Now));
            commentDataGrid.ItemsSource = items;
        }
    }
}
