using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class MovieList : System.Web.UI.Page
{
    public DataClassesDataContext database = new DataClassesDataContext();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        String director = (String)Session["director"];
        String actor = (String)Session["actor"];
        String from = (String)Session["from"];
        String to = (String)Session["to"];
        String language = (String)Session["language"];
        String genre = (String)Session["genre"];
        String partialTitle = (String)Session["title"];

        Session["SelectedIndex"] = disha.SelectedIndex;

        int fromYear, toYear;
        fromYear = 0;
        toYear = 9999;

        if (from != "")
            fromYear = Convert.ToInt16(from);
        if (to != "")
            toYear = Convert.ToInt16(to);

        var movie =
               from m in database.Movies
               from p in database.Persons
               from pr in database.PersonRoles
               from g in database.Genres
               from mg in database.MovieGenres
               from pf in database.Performers
               where (partialTitle == "" || m.title.Contains(partialTitle)) &&
               m.releaseYear >= fromYear &&
               m.releaseYear <= toYear &&
               (director == "" || (p.name == director &&
                                           pr.personId == p.personId &&
                                           pr.roleId == 3 &&
                                           m.director == pr.personRoleId)) &&
                (genre == "" || (mg.movieId == m.movieId &&
                mg.genreId == g.genreId &&
                g.description == genre)) &&
                (language == "" || (language == m.language))
               select  m.title;

        disha.Items.Clear();
        try
        {
            foreach (var a in movie)
            {
                if (!(disha.Items.Contains(new ListItem(a.ToString()))))
                {
                    disha.Items.Add(new ListItem(a.ToString()));
                }
            }
        }

        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        if (actor != "")
        {
            var moviesByActrors = from m in database.Movies
                                  from p in database.Persons
                                  from pr in database.PersonRoles
                                  from g in database.Genres
                                  from pf in database.Performers

                                  where (p.name.Trim() == actor &&
                                  p.personId == pr.personId &&
                                  (pr.roleId == 1 || pr.roleId == 2) &&
                                   pr.personRoleId == pf.personRoleId &&
                                   pf.movieId == m.movieId)
                                  select m.title;
            List<String> movieList = new List<String>();

            try
            {
                foreach (var elem in disha.Items)
                    if (moviesByActrors.Contains(elem))
                        movieList.Add((String)elem);


                disha.Items.Clear();
                foreach (var item in movieList)
                    disha.Items.Add(new ListItem(item));
            }            
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        disha.SelectedIndex = (int)Session["SelectedIndex"];
        String value = disha.SelectedItem.Text;
        Session["dishu"] = value;
            Server.Transfer("MovieInfo.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {  
        Server.Transfer("MasterPage.aspx");
    }

    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        String value = disha.SelectedItem.Text;
        Session["dishu"] = value;
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
     
    }
    protected void Hello(object sender, EventArgs e)
    {

    }
}