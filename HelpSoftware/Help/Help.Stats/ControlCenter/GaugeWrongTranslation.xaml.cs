using Help.EF;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Help.Stats
{
  public partial class GaugeWrongTranslation : UserControl
  {
    public GaugeWrongTranslation()
    {
      InitializeComponent();

      var qry = from wi in HelpContext.Instance.Translations
                select wi;
      var a = qry.ToList();

      List<Translation> translated = a.Where(x => x.EnglischText != "").ToList();

      List<Translation> Nottranslated = a.Where(x => x.EnglischText == "").ToList();

      int countran = translated.Count;
      int countnotran = Nottranslated.Count;

      int percentfilled = countran * 100 / (a.Count + 1);
      test.Value = (double)percentfilled;

      test.LabelFormatter = value => string.Format("{0}{1}", value, "%");
    }
  }
}