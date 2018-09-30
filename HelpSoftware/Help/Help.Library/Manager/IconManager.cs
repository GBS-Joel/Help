using MahApps.Metro.IconPacks;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Help.Library
{
  public class IconManager
  {
    public IconManager()
    {
      var res = LoadBitMapImageFromName("A");
    }

    public ImageSource LoadIconPackIcon(string Name)
    {
      var packIconMaterial = new PackIconMaterial()
      {
        Kind = PackIconMaterialKind.Cookie,
        Margin = new Thickness(4, 4, 2, 4),
        Width = 24,
        Height = 24,
        VerticalAlignment = VerticalAlignment.Center
      };

      Geometry geo = Geometry.Parse(packIconMaterial.Data);
      GeometryDrawing gd = new GeometryDrawing();
      gd.Geometry = geo;
      gd.Brush = packIconMaterial.BorderBrush;
      gd.Pen = new System.Windows.Media.Pen(System.Windows.Media.Brushes.White, 100);

      DrawingImage geoImage = new DrawingImage(gd);
      geoImage.Freeze();

      return geoImage;
    }

    //Key
    //Color
    //Size
    public BitmapImage LoadBitMapImageFromName(string ImageKey)
    {
      try
      {
        BitmapImage myBitmapImage = new BitmapImage();
        myBitmapImage.BeginInit();
        var res = TryResolveKey("Black_48x48_Delete");
        var ru = GetPathOfKey(res);
        string a = Environment.CurrentDirectory;
        string p = a + @"\Images" + ru;
        myBitmapImage.UriSource = new Uri(p, UriKind.RelativeOrAbsolute);
        myBitmapImage.DecodePixelWidth = 48;
        myBitmapImage.EndInit();
        return myBitmapImage;
      }
      catch (KeyNotValidException)
      {
        AppContext.Logger.Warn("Das Bild mit dem Schlüssel " + ImageKey + "konnte nicht gefunden werden!", ImageKey);
        return LoadBitMapImageFromName("Black_48x48_Invalid");
      }
      catch (Exception x)
      {
        throw x;
      }
    }

    //Create Class but im lazy
    private string GetPathOfKey(Tuple<string, string, string> Keys)
    {
      string path = @"\" + Keys.Item1 + @"\" + Keys.Item2 + @"\" + Keys.Item3 + ".png";
      return path;
    }

    //Valid Key "Black_48x48_Delete"
    private Tuple<string, string, string> TryResolveKey(string Key)
    {
      //Logic to Avoid invalid Keys must be here
      var res = Key.Split('_');
      if (res == null) throw new KeyNotValidException(Key);
      if (res.Length != 3) throw new KeyNotValidException(Key);
      if (!CheckIfSizeIsKnown(res[1])) throw new KeyNotValidException(Key);
      if (!CheckIfColorIsKnown(res[0])) throw new KeyNotValidException(Key);
      return new Tuple<string, string, string>(res[0], res[1], res[2]);
    }

    private bool CheckIfColorIsKnown(string color)
    {
      switch (color)
      {
        case "Black":
        case "White":
          return true;

        default:
          return false;
      }
    }

    private bool CheckIfSizeIsKnown(string size)
    {
      switch (size)
      {
        case "48x48":
        case "24x24":
        case "36x36":
        case "18x18":
          return true;

        default:
          return false;
      }
    }
  }
}