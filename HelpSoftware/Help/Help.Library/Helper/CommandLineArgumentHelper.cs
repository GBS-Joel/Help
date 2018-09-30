using System.Collections.Generic;

namespace Help.Library
{
  public static class CommandLineArgumentHelper
  {
    public static bool ProcessCommandLineArgs(IList<string> args)
    {
      if (args == null || args.Count == 0)
        return true;

      if ((args.Count > 1))
      {
        //the first index always contains the location of the exe so we need to check the second index
        //if ((args[ 1 ].ToLowerInvariant() == "/newarticle"))
        //{
        //  CreateArticle a = new CreateArticle();
        //  a.Show();
        //}
        //else if ((args[ 1 ].ToLowerInvariant() == "/proposearticle"))
        //{
        //  ProposeArticle a = new ProposeArticle();
        //  a.Show();
        //}
        //else
        //{
        //  MessageBox.Show("There was an error");
        //}
      }
      return true;
    }
  }
}