using Affdex;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ColinChang.EmotionAnalyze.AffdexExtentsion
{
    public static class FrameExtension
    {
        public static Stream ToImageStream(this Frame frame)
        {
            var width = frame.getWidth();
            var height = frame.getHeight();
            var imageData = frame.getBGRByteArray();
            //var stride = (width * PixelFormats.Bgr24.BitsPerPixel + 7) / 8;
            var stride = width * 3 % 4 == 0 ? width * 3 : (width * 3 / 4 + 1) * 4;
            var source = BitmapSource.Create(width, height, 96d, 96d, PixelFormats.Bgr24, null, imageData, stride);
            var stream = new MemoryStream();
            BitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(source));
            encoder.Save(stream);

            return stream;
        }
    }
}
