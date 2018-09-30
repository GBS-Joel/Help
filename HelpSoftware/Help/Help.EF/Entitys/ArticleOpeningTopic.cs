using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.EF
{
  public class ArticleOpeningTopic : IHelpEntity
  {
    [Key]
    public int ID_ArticleOpeningTopic { get; set; }

    public ArticleOpening ArticleOpening { get; set; }

    public Topic Topic { get; set; }

    public byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "ArticleOpeningTopic";
    }

    public int GetID()
    {
      return ID_ArticleOpeningTopic;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}