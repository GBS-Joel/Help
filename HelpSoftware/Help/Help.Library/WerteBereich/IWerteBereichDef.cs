using Help.EF;
using System.Collections.Generic;

namespace Help.Library
{
  public interface IWerteBereichDef
  {
    WertebereichDef GetWertebereichDef();

    bool CheckIfAllreadyInDB();

    string GetName();

    void RegisterWerteBereich();
  }
}