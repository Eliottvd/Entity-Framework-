using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Actor
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ActorId { get; set; }
        public string Name { get; set; }

        public Actor() { }
        public Actor(string[] acteurdetail)
        {
            ActorId = Int32.Parse(acteurdetail[0]);
            Name = acteurdetail[1];
            CharacterActors = new List<CharacterActors>();
            Comments = new List<Comment>();
        }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CharacterActors> CharacterActors { get; set; }
    }
}
