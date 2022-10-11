using System.Text.Json;

namespace MovieSite
{
    public partial class Form1 : Form
    {
        private MovieClass? _selectedMovie = null;
        const string _apiKey = "95404abb";
        const string _url = $"http://www.omdbapi.com/?apikey={_apiKey}";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = FakeRepo.GetMovies().Count - 1; i >= 0; i--)
            {
                var userControl = new Movie(FakeRepo.GetMovies()[i]);
                userControl.Dock = DockStyle.Top;
                pnl_Movies.Controls.Add(userControl);
            }


            AutoScrollMinSize = new Size(1300, 220 + pnl_Movies.PreferredSize.Height);
        }

        private void Search_Click(object sender, EventArgs e)
        {
            _selectedMovie = new MovieClass();
            string search = $"{_url}&t={textBox1.Text}";
            string test = $"{_url}&t=sjsj";

            using HttpClient client = new();
            string jsonStr = client.GetStringAsync(search).Result;
            string errorMessage = client.GetStringAsync(test).Result;

            if (jsonStr == errorMessage)
            {
                MessageBox.Show("Wrong Information Entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = String.Empty;
                return;
            }

            var movie = JsonSerializer.Deserialize<MovieClass>(jsonStr);

            _selectedMovie = movie;
            if (_selectedMovie == null)
                return;
            MovieDetail formEdit = new MovieDetail(_selectedMovie);
            DialogResult result = formEdit.ShowDialog();

            textBox1.Text = String.Empty;
            if (result == DialogResult.OK)
            {
                var userControl = new Movie(_selectedMovie);
                userControl.Dock = DockStyle.Top;
                pnl_Movies.Controls.Add(userControl);
            }



            DialogResult = DialogResult.OK;


        }

    }
}