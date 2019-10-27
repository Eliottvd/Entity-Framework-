﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTest
{
    class Actor
    {
        public int ActorId { get; set; }
        public string Name { get; set; }


        public virtual ICollection<CharacterActors> CharacterActors { get; set; }
    }
}