using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["director"] = directorText.Text;
        Session["actor"] = actorText.Text;
        Session["from"] = fromText.Text;
        Session["to"] = toText.Text;
        Session["language"] = languageText.Text;
        Session["genre"] = genreText.Text;
        Session["title"] = titleText.Text;
        
        try
        {
            Server.Transfer("MovieList.aspx");
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Server.Transfer("MasterPage.aspx");
    }
}