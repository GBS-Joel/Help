using System;
using System.Collections;
using System.Net.Sockets;
using System.Text;

namespace Help.Server
{
  public static class ChatService
  {
    public static Hashtable clientsList = new Hashtable();

    public static TcpListener ServerSocket { get; set; }

    public static TcpClient ClientSocket { get; set; }

    public static void StartUpService()
    {

      ServerSocket = new TcpListener(8888);
      ClientSocket = default(TcpClient);
      ServerSocket.Start();
      Console.WriteLine("Chat Server Started ....");
    }

    public static void DoService()
    {
      ClientSocket = ServerSocket.AcceptTcpClient();
      byte[] bytesFrom = new byte[10025];
      string dataFromClient = null;
      NetworkStream networkStream = ClientSocket.GetStream();
      networkStream.Read(bytesFrom, 0, (int)ClientSocket.ReceiveBufferSize);
      dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
      dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
      clientsList.Add(dataFromClient, ClientSocket);
      Broadcast(dataFromClient + " Joined ", dataFromClient, false);
      Console.WriteLine(dataFromClient + " Joined chat room ");
      ClientHandler client = new ClientHandler();
      client.startClient(ClientSocket, dataFromClient, clientsList);
    }

    public static void Broadcast(string msg, string uName, bool flag)
    {
      foreach (DictionaryEntry Item in clientsList)
      {
        TcpClient broadcastSocket;
        broadcastSocket = (TcpClient)Item.Value;
        NetworkStream broadcastStream = broadcastSocket.GetStream();
        Byte[] broadcastBytes = null;

        if (flag == true)
        {
          broadcastBytes = Encoding.ASCII.GetBytes(uName + " says : " + msg);
        }
        else
        {
          broadcastBytes = Encoding.ASCII.GetBytes(msg);
        }

        broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
        broadcastStream.Flush();
      }
    }

    public static void RestartService()
    {
      throw new NotImplementedException();
    }

    public static void ShutDownService()
    {
      ClientSocket.Close();
      ServerSocket.Stop();
      Console.WriteLine("exit");
      Console.ReadLine();
    }
  }
}