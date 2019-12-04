using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfService;

namespace ServiceTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1 ser = new Service1();
            
            ConsoleKeyInfo rep;
            List<FilmDTO> filmDTOs;
            List<CharacterDTO> characterDTOs;
            FullActorDTO fullAct;
            do
            {
                Console.WriteLine("\n\n\n--------------------------------------"); 
                Console.WriteLine("What do you want to do ? ");
                Console.WriteLine("1/Find list film by partial actor name");
                Console.WriteLine("2/Get list film by id actor");
                Console.WriteLine("3/Get full actor detail by id actor");
                Console.WriteLine("4/Get character by id actor and id film");
                Console.WriteLine("5/Exit");
                rep = Console.ReadKey();
                Console.WriteLine("\nProcessing...\n");
                switch(rep.Key)
                {
                    case ConsoleKey.NumPad1:
                        filmDTOs = ser.FindListFilmByPartialActorName("wil");
                        foreach (FilmDTO f in filmDTOs)
                        {
                            Console.WriteLine(f.toString());
                        }

                        break;

                    case ConsoleKey.NumPad2:
                        filmDTOs = ser.GetListFilmsByIdActor(2);
                        foreach (FilmDTO f in filmDTOs)
                        {
                            Console.WriteLine(f.toString());
                        }

                        break;

                    case ConsoleKey.NumPad3:
                        fullAct = ser.GetFullActorDetailsByIdActor(2);
                        Console.WriteLine(fullAct.ActorId + fullAct.Name);

                        break;

                    case ConsoleKey.NumPad4:
                        characterDTOs = ser.GetListCharacterByIdActorAndIdFilm(1, 2);
                        foreach (CharacterDTO charac in characterDTOs)
                        {
                            Console.WriteLine(charac.CharacterId+charac.Name);
                        }

                        break;
                }

            } while (rep.Key != ConsoleKey.NumPad5);
        }
    }
}
