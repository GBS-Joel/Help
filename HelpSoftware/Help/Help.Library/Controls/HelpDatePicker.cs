using System;
using System.Globalization;
using System.Windows.Controls;

namespace Help.Library
{
  public class HelpDatePicker : DatePicker, ITextFocusableHelpControl
  {
    public bool SelectContentOnInitialFocus { get; set; }

    public object Value { get; set; }

    public bool IsValueSetByInitialFocus { get; set; }

    public int CaretIndex { get; set; }

    public bool IsContentSelectedOnFocus { get; set; }

    private ValidationRule dateTimeRule = null;

    private static DateTime invalidDate = Convert.ToDateTime("1.1.6666");

    private Func<string, bool> CustomValidationRule { get; set; }

    private bool HasCustomValidation { get; set; }

    public bool ValidateControl()
    {
      AppContext.Logger.Debug("Validate DatePicker " + Name);
      if (HasCustomValidation)
      {
        return CustomValidationRule.Invoke(SelectedDate.ToString());
      }
      else
      {
        var result = dateTimeRule.Validate(SelectedDate, CultureInfo.CurrentCulture);
        return result.IsValid;
      }
    }

    public void AddCustomValidationRule(Func<string, bool> FuncToCall)
    {
      if (FuncToCall != null)
      {
        HasCustomValidation = true;
        CustomValidationRule = FuncToCall;
      }
    }

    public void AddCustomValidationRule(ValidationRule Rule)
    {
      HasCustomValidation = false;
      dateTimeRule = Rule;
    }
  }
}