using Help.EF;
using System.Linq;
using System.Windows;

namespace Help.Library
{
  public class OrganizationManager
  {
    public void TryCreateOrganization(Organization Organization)
    {
      AppContext.Logger.Debug("Try Create Organization");
      if (IsOrgValid(Organization))
      {
        SaveNewOrganization(Organization);
      }
    }

    private void SaveNewOrganization(Organization Organization)
    {
      HelpContext.Instance.Organizations.Add(Organization);
      HelpContext.Instance.SaveChanges();
    }

    private bool IsOrgValid(Organization Organization)
    {
      //The Name Must not exist singlge name if public
      //Org is allways public
      if (CheckIfOrganizationExists(Organization))
      {
        MessageBox.Show("The Org allready exists");
        return IsOrgDataValid(Organization);
      }
      else
      {
        return true;
      }
    }

    private bool IsOrgDataValid(Organization Organization)
    {
      //All Memebers are none
      //The Author is also automatic the Admin of the Group in the Beginning
      //This can later be changed but there must be allways one admin in the Group
      //Mods are
      //We need an identification number for the User that gets generated
      if (!Organization.Admins.Contains(Organization.Author))
      {
        Organization.Admins.Add(Organization.Author);
      }
      return true;
    }

    private bool CheckIfOrganizationExists(Organization Organization)
    {
      var qry = from o in HelpContext.Instance.Organizations
                where o.Name == Organization.Name
                select o;
      return qry.Any();
    }
  }
}