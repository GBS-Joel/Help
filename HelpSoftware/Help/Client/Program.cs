using Help.EF;
using Help.Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Help
{
  public static class Program
  {
    public static string ConvertStringToHex(string asciiString)
    {
      string hex = "";
      foreach (char c in asciiString)
      {
        int tmp = c;
        hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
      }
      return hex;
    }

    public static string ConvertHexToString(string HexValue)
    {
      string StrValue = "";
      while (HexValue.Length > 0)
      {
        StrValue += System.Convert.ToChar(System.Convert.ToUInt32(HexValue.Substring(0, 2), 16)).ToString();
        HexValue = HexValue.Substring(2, HexValue.Length - 2);
      }
      return StrValue;
    }





    //Decrypt


    private static void Main(string[] args)
    {
      string f = "";
      string text = "# ![Markdown Here logo](https://raw.github.com/adam-p/markdown-here/master/src/common/images/icon48.png) Markdown Here    http://markdown-here.com <br>  [**Get it for Chrome.**](https://chrome.google.com/webstore/detail/elifhakcjgalahccnjkneoccemfahfoa)<br>  [**Get it for Firefox.**](https://addons.mozilla.org/en-US/firefox/addon/markdown-here/)<br>  [**Get it for Safari.**](https://s3.amazonaws.com/markdown-here/markdown-here.safariextz)<br>  [**Get it for Thunderbird and Postbox.**](https://addons.mozilla.org/en-US/thunderbird/addon/markdown-here/)<br>  [**Get it for Opera.**](https://addons.opera.com/en/extensions/details/markdown-here/)<br>  [**Discuss it and ask questions in the Google Group.**](https://groups.google.com/forum/?fromgroups#!forum/markdown-here/)<br>    *Markdown Here* is a Google Chrome, Firefox, Safari, Opera, and Thunderbird extension that lets you write email<sup>&dagger;</sup> in Markdown<sup>&Dagger;</sup> and render them before sending. It also supports syntax highlighting (just specify the language in a fenced code block).    Writing email with code in it is pretty tedious. Writing Markdown with code in it is easy. I found myself writing email in Markdown in the Github in-browser editor, then copying the preview into email. This is a pretty absurd workflow, so I decided create a tool to write and render Markdown right in the email.    To discover what can be done with Markdown in *Markdown Here*, check out the [Markdown Here Cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Here-Cheatsheet) and the other [wiki pages](https://github.com/adam-p/markdown-here/wiki).    <sup>&dagger;: And Google Groups posts, and Blogger posts, and Evernote notes, and Wordpress posts! [See more](#compatibility).</sup><br>  <sup>&Dagger;: And TeX mathematical formulae!</sup>    ![screenshot of conversion](https://raw.github.com/adam-p/markdown-here/master/store-assets/markdown-here-image1.gimp.png)    ### Table of Contents  **[Installation Instructions](#installation-instructions)**<br>  **[Usage Instructions](#usage-instructions)**<br>  **[Troubleshooting](#troubleshooting)**<br>  **[Compatibility](#compatibility)**<br>  **[Notes and Miscellaneous](#notes-and-miscellaneous)**<br>  **[Building the Extension Bundles](#building-the-extension-bundles)**<br>  **[Next Steps, Credits, Feedback, License](#next-steps)**<br>    ## Installation Instructions    ### Chrome    #### Chrome Web Store    Go to the [Chrome Web Store page for *Markdown Here*](https://chrome.google.com/webstore/detail/elifhakcjgalahccnjkneoccemfahfoa) and install normally.    After installing, make sure to reload your webmail or restart Chrome!    #### Manual/Development    1. Clone this repo.  2. In Chrome, open the Extensions settings. (Wrench button, Tools, Extensions.)  3. On the Extensions settings page, click the checkbox.  4. Click the now-visible button. Navigate to the directory where you cloned the repo, then the `src` directory under that.  5. The *Markdown Here* extension should now be visible in your extensions list.  6. Reload your webmail page (and maybe application) before trying to convert an email.  ";
      Console.Write(text.Replace("<", "&beg").Replace(">", "&end"));
      Console.ReadKey();
      //string output = ConvertStringToHex(text);
      //string input = ConvertHexToString(output);

      //byte[ ] arr = System.Text.Encoding.ASCII.GetBytes(text);
      //string bin = StringToBinary(text);

      //string res = HashGenerator.Hash("test");
      //Console.WriteLine(res);
      //Console.ReadKey();

      //  var pipeline = new LearningPipeline();

      //  var text = new TextLoader(Path).CreateFrom<ArticleData>(separator: ',');
      //  pipeline.Add(text);

      //  pipeline.Add(new Dictionarizer("Label"));
      //  pipeline.Add(new TextFeaturizer("Features", "ArticlePreview", "ArticleTitle", "Tag1", "Tag2", "Topic1", "Topic2", "Created"));

      //  pipeline.Add(new StochasticDualCoordinateAscentClassifier());

      //  pipeline.Add(new PredictedLabelColumnOriginalValueConverter() { PredictedLabelColumn = "PredictedLabel" });

      //  var model = pipeline.Train<ArticleData, ArticlePrediction>();

      //  ArticleData dat = new ArticleData()
      //  {
      //    ArticlePreview = "Preview",
      //    ArticleTitle = "Title",
      //    Created = DateTime.Now.ToString(),
      //    Tag1 = "Tag",
      //    Tag2 = "",
      //    Topic1 = "",
      //    Topic2 = ""
      //  };
      //  var res = model.Predict(dat);

      //  var eval = new BinaryClassificationEvaluator();

      //  var testData = new TextLoader(Path).CreateFrom<ArticleData>(separator: ',');

      //  var metrics = eval.Evaluate(model, text);

      //  Console.WriteLine();
      //  Console.WriteLine("PredictionModel quality metrics evaluation");
      //  Console.WriteLine("------------------------------------------");
      //  Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
      //  Console.WriteLine($"Auc: {metrics.Auc:P2}");
      //  Console.WriteLine($"F1Score: {metrics.F1Score:P2}");
      //  Console.ReadKey();
    }

    public static void DoSomething()
    {
      string Path = "";
      HelpContext.InitInstance();
      var qry = from a in HelpContext.Instance.UserLikedArticels
                where a.LikedUser.ID_User == 3
                select a;

      //Get all Articles from the User

      List<Article> articles = new List<Article>();

      foreach (var item in qry.ToList())
      {
        var qerry = from a in HelpContext.Instance.Articles
                    where a.ID_Article == item.LikedArticel.ID_Article
                    select a;
        articles = qerry.ToList();
      }

      var r = from ai in HelpContext.Instance.Articles
              select ai;

      StringBuilder builder = new StringBuilder();
      builder.Append("ArticlePreview" + "," + "ArticleTitle" + "," + "Tag1" + "," + "Tag2" + "," + "Topic1" + "," + "Topic2" + "," + "Created" + "," + "Liked" + Environment.NewLine);
      foreach (var item in articles)
      {
        string Tag1 = "";
        string Tag2 = "";
        string Topic1 = "";
        string Topic2 = "";

        if (item.Tags.Count > 0)
        {
          Tag1 = item.Tags[0].TagName;
        }
        if (item.Tags.Count > 1)
        {
          Tag2 = item.Tags[1].TagName;
        }
        if (item.Topics.Count > 0)
        {
          Topic1 = item.Topics[0].Name;
        }
        if (item.Topics.Count > 1)
        {
          Topic2 = item.Topics[1].Name;
        }

        builder.Append(item.ArticlePreview + "," + item.ArticleTitle + "," + Tag1 + "," + Tag2 + "," + Topic1 + "," + Topic2 + "," + item.Created.ToString() + "," + 1 + Environment.NewLine);
      }

      foreach (var item in r.ToList())
      {
        if (!articles.Contains(item))
        {
          string Tag1 = "";
          string Tag2 = "";
          string Topic1 = "";
          string Topic2 = "";

          if (item.Tags.Count > 0)
          {
            Tag1 = item.Tags[0].TagName;
          }
          if (item.Tags.Count > 1)
          {
            Tag2 = item.Tags[1].TagName;
          }
          if (item.Topics.Count > 0)
          {
            Topic1 = item.Topics[0].Name;
          }
          if (item.Topics.Count > 1)
          {
            Topic2 = item.Topics[1].Name;
          }

          builder.Append(item.ArticlePreview + "," + item.ArticleTitle + "," + Tag1 + "," + Tag2 + "," + Topic1 + "," + Topic2 + "," + item.Created.ToString() + "," + 0 + Environment.NewLine);
        }
      }

      using (StreamWriter sw = new StreamWriter(new FileStream(Path, FileMode.Open)))
      {
        sw.WriteLine(builder.ToString());
      }
    }
  }
}

// HelpContext.InitInstance();
//var qry = from u in HelpContext.Instance.Users
//          where u.ID_User == 3
//          select u;
//User a = qry.FirstOrDefault();

//PinWallComment c = new PinWallComment()
//{
//  Author = a,
//  CommentText = "This is a Comment",
//  CommentTime = DateTime.Now,
//  CommentTitle = "Title",
//  IsAnonymous = false,
//  IsDeleted = false,
//  IsPublic = true,
//  User = a
//};
//HelpContext.Instance.PinWallComments.Add(c);
//HelpContext.Instance.SaveChanges();

//string WriteLine = Console.ReadLine();
//string res = HashGenerator.Hash(WriteLine);
//Console.WriteLine(res);
////Console.ReadKey();
//Random random = new Random();

//Color color = Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));

//string a = color.ToString();

//Console.WriteLine(a);
//Console.ReadKey();

//var res = ColorConverter.ConvertFromString(a);
//Color col = (Color)res;

//Console.WriteLine(col.ToString());
//Console.ReadKey();