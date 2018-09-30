using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF.Entitys
{
  public class QRCodeItem : IHelpEntity
  {
    [Key]
    public int ID_QRCodeItem { get; set; }

    public string Value { get; set; }

    public string QRValue { get; set; }

    public DateTime Created { get; set; }

    [Timestamp]
    public byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "QRCodeItem";
    }

    public int GetID()
    {
      return ID_QRCodeItem;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}