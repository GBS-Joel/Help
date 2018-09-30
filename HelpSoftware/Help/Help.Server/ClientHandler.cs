using System;
using System.Collections;
using System.Net.Sockets;
using System.Threading;

namespace Help.Server
{
  public class ClientHandler
  {
    private TcpClient clientSocket;
    private string clNo;
    private Hashtable clientsList;

    public void startClient(TcpClient inClientSocket, string clineNo, Hashtable cList)
    {
      this.clientSocket = inClientSocket;
      this.clNo = clineNo;
      this.clientsList = cList;
      Thread ctThread = new Thread(doChat);
      ctThread.Start();
    }

    private void doChat()
    {
      int requestCount = 0;
      byte[] bytesFrom = new byte[10025];
      string dataFromClient = null;
      Byte[] sendBytes = null;
      string serverResponse = null;
      string rCount = null;
      requestCount = 0;

      while ((true))
      {
        try
        {
          requestCount = requestCount + 1;
          NetworkStream networkStream = clientSocket.GetStream();
          networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
          dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
          dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
          Console.WriteLine("From client - " + clNo + " : " + dataFromClient);
          rCount = Convert.ToString(requestCount);
          ChatService.Broadcast(dataFromClient, clNo, true);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
      }
    }
  }
}