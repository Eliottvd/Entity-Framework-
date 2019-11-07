using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }

        public Character()
        {

        }

        public Character(string Name)
        {
            CharacterName = Name;
            CharacterActors = new List<CharacterActors>();
        }

        public virtual ICollection<CharacterActors> CharacterActors { get; set; }
    }
}
