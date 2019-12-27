using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfApp
{
    public class FilmViewModel
    {
        public string OriginalTitle { get; set; }
        public string ReleaseDate { get; set; }
        public string Runtime { get; set; }
        public string PosterPath { get; set; }
        //public BitmapImage PosterBitmap { get; set; }

        public FilmViewModel()
        {

        }

        public FilmViewModel(string originalTitle, string releaseDate, string runtime, string posterPath)
        {
            OriginalTitle = originalTitle;
            ReleaseDate = releaseDate;
            Runtime = runtime;
            PosterPath = posterPath;
            /*if (!String.IsNullOrWhiteSpace(posterPath))
            {
                var imageURL = @" http://image.tmdb.org/t/p/w185";
                imageURL += posterPath;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imageURL, UriKind.Absolute);
                bitmap.EndInit();

                PosterBitmap = bitmap;
            }
            else
                PosterBitmap = null;*/
        }
    }
}
