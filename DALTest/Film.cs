﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTest
{
    class Film
    {
        public int FilmID { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int VoteAverage { get; set; }
        public TimeSpan Runtime { get; set; }
        public string Posterpath { get; set; }



        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CharacterActors> CharacterActors { get; set; }
    }
}