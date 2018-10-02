using Help.EF;
using System.Collections.Generic;

namespace Help.Library
{
  public interface IWerteBereichDef
  {
    WertebereichDef GetWertebereichDef();

    List<WerteBereichValueRangeItem> GetWerteBereichValueRangeItems();

    bool CheckIfAllreadyInDB();

    string GetName();

    void RegisterWerteBereich();
  }
}