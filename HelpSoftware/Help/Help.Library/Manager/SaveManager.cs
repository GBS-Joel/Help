using Help.EF;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System;

namespace Help.Library
{
  public class SaveManager
  {
    private ChangeTrackerManager ChangeTrackerManagerInstance { get; set; }

    public SaveManager()
    {
      ChangeTrackerManagerInstance = new ChangeTrackerManager();
    }

    public void Save()
    {
      GetAllChangedEntitesAndWriteHistory();
      AppContext.WindowManagerInstance.SetCurrentWindowToSaved();
    }

    private List<DbEntityEntry> GetAllChangedEntities()
    {
      var qry = from e in HelpContext.Instance.ChangeTracker.Entries()
                where e.State != EntityState.Unchanged
                select e;
      List<DbEntityEntry> Entities = new List<DbEntityEntry>();
      foreach (var item in qry.ToList())
      {
        IHelpEntity changedentity = item.Entity as IHelpEntity;
        if (changedentity.GetEntityName() != "ChangeLog")
        {
          Entities.Add(item);
        }
      }
      return Entities;
    }

    private void WriteDeleteChangeLog(List<ChangeLog> Items)
    {
      ChangeTrackerManagerInstance.WriteDeleteTrackerEntry(Items);
    }

    private List<ChangeLog> GetChangeLog(DbEntityEntry Entry)
    {
      var entity = Entry.Cast<IHelpEntity>().Entity;
      if (entity.GetEntityName() != "ChangeLog" && entity.GetEntityName() != "OpenConnection")
      {
        return GetChangeLogItem(entity);
      }
      else
      {
        return null;
      }
    }

    #region Added Get Change Log

    //TODO Refactor to single Method Added Modified and Deleted
    private List<ChangeLog> GetChangeLogAdded(DbEntityEntry Entry)
    {
      var entity = Entry.Cast<IHelpEntity>().Entity;
      if (entity.GetEntityName() != "ChangeLog")
      {
        return GetChangeLogItemAdded(entity);
      }
      else
      {
        return null;
      }
    }

    private int DetectLaufNr()
    {
      var qry = from u in HelpContext.Instance.ChangeLogs
                select u;
      try
      {
        var item = qry.ToList().Last();
        if (item != null)
        {
          return item.LaufNr + 1;
        }
        else
        {
          return 1;
        }
      }
      catch (Exception)
      {
        return 1;
      }
    }

    private List<ChangeLog> GetChangeLogItemAdded(IHelpEntity Entry)
    {
      var currentValues = HelpContext.Instance.Entry(Entry).CurrentValues;
      List<ChangeLog> Items = new List<ChangeLog>();
      int laufnr = DetectLaufNr();
      foreach (string propertyName in currentValues.PropertyNames)
      {
        if (propertyName != "TimeStamp")
        {
          var current = currentValues[ propertyName ];
          Items.Add(new ChangeLog()
          {
            Current = current?.ToString(),
            EntityName = Entry.GetEntityName(),
            Original = null,
            LaufNr = laufnr,
            PropertyName = propertyName
          });
        }
      }
      HelpContext.Instance.Save();
      foreach (var item in Items)
      {
        item.ID_Entity = Entry.GetID();
      }
      return Items;
    }

    #endregion

    private List<ChangeLog> GetChangeLogItem(IHelpEntity Entry)
    {
      if (Entry != null)
      {
        var originalValues = HelpContext.Instance.Entry(Entry).OriginalValues;
        var currentValues = HelpContext.Instance.Entry(Entry).CurrentValues;
        List<ChangeLog> Items = new List<ChangeLog>();
        int laufnr = DetectLaufNr();
        foreach (string propertyName in originalValues.PropertyNames)
        {
          if (propertyName != "TimeStamp")
          {
            var original = originalValues[ propertyName ];
            var current = currentValues[ propertyName ];
            if (!Equals(original, current))
            {
              Items.Add(new ChangeLog()
              {
                ID_Entity = Entry.GetID(),
                Current = current.ToString(),
                EntityName = Entry.GetEntityName(),
                Original = original?.ToString(),
                LaufNr = laufnr,
                PropertyName = propertyName
              });
            }
          }
        }
        return Items;
      }
      return null;
    }

    private void WriteAddChangeLog(List<ChangeLog> Items)
    {
      ChangeTrackerManagerInstance.WriteAddTrackerEntry(Items);
    }

    private void WriteModifiedChangeLog(List<ChangeLog> Items)
    {
      ChangeTrackerManagerInstance.WriteModifiedTrackerEntry(Items);
    }

    private void GetAllChangedEntitesAndWriteHistory()
    {
      foreach (var item in GetAllChangedEntities())
      {
        IHelpEntity entity = item.Entity as IHelpEntity;
        if (entity.GetWriteHistoryEntry())
        {
          switch (item.State)
          {
            case EntityState.Added:
              WriteAddChangeLog(GetChangeLogAdded(item));
              break;
            case EntityState.Deleted:
              WriteDeleteChangeLog(GetChangeLog(item));
              break;
            case EntityState.Modified:
              WriteModifiedChangeLog(GetChangeLog(item));
              break;
          }
        }
      }
    }
  }
}