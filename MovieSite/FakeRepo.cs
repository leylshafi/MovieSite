using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieSite
{
    public class FakeRepo
    {
        public static string[] Movies = new string[] { "Interstellar", "Inception", "The Avengers", "3 idiots","Mirage","The Theory of Everything","The Danish Girl","Oblivion","Atonement","Upside Down","Five Feet Apart","Leon","The Green Mile" };
        const string _apiKey = "95404abb";
        const string _url = $"http://www.omdbapi.com/?apikey={_apiKey}";




        public static List<MovieClass> GetMovies()
        {
            List<MovieClass> MoviesTemp = new List<MovieClass>();

            for (int i = 0; i < Movies.Length; i++)
            {
                 string search = $"{_url}&t={Movies[i]}";
                 
                 
                 using HttpClient client = new();
                 string jsonStr = client.GetStringAsync(search).Result;
                 
                 
                 var movie = JsonSerializer.Deserialize<MovieClass>(jsonStr);
                 MoviesTemp.Add(movie);
            }



            return MoviesTemp;

        }
    }
}
