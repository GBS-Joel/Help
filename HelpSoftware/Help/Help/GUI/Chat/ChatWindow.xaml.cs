using Help.EF;
using Help.Library;
using MahApps.Metro.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Help
{
  public partial class ChatWindow : MetroWindow
  {
    public Chat CurrentChatPreview { get; set; }

    private TcpClient clientSocket = new TcpClient();
    private NetworkStream serverStream = default(NetworkStream);
    private string readData = null;

    public ChatWindow()
    {
      InitializeComponent();
    }

    public void LoadChats()
    {
      var qry = from chats in HelpContext.Instance.Chats
                select chats;

      var currentchats = qry.ToList().Where(x => x.User1.ID_User == AppContext.LoggedInUser.ID_User
                              || x.User2.ID_User == AppContext.LoggedInUser.ID_User);
      List<ChatPreviewListBoxItem> items = new List<ChatPreviewListBoxItem>();
      foreach (var item in currentchats)
      {
        ChatPreviewListBoxItem box = new ChatPreviewListBoxItem(item);
        box.Width = tbPreview.ActualWidth;
        items.Add(box);
      }
      tbPreview.ItemsSource = items;
    }

    private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
    {
      LoadChats();
    }

    private void tbPreview_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (tbPreview.SelectedItem != null)
      {
        CurrentChatPreview = ((ChatPreviewListBoxItem)tbPreview.SelectedItem).CurrentChat;
        LoadChatHistory();
      }
    }

    public void LoadChatHistory()
    {
      var qry = from chme in HelpContext.Instance.ChatMessage
                where chme.Chat.ID_Chat == CurrentChatPreview.ID_Chat
                select chme;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      readData = "Conected to Chat Server ...";
      clientSocket.Connect("127.0.0.1", 8888);
      serverStream = clientSocket.GetStream();
      byte[] outStream = System.Text.Encoding.ASCII.GetBytes("this is a test" + "$");
      serverStream.Write(outStream, 0, outStream.Length);
      serverStream.Flush();

      Thread ctThread = new Thread(getMessage);
      ctThread.Start();
    }

    private void getMessage()
    {
      while (true)
      {
        serverStream = clientSocket.GetStream();
        int buffSize = 0;
        byte[] inStream = new byte[10025];
        buffSize = clientSocket.ReceiveBufferSize;
        serverStream.Read(inStream, 0, buffSize);
        string returndata = System.Text.Encoding.ASCII.GetString(inStream);
        readData = "" + returndata;
        MessageBox.Show(readData);
      }
    }
  }
}