using System;
using Help.EF;

namespace Help.Library
{
  public class OpenConnectionHandler
  {
    public OpenConnectionHandler()
    {
      AppContext.Logger.Debug("Init Instance of OpenConnectionHandler()");
      OpenConnection = new OpenConnection();
    }

    private bool HasOpenConnection { get; set; }

    private OpenConnection OpenConnection { get; set; }

    public void UpdateOpenConnection()
    {
      OpenConnection.LastAction = DateTime.Now;
      //HelpContext.Instance.SaveChanges();
    }

    public void RemoveOpenConnection()
    {
      HelpContext.Instance.OpenConnections.Remove(AppContext.OpenConnectionHandler.OpenConnection);
      HelpContext.Instance.SaveChanges();
    }

    public void CreateNewConnection()
    {
      AppContext.Logger.Debug("Create New Open Connection");
      OpenConnection con = new OpenConnection()
      {
        IP = IPAdressHelper.GetLocalIPAddress(),
        MachineName = Environment.MachineName,
        LastAction = DateTime.Now,
        Connected = DateTime.Now
      };
      HelpContext.Instance.OpenConnections.Add(con);
      HelpContext.Instance.SaveChanges();
      OpenConnection = con;
    }

    private void CheckForOpenConnection()
    {
    }
  }
}