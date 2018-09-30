using System.Collections.ObjectModel;

namespace Help.WebService.Areas.HelpPage.ModelDescriptions
{
  public class EnumTypeModelDescription : ModelDescription
  {
    public EnumTypeModelDescription()
    {
      Values = new Collection<EnumValueDescription>();
    }

    public Collection<EnumValueDescription> Values { get; private set; }
  }
}