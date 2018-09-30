using Help.EF;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Help.Library
{
  public class LinkManager
  {
    public void LoadAndDisplayLinks()
    {
      var defaultlinks = LoadDefaultLinks();
      var additionalLinks = GetLinksForCurrentWindow();
      defaultlinks.AddRange(additionalLinks);
      AppContext.RibbonManagerInstance.DisplayLinkItems(defaultlinks);
    }

    //Die in der Datenbank gespeichert werden überall angezeigt
    public List<LinkItem> LoadDefaultLinks()
    {
      var qry = from l in HelpContext.Instance.LinkItems
                select l;
      return qry.ToList();
    }

    public List<LinkItem> GetLinksForCurrentWindow()
    {
      return AppContext.WindowManagerInstance.CurrentOpenElement.ProvideLinks();
    }

    public void OpenLink(LinkItem item)
    {
    }

    public void OpenLink(string item)
    {
      Process.Start(item);
    }
  }
}