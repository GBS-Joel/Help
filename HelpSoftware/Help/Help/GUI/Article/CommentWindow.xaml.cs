using Help.EF;
using Help.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Help
{
  public partial class CommentWindow : HelpUserControl
  {
    public CommentWindow()
    {
      InitializeComponent();
      LoadComments();
    }

    public void LoadComments()
    {
      //TODO Load only relevant Comments
      var qry = from ac in HelpContext.Instance.ArticleComments
                select ac;
      List<ArticleComment> lst = qry.ToList();
      List<CommentListBoxItem> lstbox = new List<CommentListBoxItem>();
      foreach (ArticleComment item in lst)
      {
        CommentListBoxItem itembox = new CommentListBoxItem(item);
        lstbox.Add(itembox);
      }
      lboxTop.ItemsSource = lstbox;
    }

    private void test_Click(object sender, RoutedEventArgs e)
    {
      var qry = from b in HelpContext.Instance.Articles
                select b;
      Article a = qry.FirstOrDefault();

      var qry1 = from us in HelpContext.Instance.Users
                 select us;

      User use = qry1.FirstOrDefault();

      ArticleComment comment = new ArticleComment()
      {
        Comment = "Fault",
        CommentArticle = a,
        CommentTime = DateTime.Now,
        CommentTitle = "Title",
        UserComment = use
      };

      HelpContext.Instance.ArticleComments.Add(comment);
      HelpContext.Instance.SaveChanges();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      LoadComments();
    }
  }
}