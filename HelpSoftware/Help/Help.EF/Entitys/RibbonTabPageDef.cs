using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class RibbonTabPageDef : IHelpEntity
  {
    [Key]
    public virtual int ID_RibbonTagPageDef { get; set; }

    public virtual string TabHeader { get; set; }

    public virtual string Name { get; set; }

    public virtual List<RibbonGroupBoxDef> GroupBoxes { get; set; }

    public virtual int RequiredPermission { get; set; }

    public virtual string KeyTip { get; set; }

    [Timestamp]
    public virtual byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "RibbonTabPageDef";
    }

    public int GetID()
    {
      return ID_RibbonTagPageDef;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}