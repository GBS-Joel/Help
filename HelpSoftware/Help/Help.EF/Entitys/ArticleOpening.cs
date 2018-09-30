using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.EF
{
  public class ArticleOpening : IHelpEntity
  {
    [Key]
    public int ID_ArticleOpening { get; set; }

    public string Title { get; set; }

    public bool IsPublic { get; set; }

    public User Author { get; set; }

    public byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "ArticleOpening";
    }

    public int GetID()
    {
      return ID_ArticleOpening;
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}