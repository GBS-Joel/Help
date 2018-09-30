using Help.EF;
using Help.Library;
using System.Windows.Controls;

namespace Help
{
  public partial class ChatPreviewListBoxItem : ListBoxItem
  {
    public Chat CurrentChat { get; set; }

    private string Rec { get; set; }

    public ChatPreviewListBoxItem(Chat chat)
    {
      InitializeComponent();
      CurrentChat = chat;
      if (CurrentChat.User1.ID_User == AppContext.LoggedInUser.ID_User)
      {
        tbrec.Text = CurrentChat.User2.Vorname + " " + CurrentChat.User2.Nachname;
      }
      else
      {
        tbrec.Text = CurrentChat.User1.Vorname + " " + CurrentChat.User1.Nachname;
      }
      DataContext = this;
    }
  }
}