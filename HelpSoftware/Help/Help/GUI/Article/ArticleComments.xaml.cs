using Help.EF;
using Help.Library;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Help
{
  public partial class ArticleComments : UserControl
  {
    public Article CurrentArticle { get; set; }

    private List<ArticleComment> Comments { get; set; }

    public ArticleComments(Article Art)
    {
      InitializeComponent();
      CurrentArticle = Art;
      LoadComments();
    }

    public void DisplayComments()
    {
      List<CommentListBoxItem> boxcomments = new List<CommentListBoxItem>();
      foreach (ArticleComment item in Comments)
      {
        CommentListBoxItem boxitem = new CommentListBoxItem(item);
        boxitem.Width = lboxTop.ActualWidth;
        boxcomments.Add(boxitem);
      }
      lboxTop.ItemsSource = boxcomments;
    }

    public void LoadComments()
    {
      Comments = HelpService.GetService<ArticleCommentService>().LoadCommentsFromArticle(CurrentArticle.ID_Article);
    }

    private void test_Click(object sender, RoutedEventArgs e)
    {
      ArticleComment c = new ArticleComment()
      {
        Comment = tbComment.Text,
        CommentArticle = CurrentArticle,
        CommentTime = DateTime.Now,
        CommentTitle = tbCommentTitle.Text,
        UserComment = AppContext.LoggedInUser
      };
      HelpContext.Instance.ArticleComments.Add(c);
      HelpContext.Instance.SaveChanges();
      DisplayComments();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
    }

    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
      DisplayComments();
    }
  }
}