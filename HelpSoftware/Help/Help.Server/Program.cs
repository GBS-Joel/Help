using Help.EF;
using System;
using System.Threading;

namespace Help.Server
{
  public static class Program
  {
    private static void Main()
    {
      StartUpServer();
      Service();
    }

    private static void Service()
    {
      while (true)
      {
        HelpContext.InitInstance();
        InactiveUserService.DoService();
        BugReportsService.DoService();
        // ImageService.DoService();
        NewsletterService.DoService();
        PrintLineDelimiter();
        Thread.Sleep(10000);
      }
    }

    public static void PrintLineDelimiter()
    {
      Console.WriteLine("--------------------" + DateTime.Now.ToLongTimeString() + "--------------------------");
    }

    public static void WriteMessage(string Message)
    {
      Console.WriteLine(DateTime.Now.ToLongTimeString() + "\t" + Message);
    }

    private static void StartUpServer()
    {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("Start UP Server");
      Console.WriteLine("Start Time: " + DateTime.Now.ToLongTimeString());
      ChatService.StartUpService();
      Console.ForegroundColor = ConsoleColor.White;
      PrintLineDelimiter();
    }
  }
}