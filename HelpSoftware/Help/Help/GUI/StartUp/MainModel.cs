using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Help.EF;
using Help.Library;

namespace Help
{
  public class MainModel : BaseModel<MainModel>
  {
    public List<DashBoard> DashBoards { get; set; }

    public List<DashBoardListBoxItem> DashBoardItems { get; set; }

    public List<Article> DiscoverArticles { get; set; }

    public override IModuleElement Owner { get; set; }

    public MainModel ModelInstance { get; set; }

    public MainModel()
    {
      DashBoardItems = new List<DashBoardListBoxItem>();
    }

    public override int GetID()
    {
      return 0;
    }

    public override void LoadData()
    {
      LoadDashBoards();
      LoadDashBoardItems();
      LoadArticles();
      base.LoadData();
    }

    public void LoadArticles()
    {
      DiscoverArticles = HelpService.GetService<ArticleService>().GetAllEntities().Take(3).ToList();
    }

    public void LoadDashBoardItems()
    {
      foreach (var item in DashBoards.Take(7))
      {
        DashBoardItems.Add(new DashBoardListBoxItem(item));
      }
    }

    public void LoadDashBoards()
    {
      DashBoards = HelpService.GetService<DashBoardService>().GetAllEntities();
    }
  }
}