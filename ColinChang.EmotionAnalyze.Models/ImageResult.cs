using System.Collections.Generic;

namespace ColinChang.EmotionAnalyze.Model
{
    public class ImageResult
    {
        public int CameraId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public float Timestamp { get; set; }
        public IList<KeyValuePair<int, Face>> Faces { get; set; }
        /// <summary>
        /// Storage anything extra
        /// </summary>
        public object Tag { get; set; }

        public ImageResult(int cameraId, int width, int height, float timestamp,
            IList<KeyValuePair<int, Face>> faces, object tag = null)
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