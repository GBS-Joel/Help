using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.EF
{
  public class ArticleOpeningTag : IHelpEntity
  {
    [Key]
    public int ID_ArticleOpeningTag { get; set; }

    public ArticleOpening ArticleOpening { get; set; }

    public Tag Tag { get; set; }

    public byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "ArticleOpeningTag";
    }

    public int GetID()
    {
      return ID_ArticleOpeningTag;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}
