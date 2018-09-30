using System;
using System.Windows.Markup;

namespace Help.Library
{
  public class TextTranslator : MarkupExtension
  {
    public string Text { get; set; }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
      if (!AppContext.InDesignMode)
      {
        if (true)
        {
          return AppContext.TranslationManagerInstance.Translate(Text);
        }
        else
        {
          return Text;
        }
      }
      else
      {
        return Text;
      }
    }
  }
}