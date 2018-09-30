using System;
using System.Windows.Markup;

namespace Help.Library
{
  public abstract class BaseConverter : MarkupExtension
  {
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
      return this;
    }
  }
}