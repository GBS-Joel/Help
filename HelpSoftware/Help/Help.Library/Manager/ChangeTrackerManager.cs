using Help.EF;
using System.Collections.Generic;

namespace Help.Library
{
  public class ChangeTrackerManager
  {
    /*
     * 1 -> Added
     * 2 -> Deleted
     * 3 -> Modified
     */

    public void WriteAddTrackerEntry(List<ChangeLog> Items)
    {
      foreach (var item in Items)
      {
        item.Action = 1;
        HelpContext.Instance.ChangeLogs.Add(item);
      }
    }

    public void WriteDeleteTrackerEntry(List<ChangeLog> Items)
    {
      if (Items != null)
        foreach (var item in Items)
        {
          item.Action = 2;
          HelpContext.Instance.ChangeLogs.Add(item);
        }
    }

    public void WriteModifiedTrackerEntry(List<ChangeLog> Items)
    {
      foreach (var item in Items)
      {
        item.Action = 3;
        HelpContext.Instance.ChangeLogs.Add(item);
      }
    }
  }
}