using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace ConsoleApp
{
    class FilmParser
    {
        private string[] filmdetailwords;
        private string[] genres;
        private string[] actors;

        public FilmParser()
        {
        }

        public Film DecodeFilmText(string filmtext) 
        {
            Film f = new Film();
            Char[] delimiterChars = { '\u2023' };
            filmdetailwords = filmtext.Split(delimiterChars);
            delimiterChars[0] = '\u2016';

            // Initialization of the basic fields of the film
            f.FilmId = Int32.Parse(filmdetailwords[0]);
            f.Title = filmdetailwords[1];
            f.Runtime = Int32.Parse(filmdetailwords[7]);
            f.Posterpath = filmdetailwords[9];

            // Initialization of the optionnals fields of the film
            if (filmdetailwords.Length == 15)
            {
                genres = filmdetailwords[12].Split(delimiterChars);
                foreach (string s in genres)
                {
                    if (s.Length > 0)
                        f.Genres.Add(new Genre(s));
                }
                actors = filmdetailwords[14].Split(delimiterChars);
                foreach (string s in actors)
                    if (s.Length > 0)
                    {
                        string[] acteurdetail, characterdetail;
                        string tmp;
                        Char[] delimiterChars2 = { '\u2024' };
                        acteurdetail = s.Split(delimiterChars2);
                        delimiterChars2[0] = '/';
                        tmp = acteurdetail[2];
                        characterdetail = tmp.Split(delimiterChars2);

                        Actor a = new Actor(acteurdetail);
                        Character c = new Character(characterdetail[0]);

                        f.CharacterActors.Add(new CharacterActors(f, c, a));
                    }
                        
            }
            return f;
        }
    }
}
