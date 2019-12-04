using DTO;
using ServiceTestConsole.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client ser = new Service1Client();

            ConsoleKeyInfo rep;

            FilmDTO[] filmDTOs;
            CharacterDTO[] characterDTOs;
            FullActorDTO fullAct;
            do
            {
                Console.WriteLine("\n\n\n--------------------------------------"); 
                Console.WriteLine("What do you want to do ? ");
                Console.WriteLine("1/Find list film by partial actor name");
                Console.WriteLine("2/Get list film by id actor");
                Console.WriteLine("3/Get full actor detail by id actor");
                Console.WriteLine("4/Get character by id actor and id film");
                Console.WriteLine("5/Insert commment on actorId");
                Console.WriteLine("6/Exit");
                rep = Console.ReadKey();
                Console.WriteLine("\nProcessing...\n");
                switch(rep.Key)
                {
                    case ConsoleKey.NumPad1:
                        Console.WriteLine("Partial actor name : ");
                        filmDTOs = ser.FindListFilmByPartialActorName(Console.ReadLine());
                        foreach (FilmDTO f in filmDTOs)
                        {
                            Console.WriteLine(f.toString());
                        }

                        break;

                    case ConsoleKey.NumPad2:
                        Console.WriteLine("Actor Id : ");
                        try
                        {
                            filmDTOs = ser.GetListFilmsByIdActor(Int32.Parse(Console.ReadLine()));
                            foreach (FilmDTO f in filmDTOs)
                            {
                                Console.WriteLine(f.toString());
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Unable to parse ");
                        }

                        

                        break;

                    case ConsoleKey.NumPad3:
                        Console.WriteLine("Actor Id : ");
                        try
                        {
                            fullAct = ser.GetFullActorDetailsByIdActor(Int32.Parse(Console.ReadLine()));
                            Console.WriteLine(fullAct.ActorId + fullAct.Name);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Unable to parse ");
                        }
                        

                        break;

                    case ConsoleKey.NumPad4:
                        int ActorId, IdFilm;
                        try
                        {
                            Console.WriteLine("Actor Id : ");
                            ActorId = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Film Id : ");
                            IdFilm = Int32.Parse(Console.ReadLine());
                            characterDTOs = ser.GetListCharacterByIdActorAndIdFilm(IdFilm, ActorId);
                            foreach (CharacterDTO charac in characterDTOs)
                            {
                                Console.WriteLine(charac.CharacterId + charac.Name);
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Unable to parse ");
                        }
                        

                        break;

                    case ConsoleKey.NumPad5:
                        CommentDTO com = new CommentDTO
                        {
                            Content = "testContent",
                            Rate = 3,
                            Avatar = "avatarString",
                            Date = new DateTime()

                        };

                        ser.InsertCommentOnActorId(com, 2);
                        break;
                }

            } while (rep.Key != ConsoleKey.NumPad6);

            ser.Close();
        }
    }
}
