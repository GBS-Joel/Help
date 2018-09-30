using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class RibbonButtonDef : IHelpEntity
  {
    [Key]
    public virtual int ID_RibbonButtonDef { get; set; }

    public virtual string DisplayName { get; set; }

    public virtual string Name { get; set; }

    public virtual string UID { get; set; }

    public virtual string ImageTiny { get; set; }

    public virtual string ImageSmall { get; set; }

    public virtual string ImageLarge { get; set; }

    public virtual string KeyTip { get; set; }

    //public virtual FontVariants FontWeight { get; set; }

    public string Command { get; set; }

    public string ScreenTippTitle { get; set; }

    public string HelpTopic { get; set; }

    public string ScreenTippText { get; set; }

    public string FontColor { get; set; }

    public virtual RibbonGroupBoxDef RibbonGroupBoxDef { get; set; }

    [Timestamp]
    public byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "RibbonButtonDef";
    }

    public int GetID()
    {
      return ID_RibbonButtonDef;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}

//Button Definition in xaml
/*
 *  <Fluent:Button Uid="SelektionAuswahlRibbonButtonTabStart" Header="Selektion Auswählen" KeyTip="C"
                                FontWeight="SemiBold" Icon="/Images/Small/Select.png"
                                LargeIcon="/Images/Large/Select.png"
                                Command="{x:Static local:LBVRibbonCommands.SelektionAuswahl}">
            <Fluent:Button.ToolTip>
              <Fluent:ScreenTip Title="Selektion Auswählen" HelpTopic="Vorhandene Selektion Auswählen"
                                Image="Images/Large/Select.png"
                                Text="Hier können Sie eine Selektion Auswählen"/>
            </Fluent:Button.ToolTip>
          </Fluent:Button>
          */
