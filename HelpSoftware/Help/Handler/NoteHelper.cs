using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class NoteHelper
  {
    public static NoteHelper Instance { get; private set; }

    private NoteHelper()
    {

    }

    public static void InitInstance()
    {
      Instance = new NoteHelper();
      Instance.UpdateDatabase();
    }

    public void SyncDatabase()
    {
      foreach (object item in Enum.GetValues(typeof(Notes)))
      {
        Note n = new Note()
        {
          Created = DateTime.Now,
          NoteName = item.ToString()
        };
        HelpContext.Instance.Notes.Add(n);
      }
      HelpContext.Instance.SaveChanges();
    }

    public void UpdateDatabase()
    {
      var qry = from n in HelpContext.Instance.Notes
                select n;
      List<Note> notes = qry.ToList();
      if (!notes.Any())
      {
        SyncDatabase();
      }
      else
      {
        foreach (var item in Enum.GetValues(typeof(Notes)))
        {
          var q = from n in HelpContext.Instance.Notes
                    where n.NoteName == item.ToString()
                  select n;
          if (!q.Any())
          {
            Note not = new Note()
            {
              Created = DateTime.Now,
              NoteName = item.ToString()
            };
            HelpContext.Instance.Notes.Add(not);
          }
        }
        HelpContext.Instance.SaveChanges();
      }
    }
  }
}