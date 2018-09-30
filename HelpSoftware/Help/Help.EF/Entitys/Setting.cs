using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class Setting : IHelpEntity
  {
    [Key]
    public virtual int ID_UserSetting { get; set; }

    public virtual string DefaultValue { get; set; }

    //public virtual WerteBereich WertebereichValue { get; set; }

    public virtual string SettingName { get; set; }

    public virtual DateTime Created { get; set; }

    public virtual int Type { get; set; }

    public virtual List<object> ValidValues { get; set; }

    [Timestamp]
    public virtual byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "Setting";
    }

    public int GetID()
    {
      return ID_UserSetting;
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}