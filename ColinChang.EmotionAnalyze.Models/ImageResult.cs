using System.Collections.Generic;
using ColinChang.EmotionAnalyze.Model;

namespace ColinChang.EmotionAnalyze.Models
{
    public class ImageResult : IImageResult
    {
        public int CameraId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public float Timestamp { get; set; }

        public IEnumerable<Face> Faces { get; set; }

        /// <summary>
        /// Storage anything extra
        /// </summary>
        public object Tag { get; set; }

        public ImageResult(int cameraId, int width, int height, float timestamp,
            IEnumerable<Face> faces, object tag = null)
        {
            CameraId = cameraId;
            Width = width;
            Height = height;
            Timestamp = timestamp;
            Faces = faces;
            Tag = tag;
        }
    }
}