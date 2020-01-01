using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.ServiceReference1;

namespace WebApp.Models
{
    public class listComments
    {
        public List<Comment> listCom { get; set; }

        public listComments()
        {
            listCom = new List<Comment>();
        }
        public listComments(List<CommentDTO> commentDTOs)
        {
            listCom = new List<Comment>();
            foreach(CommentDTO com in commentDTOs)
            {
                listCom.Add(new Comment(com));
            }
        }
    }
}