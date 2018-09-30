using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public interface IHelpEntity
  {
    int GetID();

    string GetEntityName();

    Type GetType();

    [Timestamp]
    byte[] TimeStamp { get; set; }

    bool GetWriteHistoryEntry();
  }
}