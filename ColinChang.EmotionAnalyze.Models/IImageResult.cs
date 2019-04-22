using System.Collections.Generic;
using ColinChang.EmotionAnalyze.Model;

namespace ColinChang.EmotionAnalyze.Models
{
    public interface IImageResult
    {
        int CameraId { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        float Timestamp { get; set; }

        IEnumerable<Face> Faces { get; set; }

        /// <summary>
        /// Storage anything extra
        /// </summary>
        object Tag { get; set; }
    }
}