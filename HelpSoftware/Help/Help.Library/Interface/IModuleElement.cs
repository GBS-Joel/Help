using System.ComponentModel;

namespace Help.Library
{
  public interface IModuleElement : IRequirePermission, IProvideRibbonItems, IAllowNew, INotifyPropertyChanged, IAutoStretch
  {
    /// <summary>
    /// Will be called AFTER the Element is in the WPF Tree
    /// </summary>
    void DisplayData();

    /// <summary>
    /// Will be called BEFORE the Element is in the WPF Tree
    /// </summary>
    void HandleInitLoad();

    /// <summary>
    /// The Type of The Window
    /// </summary>
    WindowType WindowType { get; set; }

    /// <summary>
    /// The NAme of the COntrol
    /// Is not in use Currently and is just for debug purposes
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// The Name that gets Displayed in the Tab Header
    /// This will be auto Translated if the Property AutoTranslate is set to true (default)
    /// </summary>
    string Title { get; set; }

    /// <summary>
    /// Indicates wheter the The window may be closed at this state
    /// set to false if the current window is not saved
    /// </summary>
    bool CanClose { get; set; }

    /// <summary>
    /// Will be performed after the user perfomed a loggin when the window is open
    /// </summary>
    void PerformAfterLogin();

    /// <summary>
    /// Auto Bind to this
    /// </summary>
    IModel Model { get; set; }

    /// <summary>
    /// REturn the Bidning Model
    /// It returns the Ref to the Object but not the object itself
    /// </summary>
    /// <returns></returns>
    IModel GetModel();

    /// <summary>
    /// Will be called right after the constructor
    /// </summary>
    void StartUp();

    /// <summary>
    /// Indicates wether the window is saved
    /// </summary>
    bool IsSaved { get; set; }
  }
}