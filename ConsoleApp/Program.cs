﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;
using DTO;
using WcfService;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            StreamReader f;
            int startLine = 0;
            int endLine = 200;

            if (System.Environment.MachineName == "LAPTOP-QHT69N73")
                f = new StreamReader(@"D:\OneDrive - Enseignement de la Province de Liège\Ecole\BLOC3\Q1\C#\movies_v2.txt");
            else if(System.Environment.MachineName == "DESKTOP-S21MDKI")
                f = new StreamReader(@"D:\GoogleDrive\Ecole\2019-2020\3e Indus\C#\Entity-Framework\movies_v2.txt");
            else
            {
                Console.WriteLine("Chemin d'acces au fichier movie2.txt non valide");
                f = null;
                System.Environment.Exit(1);
            }

            for (int i = 0; i <= startLine; i++)
            {
                f.ReadLine();
            }
            for (int i = startLine; i < endLine; i++)
            {
                readAnddecodeline(f);
                Console.WriteLine("Decoding line " + i);
            }

            Console.ReadLine();
        }

        private static bool readAnddecodeline(StreamReader f)
        {
            string line = f.ReadLine();
            if (line == null)
                return false;

            // Creation d'un objet film
            FilmParser filmtext = new FilmParser();
            Film film = filmtext.DecodeFilmText(line);

            SaveFilmToDataBase(film);

            return true;
        }

        private static void SaveFilmToDataBase(Film film)
        {
            using (var dal = new DALManager("name=FilmDB"))
            {
                dal.AddFilm(film);
            }
        }
    }
}
