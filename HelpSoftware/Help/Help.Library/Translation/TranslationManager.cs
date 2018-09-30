using Help.EF;
using System;
using System.Linq;

namespace Help.Library
{
  public class TranslationManager
  {
    public void ChangeAppLanguage(AppLanguage appLanguage)
    {
      switch (appLanguage)
      {
        case AppLanguage.German:
          AppContext.HelpSettingsHandler.UserSettingsHandler.SetUserSetting("AppLanguage", "1");
          break;

        case AppLanguage.Englisch:
          AppContext.HelpSettingsHandler.UserSettingsHandler.SetUserSetting("AppLanguage", "2");
          break;

        case AppLanguage.French:
          AppContext.HelpSettingsHandler.UserSettingsHandler.SetUserSetting("AppLanguage", "3");
          break;

        default:
          AppContext.HelpSettingsHandler.UserSettingsHandler.SetUserSetting("AppLanguage", "1");
          break;
      }
      AppContext.WindowManagerInstance.ReOpenCurrentWindow();
    }

    public string Translate(string text)
    {
      if (AppContext.IsLoggedIn)
      {
        var res = AppContext.HelpSettingsHandler.UserSettingsHandler.GetUserSettingFromName("AppLanguage");
        var qry = from t in HelpContext.Instance.Translations
                  where t.GermanText == text
                  select t;
        if (qry.FirstOrDefault() != null)
        {
          if (qry.FirstOrDefault().EnglischText == null && res.UserValue == "1")
          {
            return text;
          }
          else
          {
            return qry.FirstOrDefault().EnglischText;
          }
        }
        else
        {
          Translation tran = new Translation()
          {
            CreatedDate = DateTime.Now,
            EnglischText = "",
            GermanText = text
          };
          HelpContext.Instance.Translations.Add(tran);
          HelpContext.Instance.SaveChanges();
          return text;
        }
      }
      else
      {
        return text;
      }
    }
  }
}