using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xaml;

namespace Help.Light
{
  internal class MyXamlSchemaContext : XamlSchemaContext
  {
    public override bool TryGetCompatibleXamlNamespace(string xamlNamespace, out string compatibleNamespace)
    {
      if (xamlNamespace.Equals("clr-namespace:Markdig.Wpf"))
      {
        compatibleNamespace = $"clr-namespace:Markdig.Wpf;assembly={Assembly.GetAssembly(typeof(Markdig.Wpf.Styles)).FullName}";
        return true;
      }
      return base.TryGetCompatibleXamlNamespace(xamlNamespace, out compatibleNamespace);
    }
  }
}
