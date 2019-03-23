using Affdex;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinChang.EmotionAnalyze.AffdexExtentsion
{
    class AutoImageListener : ImageListener
    {
        private int _cameraId;
        private event EventHandler<ImageCaptureEventArgs> OnImageCapture;
        private event EventHandler<ImageResultsEventArgs> OnImageResults;

        public AutoImageListener(int cameraId, EventHandler<ImageCaptureEventArgs> onImageCapture, EventHandler<ImageResultsEventArgs> onImageResults)
        {
            _cameraId = cameraId;
            OnImageCapture = onImageCapture;
            OnImageResults = onImageResults;
        }

        public void onImageCapture(Frame frame)
        {
            OnImageCapture?.Invoke(this, new ImageCaptureEventArgs(_cameraId, frame));

            if (frame != null)
                frame.Dispose();
        }

        public void onImageResults(Dictionary<int, Face> faces, Frame frame)
        {
            OnImageResults?.Invoke(this, new ImageResultsEventArgs(_cameraId, faces, frame));

            foreach (var face in faces.Values)
                face.Dispose();
            faces = null;

            if (frame != null)
                frame.Dispose();
        }
    }

    public class ImageCaptureEventArgs : CameraDetectorEventArgs
    {
        public Frame Frame { get; set; }
        public ImageCaptureEventArgs(int cameraId, Frame frame) : base(cameraId)
        {
            this.Frame = frame;
        }
    }

    public class ImageResultsEventArgs : ImageCaptureEventArgs
    {
        public Dictionary<int, Face> Faces { get; set; }

        public ImageResultsEventArgs(int cameraId, Dictionary<int, Face> faces, Frame frame) : base(cameraId, frame)
        {
            Faces = faces;
        }
    }
}
