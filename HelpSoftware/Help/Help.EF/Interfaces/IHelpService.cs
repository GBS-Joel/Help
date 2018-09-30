using System.Collections.Generic;

namespace Help.EF
{
  public interface IHelpService<K>
  {
    List<K> GetAllEntities();

    K GetEntityByID(int id);

    /// <summary>
    /// Represents the Count of all Entitys
    /// </summary>
    int Count { get; set; }

    void UpdateEntity(K entity);

    void ReloadEntity(K entity);

    int Insert(K entity);

    void DeleteEntity(K entity);

    void DeleteEntity(List<K> entities);

    void UpdateCount();
  }
}