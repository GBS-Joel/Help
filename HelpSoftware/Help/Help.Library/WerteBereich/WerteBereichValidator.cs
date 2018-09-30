using Help.EF;
using System.Text.RegularExpressions;
using System.Windows;

namespace Help.Library
{
  public class WerteBereichValidator
  {
    public WerteBereichValidator()
    {
      ActivityActionWB wb = new ActivityActionWB();
      WerteBereich bereich = new WerteBereich();
      bereich.Value = "Insert";
      bereich.WertebereichDef = wb.GetWertebereichDef();
      // MessageBox.Show(ValidateWerteBereich(bereich).ToString());
    }

    //TODO: Loop through all Elements and set value do default if value is not valid
    public void RepairWerteBereichValues()
    {

    }

    public bool ValidateWerteBereich(WerteBereich WerteBereich)
    {
      bool IsValid = false;
      //If there is no Range every value is valid
      if (WerteBereich.WertebereichDef.WerteBereichValueRanges.Count == 0)
      {
        IsValid = true;
      }
      else foreach (var item in WerteBereich.WertebereichDef.WerteBereichValueRanges)
        {
          switch (item.Type)
          {
            case WerteBereichValueRangeType.InList:
              IsValid = CheckIfValueIsInList(item, WerteBereich.Value);
              break;
            case WerteBereichValueRangeType.NotInList:
              IsValid = CheckIfValueIsNotInList(item, WerteBereich.Value);
              break;
            case WerteBereichValueRangeType.Between:
              IsValid = CheckIfValueIsBetween(item, WerteBereich.Value);
              break;
            case WerteBereichValueRangeType.NotBetween:
              IsValid = CheckIfValueIsNotBetween(item, WerteBereich.Value);
              break;
          }
        }
      return IsValid;
    }

    public bool CheckIfValueIsNotBetween(WerteBereichValueRange Range, string Item)
    {
      return true;
    }

    public bool CheckIfValueIsBetween(WerteBereichValueRange Range, string Item)
    {
      return true;
    }

    public bool CheckIfValueIsNotInList(WerteBereichValueRange Range, string Item)
    {
      bool IsValid = true;
      foreach (var item in Range.WerteBereichValueRangeItems)
      {
        if (item.Value == Item)
        {
          IsValid = false;
        }
      }
      return IsValid;
    }

    public bool CheckIfValueIsInList(WerteBereichValueRange Range, string Item)
    {
      bool IsValid = false;
      foreach (var item in Range.WerteBereichValueRangeItems)
      {
        if (item.Value == Item)
        {
          IsValid = true;
        }
      }
      return IsValid;
    }

    private bool CheckIfStringMatchesRegex(string RegexMatch, string Expression)
    {
      return Regex.Match(Expression, RegexMatch) != null;
    }

    private bool CheckIfIsRange(int min, int max, int value)
    {
      return value > min && value < max;
    }
  }
}