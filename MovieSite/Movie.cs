using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieSite
{
    public partial class Movie : UserControl
    {
        const string _apiKey = "95404abb";
        const string _url = $"http://www.omdbapi.com/?apikey={_apiKey}";
        public Movie(MovieClass movie)
        {
            InitializeComponent();
            IMDB.Text = movie.imdbRating;
            MovieName.Text = movie.Title;
            Year.Text = movie.Year;
            pictureBox1.Load(movie.Poster);
        }

        private void MovieName_Click(object sender, EventArgs e)
        {

            foreach (var item in (sender as Label).Parent.Controls)
            {
                if(item is Label l && l.Name=="MovieName")
                {
                    MovieClass m=new MovieClass();
                    string search = $"{_url}&t={l.Text}";

                   

                    using HttpClient client = new();
                    string jsonStr = client.GetStringAsync(search).Result;
                    

                    var movies = JsonSerializer.Deserialize<MovieClass>(jsonStr);

                    
                    MovieDetail detail = new MovieDetail(movies);
                    DialogResult r = detail.ShowDialog();

                }
                    
            }
            
        }

    }
}
