using System.ComponentModel;

namespace Help.Library
{
  public interface IModel : INotifyPropertyChanged
  {
    /// <summary>
    /// The Module to Bind to
    /// </summary>
    IModuleElement Owner { get; set; }

    /// <summary>
    /// Loads the Data from the Database. DO NOT LOAD in ctor
    /// </summary>
    void LoadData();

    /// <summary>
    /// Performed when the User Presses F5 or the Window gained Focus again
    /// The Data that is not saved yet should not be discarded
    /// </summary>
    void ReloadData();

    /// <summary>
    /// Returns the DataID of the Current Element
    /// </summary>
    /// <returns></returns>
    int GetID();

    /// <summary>
    /// Gets Called when the User calls abbrechen on the current window
    /// </summary>
    void ReloadAndDumpCurrentChanged();

    void NotifyChanged();

    void NotifyChanged(string PropertyName);

    void Save();

    bool IsSaved { get; set; }
  }
}