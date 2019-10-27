using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTest
{
    class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public float Rate { get; set; } 
        public string Avatar { get; set; }
        public DateTime? Date { get; set; }


        public Film Film { get; set; }
    }


}
