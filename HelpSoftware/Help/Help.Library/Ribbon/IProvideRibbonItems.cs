using Help.EF;
using System.Collections.Generic;

namespace Help.Library
{
  public interface IProvideRibbonItems
  {
    /// <summary>
    /// This RibbbonTabPAge Defs will be saved and displayed in the ribbon
    /// </summary>
    /// <returns></returns>
    List<RibbonTabPageDef> ProvideRibbon();

    /// <summary>
    /// Provides the Link Items for the Ribbon
    /// </summary>
    /// <returns></returns>
    List<LinkItem> ProvideLinks();
  }
}