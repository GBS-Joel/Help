using System.ComponentModel;
using Help.Library;

namespace Help
{
  public abstract class BaseModel<T> : IModel
  {
    public abstract IModuleElement Owner { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Gets The ID of the Current Dataset if the ID is not there or not in use 
    /// because of multiple Datasets return 0
    /// </summary>
    /// <returns>The ID of the Current Dataset</returns>
    public abstract int GetID();

    public bool IsSaved { get; set; }

    public virtual void LoadData()
    {
      AppContext.Logger.Debug("Load Data On Model " + GetType());
    }

    public virtual void ReloadAndDumpCurrentChanged()
    {
      AppContext.Logger.Debug("Reload and Dump current Changed Data on " + GetType());
      LoadData();
      NotifyChanged();
    }

    public virtual void NotifyChanged()
    {
      AppContext.Logger.Debug("Notify Property Changed on Model " + GetType());
      var items = WPFHelper.GetPropertyInfos(this);
      if (items != null)
        foreach (var item in items)
        {
          string pname = item.Name;
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(pname));
        }
    }

    public virtual void ReloadData()
    {
      AppContext.Logger.Debug("Reload Data on Window " + GetType());
      NotifyChanged();
    }

    public virtual void Save()
    {
      AppContext.Logger.Debug("Reload Data on Window " + GetType());
    }

    public void NotifyChanged(string PropertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
    }
  }
}