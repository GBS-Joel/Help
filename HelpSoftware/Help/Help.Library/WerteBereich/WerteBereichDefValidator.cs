using Help.EF;
using System;
using System.Collections.Generic;

namespace Help.Library
{
  public class WerteBereichDefValidator
  {
    public bool ValidateValueFromWerteBereich(WertebereichDef Def, WerteBereich Value)
    {
      return true;
    }

    public void CheckIfAllDefsAreThere()
    {
      foreach (var item in GetWertebereichDefs())
      {
        if (!CheckIfWerteBereichDefExist(item.Name))
        {
          CreateWerteBereichDef(item.Name);
        }
      }
    }

    private void CreateWerteBereichDef(string name)
    {
      WertebereichDef def = new WertebereichDef()
      {
        Name = name,
        Created = DateTime.Now,
        AutomaticCreated = true
      };
      //HelpContext.Instance.WertebereichDefs.Add(def);
      HelpContext.Instance.SaveChanges();
    }

    public bool CheckIfWerteBereichDefExist(string Name)
    {
      //var qry = from w in HelpContext.Instance.WertebereichDefs
      //          where w.Name == Name
      //          select w;
      //if (qry.Any())
      //{
      //  return true;
      //}
      //else
      //{
      //  return false;
      //}
      return true;
    }

    public WertebereichDef GetWertebereichDef(string Name)
    {
      throw new NotImplementedException();
    }

    public List<WertebereichDef> GetWertebereichDefs()
    {
      return new List<WertebereichDef>();
    }
  }
}