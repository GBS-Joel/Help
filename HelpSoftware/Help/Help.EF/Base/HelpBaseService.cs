using System;
using System.Collections.Generic;

namespace Help.EF
{
  public abstract class HelpBaseService<T> : IHelpService<T>
  {
    public HelpBaseService()
    {
      UpdateCount();
    }

    public virtual int Count { get; set; }

    public void DeleteEntity(T entity)
    {
      throw new NotImplementedException();
    }

    public void DeleteEntity(List<T> entities)
    {
      throw new NotImplementedException();
    }

    public abstract List<T> GetAllEntities();

    public abstract T GetEntityByID(int id);

    public int Insert(T entity)
    {
      throw new NotImplementedException();
    }

    public void ReloadEntity(T entity)
    {
      throw new NotImplementedException();
    }

    public virtual void UpdateCount()
    {
      Count = GetAllEntities().Count;
    }

    public void UpdateEntity(T entity)
    {
      throw new NotImplementedException();
    }

    T IHelpService<T>.GetEntityByID(int id)
    {
      throw new NotImplementedException();
    }
  }
}