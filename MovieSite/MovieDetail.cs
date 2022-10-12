using MovieSite.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieSite
{
    public partial class MovieDetail : Form
    {
        public MovieClass? Movie { get; set; }
        public MovieDetail(MovieClass movie)
        {
            InitializeComponent();
            Movie = movie;
            FillTextBoxText();
        }

        private void FillTextBoxText()
        {
            if (Movie is null)
                return;
            MovieName.Text = Movie.Title;
            Genre.Text= Movie.Genre;
            Year.Text= Movie.Year;
            Actors.Text= Movie.Actors;
            Brief.Text = Movie.Plot;
            IMDB.Text = Movie.imdbRating;
            Language.Text = Movie.Language;
            Production.Text = Movie.Production;
            pictureBox1.Load(Movie.Poster);
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {
            Font myFont = new Font("Arial", 14);
            Brush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            e.Graphics.TranslateTransform(30, 170);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString("Troy", myFont, myBrush, 0, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text =String.Empty;
            textBox1.Enabled = false;
        }


        private void pictureBox6_Click(object sender, EventArgs e)
        {
            string name = (sender as PictureBox).Name;
            switch (name)
            {
                case "str1":

                    str2.Image = Resources.icons8_star_96__1_;
                    str3.Image = Resources.icons8_star_96__1_;
                    str4.Image = Resources.icons8_star_96__1_;
                    str5.Image = Resources.icons8_star_96__1_;

                    str1.Image = Resources.icons8_star_96;
                    break;
                case "str2":
                    str3.Image = Resources.icons8_star_96__1_;
                    str4.Image = Resources.icons8_star_96__1_;
                    str5.Image = Resources.icons8_star_96__1_;

                    str1.Image = Resources.icons8_star_96;
                    str2.Image = Resources.icons8_star_96;
                    break;
                case "str3":

                    str4.Image = Resources.icons8_star_96__1_;
                    str5.Image = Resources.icons8_star_96__1_;

                    str1.Image = Resources.icons8_star_96;
                    str2.Image = Resources.icons8_star_96;
                    str3.Image = Resources.icons8_star_96;
                    break;
                case "str4":
                    str5.Image = Resources.icons8_star_96__1_;
                    str1.Image = Resources.icons8_star_96;
                    str2.Image = Resources.icons8_star_96;
                    str3.Image = Resources.icons8_star_96;
                    str4.Image = Resources.icons8_star_96;
                    break;
                case "str5":

                    str1.Image = Resources.icons8_star_96;
                    str2.Image = Resources.icons8_star_96;
                    str3.Image = Resources.icons8_star_96;
                    str4.Image = Resources.icons8_star_96;
                    str5.Image = Resources.icons8_star_96;
                    break;
                default:
                    break;
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
           DialogResult = DialogResult.OK;
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
