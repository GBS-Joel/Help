﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class LinkItem : IHelpEntity
  {
    [Key]
    public int ID_LinkItem { get; set; }

    public string Link { get; set; }

    public string DisplayName { get; set; }

    public int RequiredPermission { get; set; }

    [Timestamp]
    public virtual byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "LinkItem";
    }

    public int GetID()
    {
      return ID_LinkItem;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}