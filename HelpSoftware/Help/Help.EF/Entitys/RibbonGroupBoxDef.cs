using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class RibbonGroupBoxDef : IHelpEntity
  {
    [Key]
    public virtual int ID_RibbonGroupBoxDef { get; set; }

    public virtual string Name { get; set; }

    public virtual string Header { get; set; }

    public virtual List<RibbonButtonDef> RibbonButtonDefs { get; set; }

    public string ForeGround { get; set; }

    public virtual RibbonTabPageDef RibbonTabPageDef { get; set; }

    [Timestamp]
    public virtual byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "RibbonGroupBoxDef";
    }

    public int GetID()
    {
      return ID_RibbonGroupBoxDef;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }

    //public virtual FontWeight FontWeight { get; set; }
  }
}

//RibbonGroupBox in XAML
/*
 * <Fluent:RibbonGroupBox Header="Selektion" Foreground="#FF2B579A" FontWeight="Normal">
*/
