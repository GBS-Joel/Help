using Fluent;
using Help.EF;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace Help.Library
{
  public class BackstageManager
  {
    public bool IsInitialized { get; set; }

    public BackstageManager()
    {
      CheckIfDefaultButtonExist();
      IsInitialized = true;
    }

    public void DisplayBackstage()
    {
      var buttons = LoadDefaultBackstageButtons();
      CreateAndDisplayBackstage(CreateButtonFromBackstageDef(buttons));
    }

    private List<Button> CreateButtonFromBackstageDef(List<BackstageButtonDef> Defs)
    {
      List<Button> Buttons = new List<Button>();
      foreach (var item in Defs)
      {
        Buttons.Add(new Button()
        {
          Header = item.Header,
        });
      }
      return Buttons;
    }

    private void CreateAndDisplayBackstage(List<Button> Buttons)
    {
      Backstage b = new Backstage
      {
        Header = "Datei",
        Background = Brushes.Red,
      };
      BackstageTabControl backstageTabControl = new BackstageTabControl();
      foreach (var item in Buttons)
      {
        backstageTabControl.Items.Add(item);
      }
      b.Content = backstageTabControl;
      AppContext.RibbonManagerInstance.GetRibbonAccess().Menu = b;
    }

    public List<BackstageButtonDef> LoadDefaultBackstageButtons()
    {
      var qry = from b in HelpContext.Instance.BackstageButtonDefs
                where b.IsDefault == true
                orderby b.Order ascending
                select b;
      return qry.ToList();
    }

    private void CheckIfDefaultButtonExist()
    {
      CreateDefaultButton(new BackstageButtonClose().GetBackStageButtonDef());
      CreateDefaultButton(new BackstageButtonHelp().GetBackStageButtonDef());
      CreateDefaultButton(new BackstageButtonSetting().GetBackStageButtonDef());
    }

    private void CreateDefaultButton(BackstageButtonDef Def)
    {
      if (!CheckIfButtonIsInDB(Def))
        SaveNewButtonDef(Def);
    }

    private void SaveNewButtonDef(BackstageButtonDef Def)
    {
      HelpContext.Instance.BackstageButtonDefs.Add(Def);
      HelpContext.Instance.SaveChanges();
    }

    private bool CheckIfButtonIsInDB(BackstageButtonDef Def)
    {
      var qry = from b in HelpContext.Instance.BackstageButtonDefs
                where b.Name == Def.Name
                select b;
      if (qry.FirstOrDefault() != null)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
  }
}