using System;
using System.Windows;
using System.Windows.Data;

namespace Help.Library.Controls
{
  public class HelpButtonSave : HelpButton
  {
    private bool IsControlLoaded { get; set; }

    private Action _CustomSaveMethod { get; set; }

    private bool HasCustomSaveMethod { get; set; }

    private Action DefaultSaveMethod { get; set; }

    private bool HasCustomBindProperty { get; set; }

    private string _CustomBindProperty { get; set; }

    public HelpButtonSave()
    {
      FontSize = 14;
      Height = 35;
      VerticalAlignment = VerticalAlignment.Top;
      HorizontalAlignment = HorizontalAlignment.Right;
      Width = 120;
      if (!AppContext.InDesignMode)
      {
        AppContext.Logger.Debug("Start Creating Help Save Button" + Name);
        Loaded += HelpButtonSave_Loaded;
      }
    }

    public Action CustomSaveMethod
    {
      get
      {
        AppContext.Logger.Debug("Get Custom Save Method for Button " + Name);
        return _CustomSaveMethod;
      }
      set
      {
        AppContext.Logger.Debug("Setting Custom Save Method for Button " + Name + " Method: " + value.Method.Name);
        _CustomSaveMethod = value;
        HasCustomSaveMethod = true;
      }
    }

    public string CustomBindProperty
    {
      get
      {
        AppContext.Logger.Debug("Get Custom Bind Property");
        return _CustomBindProperty;
      }
      set
      {
        AppContext.Logger.Debug("Setting Custom Bind Property To " + value);
        _CustomBindProperty = value;
        HasCustomBindProperty = true;
      }
    }

    private void HelpButtonSave_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
      AppContext.Logger.Debug("Save Button Loaded Event");
      DefaultSaveMethod = AppContext.WindowManagerInstance.SaveCurrentWindow;
      LoadContent();
      GenerateBinding();
      IsControlLoaded = true;
      Style = (Style)FindResource("AccentedSquareButtonStyle");
    }

    private void LoadContent()
    {
      AppContext.Logger.Debug("Set Default Content of Save Button To Save");
      if (Content == null)
        Content = AppContext.TranslationManagerInstance.Translate("Speichern");
    }

    private void GenerateBinding()
    {
      if (!IsPermissionHandledInternally)
      {
        if (HasCustomBindProperty)
        {
          AppContext.Logger.Debug("Create Custom Binding to Property " + CustomBindProperty);
          Binding b = new Binding(CustomBindProperty)
          {
            Mode = BindingMode.TwoWay,
            Converter = new InverseBooleanConverter()
          };
          BindingOperations.SetBinding(this, IsEnabledProperty, b);
        }
        else
        {
          AppContext.Logger.Debug("Create Default Binding on Button to IsSaved");
          Binding b = new Binding("IsSaved")
          {
            Mode = BindingMode.TwoWay,
            Converter = new InverseBooleanConverter()
          };
          BindingOperations.SetBinding(this, IsEnabledProperty, b);
        }
      }
    }

    protected override void OnClick()
    {
      AppContext.Logger.Debug("On Click Performed on Button " + Name);
      if (HasCustomSaveMethod)
      {
        AppContext.Logger.Debug("Custom Save Method Invoked");
        CustomSaveMethod.Invoke();
      }
      else
      {
        AppContext.Logger.Debug("Default Save Method Invoked");
        DefaultSaveMethod.Invoke();
      }
    }
  }
}