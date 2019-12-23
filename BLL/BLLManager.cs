using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class BLLManager
    {
        private FilmCtx _filmCtx;
        private DALManager dalM;
        private readonly object filmDTOs;

        public BLLManager(String connString)
        {
            _filmCtx = new FilmCtx(connString);
            dalM = new DALManager(_filmCtx);
            Console.WriteLine("DAL crée");
        }

        public BLLManager()
        {
            _filmCtx = new FilmCtx("name=FilmDB");
            dalM = new DALManager(_filmCtx);
            Console.WriteLine("DAL crée");
        }

        public List<FilmDTO> GetListFilmsByIdActor(int id)
        {
            List<FilmDTO> filmDTOs = new List<FilmDTO>();

            try
            {
                Actor acteur = dalM.FilmCtx.Actors.First(a => a.ActorId == id);


                FilmDTO tmp;

                foreach (CharacterActors ca in acteur.CharacterActors)
                {
                    tmp = new FilmDTO
                    {
                        FilmId = ca.Film.FilmId,
                        Title = ca.Film.Title,
                        OriginalTitle = ca.Film.OriginalTitle,
                        ReleaseDate = ca.Film.ReleaseDate,
                        VoteAverage = ca.Film.VoteAverage,
                        VoteCount = ca.Film.VoteCount,
                        Runtime = ca.Film.Runtime,
                        Posterpath = ca.Film.Posterpath,
                        Budget = ca.Film.Budget,
                        TagLine = ca.Film.TagLine
                    };

                    if (ca.Film.Status != null)
                    {
                        Status stat = dalM.FilmCtx.Status.First(s => s.StatusId == ca.Film.Status.StatusId);
                        tmp.Status = stat.StatusName;
                    }
                    else
                    {
                        tmp.Status = "/";
                    }

                    if (ca.Film.Status != null)
                    {
                        Rating rat = dalM.FilmCtx.Rating.First(r => r.RatingId == ca.Film.Rating.RatingId);
                        tmp.Rating = rat.Type;
                    }
                    else
                    {
                        tmp.Rating = "/";
                    }



                    filmDTOs.Add(tmp);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return filmDTOs;
        }

        public List<FilmDTO> getAllMovies()
        {
            List<FilmDTO> filmDTOs = new List<FilmDTO>();

            List<Film> listFilm = dalM.getAllMovies();

            foreach (Film f in listFilm)
            {
                filmDTOs.Add(new FilmDTO
                {
                    Title = f.Title,
                    OriginalTitle = f.OriginalTitle,
                    ReleaseDate = f.ReleaseDate,
                    VoteAverage = f.VoteAverage,
                    VoteCount = f.VoteCount,
                    Runtime = f.Runtime,
                    Posterpath = f.Posterpath,
                    Budget = f.Budget,
                    TagLine = f.TagLine
                });
            }

            return filmDTOs;
        }

        public List<CharacterDTO> GetListCharacterByIdActorAndIdFilm(int idActor, int idFilm)
        {
            List<CharacterDTO> characterDTOs = new List<CharacterDTO>();
            try
            {
                Actor acteur = dalM.FilmCtx.Actors.First(a => a.ActorId == idActor);
                Film film = dalM.FilmCtx.Films.First(f => f.FilmId == idFilm);

                CharacterDTO tmp;
                foreach (CharacterActors ca in acteur.CharacterActors)
                {
                    if (film == ca.Film)
                    {
                        tmp = new CharacterDTO
                        {
                            Name = ca.Character.CharacterName,
                            CharacterId = ca.Character.CharacterId
                        };
                        characterDTOs.Add(tmp);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }


            return characterDTOs;
        }

        public List<FilmDTO> FindListFilmByPartialActorName(String name)
        {
            List<FilmDTO> filmDTOs = new List<FilmDTO>();
            try
            {
                IQueryable<Actor> acteurs = dalM.FilmCtx.Actors.Where(a => a.Name.Contains(name));

                foreach (Actor a in acteurs)
                {
                    foreach (FilmDTO f in GetListFilmsByIdActor(a.ActorId))
                        filmDTOs.Add(f);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return filmDTOs;
        }

        public List<ActorDTO> FindListActorByPartialActorName(String name, int pageNumber, int pageSize)
        {
            List<ActorDTO> actorDTOs = new List<ActorDTO>();
            try
            {
                //IQueryable<Actor> acteurs = dalM.FilmCtx.Actors.Where(a => a.Name.Contains(name));
                IQueryable<Actor> acteurs = dalM.FilmCtx.Actors.Where(a => a.Name.Contains(name)).OrderBy(a => a.Name).Skip(pageNumber * pageSize).Take(pageSize);

                foreach (Actor a in acteurs)
                {
                    actorDTOs.Add(new ActorDTO
                    {
                        ActorId = a.ActorId,
                        Name = a.Name
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return actorDTOs;
        }

        public FullActorDTO GetFullActorDetailsByIdActor(int idActor)
        {
            FullActorDTO FullActeur = new FullActorDTO();
            try
            {
                Actor acteur = dalM.FilmCtx.Actors.Find(idActor);
                FullActeur.ActorId = acteur.ActorId;
                FullActeur.Name = acteur.Name;
                foreach (var film in acteur.Films)
                {
                    FullActeur.Films.Add(new FilmDTO
                    {
                        Title = film.Title,
                        OriginalTitle = film.OriginalTitle,
                        ReleaseDate = film.ReleaseDate,
                        VoteAverage = film.VoteAverage,
                        VoteCount = film.VoteCount,
                        Runtime = film.Runtime,
                        Posterpath = film.Posterpath,
                        Budget = film.Budget,
                        TagLine = film.TagLine,
                        Status = film.Status==null?"":film.Status.StatusName,
                        Rating = film.Rating==null?"":film.Rating.Type
                    });
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return FullActeur;
        }

        public void InsertCommentOnActorId(CommentDTO comment, int actorId)
        {
            Actor acteur = dalM.FilmCtx.Actors.Find(actorId);
            
                Comment c = new Comment()
                {
                    Actor = acteur,
                    Rate = comment.Rate,
                    Avatar = comment.Avatar,
                    Content = comment.Content,
                    Date = DateTime.Now
                };
                //acteur.Comments.Add(c);
                

                dalM.AddComment(c);


        }

        public List<ActorDTO> getAllActors()
        {
            List<ActorDTO> actorDTOs = new List<ActorDTO>();

            List<Actor> listActor = dalM.getActor();

            foreach (Actor a in listActor)
            {
                actorDTOs.Add(new ActorDTO
                {
                    Name = a.Name,
                    ActorId = a.ActorId
                });
            }

            return actorDTOs;
        }

    }
}
