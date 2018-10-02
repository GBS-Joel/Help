using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class Topic : IHelpEntity
  {
    [Key]
    public virtual int ID_Topic { get; set; }

    public virtual string Name { get; set; }

    public virtual string Description { get; set; }

    public virtual Topic ParentTopic { get; set; }

    public virtual List<Topic> ChildTopics { get; set; }

    public virtual DateTime CreatedDate { get; set; }

    public virtual User Author { get; set; }

    public virtual User LastModifier { get; set; }

    public virtual DateTime LastModified { get; set; }

    [Timestamp]
    public byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "Topic";
    }

    public int GetID()
    {
      return ID_Topic;
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}