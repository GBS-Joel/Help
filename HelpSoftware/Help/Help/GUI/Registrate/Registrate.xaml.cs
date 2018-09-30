using Help.Library;
using System.Windows;

namespace Help
{
  public partial class Registrate : HelpUserControl
  {
    public Registrate()
    {
      InitializeComponent();
      Model = new RegistrateModel();
    }

    //Registrate
    private void Registrate_Click(object sender, RoutedEventArgs e)
    {
      ((RegistrateModel)Model).Registrate();
    }
  }
}