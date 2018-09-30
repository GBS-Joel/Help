using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class BackstageButtonDef : IHelpEntity
  {
    [Key]
    public int ID_BackstageButtonDef { get; set; }

    public string Name { get; set; }

    public bool SeperatorAfter { get; set; }

    //Index 0 is at the top and max is at the bottom

    public int Order { get; set; }

    public bool IsFirst { get; set; }

    public bool IsLast { get; set; }

    public string UID { get; set; }

    public string Header { get; set; }

    public string KeyTip { get; set; }

    public string Command { get; set; }

    public int RequiredPermission { get; set; }

    public bool IsDefault { get; set; }

    public string Image { get; set; }

    [Timestamp]
    public byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "BackstageButtonDef";
    }

    public int GetID()
    {
      return ID_BackstageButtonDef;
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}