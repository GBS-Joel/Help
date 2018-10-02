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
      HelpContext.Instance.DeleteEntity((IHelpEntity)entity);
    }

    public void DeleteEntity(List<T> entities)
    {
      foreach (var item in entities)
      {
        HelpContext.Instance.DeleteEntity((IHelpEntity)item);
      }
    }

    public abstract List<T> GetAllEntities();

    public abstract T GetEntityByID(int id);

    public int Insert(T entity)
    {
      return 0;
    }

    public void ReloadEntity(T entity)
    {
      HelpContext.Instance.Entry((IHelpEntity)entity).Reload();
    }

    public virtual void UpdateCount()
    {
      Count = GetAllEntities().Count;
    }

    public void UpdateEntity(T entity)
    {

    }

    T IHelpService<T>.GetEntityByID(int id)
    {
      return default(T);
    }
  }
}