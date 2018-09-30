using QRCoder;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace Help.Library
{
  public class QRCodeHandler
  {
    private BitmapImage BitmapToImageSource(Bitmap bitmap)
    {
      using (MemoryStream memory = new MemoryStream())
      {
        bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
        memory.Position = 0;
        BitmapImage bitmapimage = new BitmapImage();
        bitmapimage.BeginInit();
        bitmapimage.StreamSource = memory;
        bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapimage.EndInit();

        return bitmapimage;
      }
    }

    public static byte[] ImageToByteArray(Image img)
    {
      byte[] byteArray = new byte[0];
      using (MemoryStream stream = new MemoryStream())
      {
        img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        stream.Close();

        byteArray = stream.ToArray();
      }
      return byteArray;
    }

    public string GetString(BitmapImage image)
    {
      return "";
    }

    private BitmapImage EnCode(string value)
    {
      QRCodeGenerator qrGenerator = new QRCodeGenerator();
      QRCodeData qrCodeData = qrGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
      QRCode qrCode = new QRCode(qrCodeData);
      Bitmap qrCodeImage = qrCode.GetGraphic(20);
      return BitmapToImageSource(qrCodeImage);
    }

    public BitmapImage GetQRCode(string value)
    {
      return EnCode(value);
    }
  }
}