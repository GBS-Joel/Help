using System;

namespace Help.Library
{
  public interface ITextFocusableHelpControl
  {
    object Value { get; set; }

    bool IsValueSetByInitialFocus { get; set; }

    int CaretIndex { get; set; }

    bool IsContentSelectedOnFocus { get; set; }

    bool ValidateControl();

    void AddCustomValidationRule(Func<string, bool> FuncToCall);
  }
}