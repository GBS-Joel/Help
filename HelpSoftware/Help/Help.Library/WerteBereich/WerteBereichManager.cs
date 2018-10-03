using Help.EF;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Help.Library
{
  public class WerteBereichManager
  {
    private WerteBereichValidator WerteBereichValidator { get; set; }

    private WerteBereichDefValidator WerteBereichDefValidator { get; set; }

    private WerteBereichDefManager WerteBereichDefManager { get; set; }

    public List<IWerteBereichDef> RegisteredWerteBereichDefs { get; set; }

    public WerteBereichManager()
    {
      RegisterWerteBereichs();
      RegisteredWerteBereichDefs = new List<IWerteBereichDef>();
      WerteBereichValidator = new WerteBereichValidator();
      WerteBereichDefManager = new WerteBereichDefManager();
      var wb = GetWerteBereichByName("ActivityAction", "Update", WerteBereichValueDataType.text);
    }

    public void RegisterWerteBereichs()
    {
      WerteBereichDefRegisterer.RegisteredWerteBereichDefs();
      WerteBereichDefRegisterer.UdpateRegisteredWertebereichs();
    }

    public void RegisterNewWerteBereichDef(IWerteBereichDef def)
    {
      RegisteredWerteBereichDefs.Add(def);
    }

    public void GetWerteBereichDefByName(string Name)
    {

    }

    //Example 
    //ActivityAction
    //"Update"
    //It can also be ActivityAction_Update
    //TODO Implement the Service
    public WerteBereich GetWerteBereichByName(string Name, WerteBereichValueDataType Type)
    {
      return null;
    }

    public WerteBereich GetWerteBereichByName(string Name, string Value, WerteBereichValueDataType Type)
    {
      AppContext.Logger.Debug("Getting WerteBereich for Name " + Name + " and Value " + Value);
      List<WerteBereichValueRangeItem> Items = new List<WerteBereichValueRangeItem>();
      try
      {
        WertebereichDef wertebereichDef = WerteBereichDefManager.GetWertebereichDef(Name);
        var getwb = from w in HelpContext.Instance.WerteBereichs
                    where w.Value == Value
                    where w.WertebereichDef.ID_WertebereichDef == wertebereichDef.ID_WertebereichDef
                    select w;
        return getwb.FirstOrDefault();
      }
      catch (Exception)
      {
        // throw;
        return null;
      }
    }

    public WerteBereich GetWerteBereichByFullString(string Name)
    {
      return null;
    }
  }
}



/*
public List<WerteBereich> GetWerteBereichValueByName(string Name)
{
  var qry = from h in HelpContext.Instance.WerteBereichs
            where h.WertebereichDef.Name == Name
            select h;
  List<WerteBereich> lst = qry.ToList();
  foreach (var item in lst)
  {
    WerteBereichValidator.ValidateWerteBereichValues(item);
  }
  return lst;
}
*/

//public WertebereichDef GetWertebereichDefByName(string Name)
//{
//  //var qry = from w in HelpContext.Instance.WertebereichDefs
//  //          where w.Name == Name
//  //          select w;
//  //WertebereichDef wertebereichDef = qry.FirstOrDefault();
//  //if (wertebereichDef != null)
//  //{
//  //  return wertebereichDef;
//  //}
//  //else
//  //{
//  //  AppContext.Logger.Warn("WerteBeichDef with Value " + Name + " Not Found!", "WerteBereichManager");
//  //  throw new WerteBereichNotFoundException(Name);
//  //}
//}