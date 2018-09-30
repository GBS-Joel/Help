using Help.EF;
using Help.Library;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Windows;

namespace Help
{
  public partial class CreateArticle : HelpUserControl
  {
    public List<CheckItem> list = new List<CheckItem>();

    public List<CheckItem> lst1 = new List<CheckItem>();

    public List<CheckItem> listopic = new List<CheckItem>();

    public List<CheckItem> lsttops = new List<CheckItem>();

    public CreateArticle()
    {
      InitializeComponent();
      LoadTags();
      LoadTopics();
      CheckItem item = new CheckItem()
      {
        Display = "Test",
        Index = 0,
        KeyValue = 0
      };

      CheckItem item2 = new CheckItem()
      {
        Display = "Test",
        Index = 0,
        KeyValue = 0
      };

      lst1.Add(new CheckItem()
      {
        KeyValue = 0,
        Display = "item 1"
      });

      lst1.Add(new CheckItem()
      {
        KeyValue = 1,
        Display = "item 2"
      });


      list.Add(item);
      list.Add(item2);

      test.CheckListArray = list;
      test.CheckedValue = lst1;

      test1.CheckListArray = listopic;
      test1.CheckedValue = lsttops;
      DataContext = this;
    }


    public void LoadTags()
    {
      var qry = from t in HelpContext.Instance.Tags
                select t;
      foreach (var item in qry.ToList())
      {
        lst1.Add(new CheckItem(item.ID_Tag, item.TagName));
        list.Add(new CheckItem(item.ID_Tag, item.TagName));
      }
    }

    public void LoadTopics()
    {
      var qry = from t in HelpContext.Instance.Topics
                select t;
      foreach (var item in qry.ToList())
      {
        lsttops.Add(new CheckItem(item.ID_Topic, item.Name));
        listopic.Add(new CheckItem(item.ID_Topic, item.Name));
      }

    }

    private void btnPreview_Click(object sender, RoutedEventArgs e)
    {
      //string b = a.Replace("\r\n", Environment.NewLine + "" + Environment.NewLine);

      Article art = new Article()
      {
        //ArticleText = b
      };
      AppContext.WindowManagerInstance.OpenNewWindow(new ArticlePreview(art));
    }

    private void btnNext_Click(object sender, RoutedEventArgs e)
    {
      //Create Article Opening
      ArticleOpening opening = new ArticleOpening()
      {
        Author = AppContext.LoggedInUser,
        IsPublic = true,
        Title = tbTitle.Text
      };
      HelpContext.Instance.ArticleOpenings.Add(opening);
      List<ArticleOpeningTag> otags = new List<ArticleOpeningTag>();
      foreach (var item in lst1)
      {
        if (item.IsChecked)
          otags.Add(new ArticleOpeningTag()
          {

          });
      }
    }
  }
}