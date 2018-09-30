using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.EF
{
  public class ImageEntry : IHelpEntity
  {
    [Key]
    public int ID_ImageEntry { get; set; }

    public string ImageName { get; set; }

    public Article Article { get; set; }

    public int LaufNr { get; set; }

    [Timestamp]
    public byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "ImageEntry";
    }

    public int GetID()
    {
      return ID_ImageEntry;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}