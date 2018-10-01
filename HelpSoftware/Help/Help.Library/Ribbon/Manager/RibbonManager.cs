using Fluent;
using Help.EF;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Help.Library
{
  public class RibbonManager
  {
    private static Ribbon BaseRibbon { get; set; }

    public RibbonButtonManager RibbonButtonManager { get; set; }

    public RibbonGroupBoxManager RibbonGroupBoxManager { get; set; }

    public RibbonTabPageManager RibbonTabPageManager { get; set; }

    public BackstageManager BackstageManager { get; set; }

    public HelpCommandManager HelpCommandManager { get; set; }

    public RibbonManager()
    {
      InitRibbonManager();
    }

    public void SetRibbon(Ribbon ribbon)
    {
      BaseRibbon = ribbon;
      DisplayBackstage();
    }

    public void InitRibbonManager()
    {
      RibbonButtonManager = new RibbonButtonManager();
      RibbonGroupBoxManager = new RibbonGroupBoxManager();
      RibbonTabPageManager = new RibbonTabPageManager();
      BackstageManager = new BackstageManager();
      HelpCommandManager = new HelpCommandManager();
    }

    public void DisplayWindowRibbon(List<RibbonTabPageDef> Defs)
    {
      foreach (var item in Defs)
      {
        DisplayRibbonTab(item);
      }
    }

    public void DisplayRibbonTab(RibbonTabPageDef Def)
    {
      RibbonTabItem item = GetRibbonFromDef(Def);
      foreach (var g in GetGroupBoxesFromTabPage(Def))
      {
        item.Groups.Add(g);
        item.Groups.Add(GetGroupBoxesFromTabPage(Def).FirstOrDefault());
      }
      BaseRibbon.Tabs.Add(item);
    }

    public List<RibbonGroupBox> GetGroupBoxesFromTabPage(RibbonTabPageDef Def)
    {
      List<RibbonGroupBox> GroupBoxes = new List<RibbonGroupBox>();
      var qry = from g in HelpContext.Instance.RibbonGroupBoxDefs
                where g.RibbonTabPageDef.ID_RibbonTagPageDef == Def.ID_RibbonTagPageDef
                select g;
      foreach (var item in qry.ToList())
      {
        var res = GetRibbonGroupBoxFromDef(item);
        res.Items.Add(GetButtonsFromGroupBox(item));
        GroupBoxes.Add(res);
      }
      return GroupBoxes;
    }

    public RibbonGroupBox GetRibbonGroupBoxFromDef(RibbonGroupBoxDef Def)
    {
      return new RibbonGroupBox()
      {
        Header = Def.Header,
      };
    }

    public RibbonTabItem GetRibbonFromDef(RibbonTabPageDef Def)
    {
      RibbonTabItem item = new RibbonTabItem()
      {
        Header = Def.TabHeader,
        KeyTip = Def.KeyTip,
        FontWeight = FontWeights.Bold
      };
      return item;
    }

    public List<Button> GetButtonsFromGroupBox(RibbonGroupBoxDef Def)
    {
      List<Button> Buttons = new List<Button>();

      var qry = from b in HelpContext.Instance.RibbonButtonDefs
                where b.RibbonGroupBoxDef.ID_RibbonGroupBoxDef == Def.ID_RibbonGroupBoxDef
                select b;
      foreach (var item in qry.ToList())
      {
        Buttons.Add(GetButtonFromButtonDef(item));
      }
      return Buttons;
    }

    public Button GetButtonFromButtonDef(RibbonButtonDef Def)
    {
      ScreenTip tip = new ScreenTip()
      {
        Title = Def.ScreenTippTitle,
        Text = Def.ScreenTippText,
        Image = AppContext.IconManagerInstance.LoadBitMapImageFromName(Def.ImageTiny),
        //Image = new BitmapImage(new System.Uri(Def.ImageLarge)),
        HelpTopic = Def.HelpTopic
      };

      return new Button()
      {
        Header = Def.DisplayName,
        Name = Def.Name,
        Uid = Def.UID,
        Icon = Def.ImageSmall,
        LargeIcon = Def.ImageLarge,
        FontWeight = System.Windows.FontWeights.Normal,
        KeyTip = Def.KeyTip,
        ToolTip = tip
      };
    }

    public void DisplayDefaultRibbon()
    {
      //Load Ribbons For Active Window
      var res = RibbonTabPageManager.GetRibbonTabPageDefs();
      DisplayRibbonTab(res.FirstOrDefault());

      foreach (var item in RibbonTabPageManager.GetRibbonTabPageDefs())
      {
        RibbonTabItem ribbonTabItem = new RibbonTabItem();
        ribbonTabItem.Header = "Test Test";
        HelpContext.Instance.Entry(item).Collection(x => x.GroupBoxes).Load();
        foreach (var box in item.GroupBoxes)
        {
          HelpContext.Instance.Entry(box).Collection(s => s.RibbonButtonDefs).Load();
          RibbonGroupBox ribbonbox = new RibbonGroupBox();
          ribbonbox.Header = "Group Box Test";
          foreach (var button in box.RibbonButtonDefs)
          {
            ribbonbox.Items.Add(new Button()
            {
              Header = "Schliessen",
              Icon = AppContext.IconManagerInstance.LoadBitMapImageFromName("A"),
              LargeIcon = AppContext.IconManagerInstance.LoadBitMapImageFromName("a"),
            });
          }
          ribbonTabItem.Groups.Add(ribbonbox);
        }
        BaseRibbon.Tabs.Add(ribbonTabItem);
      }
    }

    private void Ribbonbox_Loaded(object sender, RoutedEventArgs e)
    {
      //    ((RibbonGroupBox)sender).Width = ((RibbonGroupBox)sender).ActualWidth;
    }

    public void UpdateRibbon()
    {
    }

    public void DisplayBackstage()
    {
      BackstageManager.DisplayBackstage();
    }

    public Ribbon GetRibbonAccess()
    {
      return BaseRibbon;
    }

    public void GetRibbonTabDefsForCurrentWindow()
    {
      var ribbontabs = AppContext.WindowManagerInstance.CurrentOpenElement.ProvideRibbon();
      DisplayWindowRibbon(ribbontabs.ToList());
    }

    public void ProvideDefaultRibbonPages()
    {
      //Start
      //Debug if IsDebug or IsDevelopement is enabled
    }

    // <param name="Items">All the Links that will be displayed on the ribbon</param>
    public void DisplayLinkItems(List<LinkItem> Items)
    {
      //Clear Links First
    }
  }
}