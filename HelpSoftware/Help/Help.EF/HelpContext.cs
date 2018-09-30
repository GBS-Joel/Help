using System;
using System.Data.Entity;
using System.Windows;

namespace Help.EF
{
  public class HelpContext : DbContext
  {
    public static bool IsInitialized { get; set; }

    public static Action SaveMethod { get; set; }

    public static HelpContext Instance { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Article> Articles { get; set; }

    public DbSet<Topic> Topics { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public DbSet<ViewHistory> ViewHistory { get; set; }

    public DbSet<UserFavedArticles> UserFavedArticles { get; set; }

    public DbSet<UserLikedArticel> UserLikedArticels { get; set; }

    public DbSet<Activity> Activities { get; set; }

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

    public DbSet<DashBoard> DashBoards { get; set; }

    public DbSet<DashBoardUser> DashBoardUsers { get; set; }

    public DbSet<Translation> Translations { get; set; }

    public DbSet<PinWallComment> PinWallComments { get; set; }

    public DbSet<ChatPreview> ChatPreview { get; set; }

    public DbSet<ChatMessage> ChatMessage { get; set; }

    public DbSet<WrongTranslation> WrongTranslations { get; set; }

    public DbSet<Chat> Chats { get; set; }

    public DbSet<AppError> AppErrors { get; set; }

    public DbSet<Configuration> Configurations { get; set; }

    public DbSet<OpenConnection> OpenConnections { get; set; }

    public DbSet<APIRequest> APIRequests { get; set; }

    public DbSet<Verify> Verifies { get; set; }

    public DbSet<Booklet> Booklets { get; set; }

    public DbSet<BookletArticle> BookletArticles { get; set; }

    //public DbSet<Project> Projects { get; set; }

    //public DbSet<ProjectUser> ProjectUser { get; set; }

    public DbSet<LogItem> LogItems { get; set; }

    public DbSet<WertebereichDef> WertebereichDefs { get; set; }

    public DbSet<WerteBereich> WerteBereichs { get; set; }

    public DbSet<WerteBereichValueRange> WerteBereichValueRanges { get; set; }

    public DbSet<WerteBereichValueRangeItem> WerteBereichValueRangeItems { get; set; }

    public DbSet<RibbonButtonDef> RibbonButtonDefs { get; set; }

    public DbSet<RibbonGroupBoxDef> RibbonGroupBoxDefs { get; set; }

    public DbSet<RibbonTabPageDef> RibbonTabPageDefs { get; set; }

    public DbSet<LinkItem> LinkItems { get; set; }

    public DbSet<BackstageButtonDef> BackstageButtonDefs { get; set; }

    public DbSet<Organization> Organizations { get; set; }

    public DbSet<Team> Teams { get; set; }

    public DbSet<TeamMessage> TeamMessages { get; set; }

    public DbSet<ChangeLog> ChangeLogs { get; set; }

    public DbSet<ImageEntry> ImageEntries { get; set; }

    public DbSet<ArticleOpening> ArticleOpenings { get; set; }

    public DbSet<ArticleOpeningTag> ArticleOpeningTags { get; set; }

    public DbSet<ArticleOpeningTopic> ArticleOpeningTopics { get; set; }

    public HelpContext() : base(Connection.ConnectionString)
    {
    }

    public static void InitInstance()
    {
      try
      {
        Instance = new HelpContext();
        Instance.Database.Initialize(true);
        Instance.Configuration.ProxyCreationEnabled = true;
        Instance.Configuration.LazyLoadingEnabled = true;
        Instance.Configuration.AutoDetectChangesEnabled = true;
        Instance.Configuration.ValidateOnSaveEnabled = true;
        IsInitialized = true;
      }
      catch (Exception)
      {
        MessageBox.Show("The Database has changed. Contact you Network Administrator");
      }
    }

    public void DeleteEntity(IHelpEntity entity)
    {
      Instance.Entry(entity).State = EntityState.Deleted;
      Instance.SaveChanges();
    }

    /// <summary>
    /// Saves all Entitys and DOES Write Change Log Items
    /// </summary>
    /// <returns></returns>
    public override int SaveChanges()
    {
      SaveMethod?.Invoke();
      return base.SaveChanges();
    }

    /// <summary>
    /// Saves all Entitys and does NOT Write Change Log Items
    /// </summary>
    public void Save()
    {
      base.SaveChanges();
    }
  }
}