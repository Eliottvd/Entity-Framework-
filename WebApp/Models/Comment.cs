using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.ServiceReference1;

namespace WebApp.Models
{
    public class Comment : CommentDTO
    {
        public Comment()
        {

        }
        public Comment(CommentDTO com)
        {
            this.Avatar = com.Avatar;
            this.Content = com.Content;
            this.Date = com.Date;
            this.Rate = com.Rate;
        }
    }
}