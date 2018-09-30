using System;
using System.Reflection;

namespace Help.WebService.Areas.HelpPage.ModelDescriptions
{
  public interface IModelDocumentationProvider
  {
    string GetDocumentation(MemberInfo member);

    string GetDocumentation(Type type);
  }
}