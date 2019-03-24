using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinChang.EmotionAnalyze.AffdexExtentsion.Model
{
    public class ImageResult
    {
        public int CameraId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public float Timestamp { get; set; }
        public IList<KeyValuePair<int, Face>> Faces { get; set; }

        public ImageResult( int cameraId, int width, int height, float timestamp,
            IList<KeyValuePair<int, Face>> faces)
        {
            CameraId = cameraId;
            Width = width;
            Height = height;
            Timestamp = timestamp;
            Faces = faces;
        }
    }
}