using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class HelpContext : DbContext
  {
    public static HelpContext Instance { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Article> Articles { get; set; }

    public DbSet<Topic> Topics { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public DbSet<ViewHistory> ViewHistory { get; set; }

    public DbSet<UserFavedArticles> UserFavedArticles { get; set; }

    public DbSet<UserLikedArticel> UserLikedArticels { get; set; }

    public DbSet<Activity> Activities { get; set; }

    public DbSet<ActivityAction> ActivityActions { get; set; }

    public DbSet<UserWatchArticle> UserWatchArticles { get; set; }

    public DbSet<ArticleComment> ArticleComments { get; set; }

    public DbSet<ArticleTag> ArticleTags { get; set; }

    public DbSet<LoginHistory> LoginHistorys { get; set; }

    public DbSet<Setting> Settings { get; set; }

    public DbSet<UserSetting> UserSettings { get; set; }

    public DbSet<SearchHistory> SearchHistories { get; set; }

    public DbSet<Note> Notes { get; set; }

    public DbSet<ArticleNote> ArticleNotes { get; set; }

    public DbSet<MailActivity> MailActivities { get; set; }

    public DbSet<ReviewedArticle> ReviewedArticles { get; set; }

    public DbSet<ArticleNomination> ArticleNominations { get; set; }

    public DbSet<BugReport> BugReports { get; set; }

    public DbSet<SystemSetting> SystemSettings { get; set; }

    public DbSet<ArticleProposal> ArticleProposals { get; set; }

    public DbSet<ArticleViewHistory> ArticleViewHistories { get; set; }

    public HelpContext() : base(Connection.ConnectionString)
    {

    }

    public static void InitInstance()
    {
      Instance = new HelpContext();
      Instance.Database.Initialize(true);
      Instance.Configuration.ProxyCreationEnabled = true;
      Instance.Configuration.LazyLoadingEnabled = true;
    }
  }
}