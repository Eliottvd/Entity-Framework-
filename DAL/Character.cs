using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Character
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }

        public Character() { }
        public Character(string Name)
        {
            CharacterName = Name;
            CharacterActors = new List<CharacterActors>();
            Actors = new List<Actor>();
            Films = new List<Film>();
        }

        public virtual ICollection<CharacterActors> CharacterActors { get; set; }
        public virtual ICollection<Film> Films { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
    }
}
