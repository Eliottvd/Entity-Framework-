using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
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
        private string[] directors;

        public FilmParser()
        {
        }

        public Film DecodeFilmText(string filmtext) 
        {
            Film f = new Film();
            Char[] delimiterChars = { '\u2023' };
            filmdetailwords = filmtext.Split(delimiterChars);
            delimiterChars[0] = '\u2016';

            // Initialization of the basic fields of the movie
            f.FilmId = Int32.Parse(filmdetailwords[0]);
            f.Title = filmdetailwords[1];
            f.OriginalTitle = filmdetailwords[2];
            f.ReleaseDate = DateTime.ParseExact(filmdetailwords[3], "yyyy-MM-dd", CultureInfo.InvariantCulture);
            f.Status = new Status(filmdetailwords[4]);
            f.Status.Film.Add(f);
            f.VoteAverage = float.Parse(filmdetailwords[5]);
            f.VoteCount = Int32.Parse(filmdetailwords[6]);
            f.Runtime = Int32.Parse(filmdetailwords[7]);
            f.Rating = new Rating(filmdetailwords[8]);
            f.Rating.Film.Add(f);
            f.Posterpath = filmdetailwords[9];
            f.Budget = Int32.Parse(filmdetailwords[10]);
            f.TagLine = filmdetailwords[11];

            // Initialization of the optionnal fields of the movie
            if (filmdetailwords.Length == 15)
            {
                // Parse genres
                genres = filmdetailwords[12].Split(delimiterChars);
                foreach (string s in genres)
                {
                    if (s.Length > 0)
                    {
                        Genre g = new Genre(s);
                        g.Film.Add(f);
                        f.Genres.Add(g);
                    }
                }
                // Parse directors
                directors = filmdetailwords[13].Split(delimiterChars);
                foreach (string s in directors)
                    if (s.Length > 0)
                    {
                        Director d = new Director(s);
                        d.Film.Add(f);
                        f.Directors.Add(d);
                    }
                // Parse actors
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
