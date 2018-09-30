using Help.EF;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;

namespace Help.Light
{
  public partial class App : Application
  {
    private void Application_Startup(object sender, StartupEventArgs e)
    {
      string[ ] content = File.ReadAllLines(e.Args[ 0 ]);
      string id = "";
      string title = "";
      string text = "";
      id = content[ 0 ];
      title = content[ 1 ];
      for (int i = 2; i < content.Length - 1; i++)
      {
        text += content[ i ] + Environment.NewLine;

      }
      string finaltext = "";
      string t = loadtextfromDB(Convert.ToInt32(id));
      if (t == null || t != "")
      {
        finaltext = t;
      }
      else
      {
        finaltext = text;
      }
      ArticleFile file = new ArticleFile()
      {
        ID = id,
        Text = finaltext,
        Title = title
      };
      MainWindow window = new MainWindow(file);
      window.Show();
    }

    public string loadtextfromDB(int i)
    {
      try
      {
        HelpContext.InitInstance();
        var qry = from a in HelpContext.Instance.Articles
                  where a.ID_Article == i
                  select a;
        return qry.FirstOrDefault().ArticleText;
      }
      catch (Exception)
      {
        return "";
      }
    }
  }
}