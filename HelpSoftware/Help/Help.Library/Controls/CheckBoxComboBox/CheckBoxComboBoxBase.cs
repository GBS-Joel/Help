using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Help.Library
{
  public abstract class HelpCheckComboBoxBase : ComboBox, ICheckCtrlBase
  {
    private bool isRadioMode;

    public bool IsChanged { get; set; }

    public Action OnChanged { get; set; }

    public HelpCheckComboBoxBase(bool isRadioMode) : base()
    {
      this.isRadioMode = isRadioMode;
      DataContextChanged += OnDataContextChanged;
    }

    private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      PropertyInfo _propInfo = null;
      BindingExpression _bindExp = GetBindingExpression(CheckedValueProperty);

      if (_bindExp != null && _bindExp.ParentBinding != null && _bindExp.ParentBinding.Path != null)
      {
        if (e.NewValue != null)
        {
          _propInfo = e.NewValue.GetType().GetProperty(_bindExp.ParentBinding.Path.Path);
        }
        else
        {
          if (_bindExp.DataItem != null)
          {
            _propInfo = _bindExp.DataItem.GetType().GetProperty(_bindExp.ParentBinding.Path.Path);
          }
        }

        if (_propInfo != null)
        {
          CreateViewModel(_propInfo.PropertyType);
        }
      }
    }

    public void CreateViewModel(Type boundType)
    {
      if (boundType == null)
      {
        return;
      }
      if (CheckViewModel == null || CheckViewModel.BoundType != boundType)
      {
        Type _viewBase = typeof(CheckViewModel<>);
        Type _viewType = _viewBase.MakeGenericType(boundType);

        CheckViewModel = (ICheckViewModel)Activator.CreateInstance(_viewType);
        CheckViewModel.HostParent = this;
        CheckViewModel.IsRadioMode = isRadioMode;

        if (CheckListArray != null)
        {
          List<CheckItem> _itemList = new List<CheckItem>();
          foreach (CheckItem _checkItem in CheckListArray)
          {
            _itemList.Add(_checkItem);
          }
          CheckViewModel.CheckItems = _itemList;
        }
        else
        {
          CheckViewModel.InitDiscovery();
        }
      }

      if (CheckViewModel != null && ItemsSource == null)
      {
        this.ItemsSource = this.CheckViewModel.CheckItems;
        this.DisplayMemberPath = "Display";
        this.SelectedValuePath = "KeyValue";
        if (this.isRadioMode)
        {
          //  radio
          this.IsTextSearchEnabled = true;
          this.IsEditable = true;
          this.IsReadOnly = false;
          this.IsSynchronizedWithCurrentItem = false;
        }
        else
        {
          //  checkboxes
          this.IsTextSearchEnabled = false;
          this.IsEditable = true;
          this.IsReadOnly = true;
          this.IsSynchronizedWithCurrentItem = false;
        }
      }
    }


    #region Property - CheckViewModel

    public ICheckViewModel CheckViewModel { get; set; }

    #endregion



    public List<CheckItem> CheckListArray { get; set; }


    //  this property is actually bound
    public static readonly DependencyProperty CheckedValueProperty = DependencyProperty.Register("CheckedValue", typeof(object), typeof(HelpCheckComboBoxBase),
                                                                            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnCheckedValueChanged)));
    public object CheckedValue
    {
      get { return (object)GetValue(CheckedValueProperty); }
      set { SetValue(CheckedValueProperty, value); }
    }

    private static void OnCheckedValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      if (d == null)
      {
        return;
      }

      HelpCheckComboBoxBase _ctrl = (HelpCheckComboBoxBase)d;
      object _value = (object)e.NewValue;

      if (e.NewValue != e.OldValue)
      {
        if (_ctrl.CheckViewModel == null && _value != null)
        {
          _ctrl.CreateViewModel(_value.GetType());
        }

        if (_ctrl.CheckViewModel != null)
        {
          _ctrl.CheckViewModel.ApplyValue(_value);
        }
      }
    }

    public void SetDisplay(string displayText)
    {
      Text = displayText;
      if (displayText != "")
      {
        IsChanged = true;
        OnChanged?.Invoke();
      }
    }
  }
}