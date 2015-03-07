using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MovieInfo : System.Web.UI.Page
{
    public DataClassesDataContext database = new DataClassesDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        
            String value = (String)Session["dishu"];
            movieInfoLabel.Text = value;
        
        Movy movie = new Movy();
        try
        {
            var movies = from movieName in database.Movies
                         where movieName.title == value
                         select movieName;

            movie = movies.First();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
            movieInfoLabel.Text = "Title: " + movie.title + "<br>Release Year: " + movie.releaseYear + "<br>Language: " + movie.language + "<br>";

            var genresID = from genreId in database.MovieGenres
                           where genreId.movieId == movie.movieId
                           select genreId;

            movieInfoLabel.Text += "Genre: ";
            foreach (var g in genresID)
            {
                var genres = from genre in database.Genres
                             where genre.genreId == g.genreId
                             select genre;

                Genre gg = genres.First();
                movieInfoLabel.Text += gg.description + ", ";
            }
            String temp = movieInfoLabel.Text;
            movieInfoLabel.Text = temp.Substring(0, temp.Length - 2);
            movieInfoLabel.Text += "<br>";

            var directorID = from id in database.Persons
                             where id.personId == movie.director
                             select id;
            try
            {
                movieInfoLabel.Text += "Director: " + directorID.First().name+"<br>";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var personNames = from p in database.Persons
                              from pr in database.PersonRoles
                              from pf in database.Performers
                              where pr.personRoleId == pf.personRoleId &&
                              pf.movieId == movie.movieId &&
                              p.personId == pr.personId
                              select p.name;
            movieInfoLabel.Text += "Actor/Actresses: ";

            foreach (var name in personNames)
                movieInfoLabel.Text += name.Trim() + ", ";  
        temp = movieInfoLabel.Text;
        movieInfoLabel.Text = temp.Substring(0, temp.Length - 2);
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Server.Transfer("MasterPage.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Server.Transfer("MovieList.aspx");
    }
}