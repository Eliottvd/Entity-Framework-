using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Status
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public Status() { }

        public Status(string statusName)
        {
            StatusName = statusName;
            Film = new List<Film>();
        }

        public virtual ICollection<Film> Film { get; set; }
    }
}
