using Affdex;
using System;
using System.Collections.Generic;
using System.IO;

namespace ColinChang.EmotionAnalyze.AffdexExtentsion
{
    class AutoImageListener : ImageListener
    {
        private readonly int _cameraId;
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

            if (frame != null)
                frame.Dispose();
        }
    }

    public class ImageCaptureEventArgs : CameraDetectorEventArgs
    {
        public Stream ImageData { get; set; }
        public ImageCaptureEventArgs(int cameraId, Frame frame) : base(cameraId)
        {
            ImageData = frame.ToImageStream();
        }
    }

    public class ImageResultsEventArgs
    {
        public Model.ImageResult ImageResult { get; set; }

        /// <summary>
        /// The Image Data as stream format,it's from the origin Frame
        /// </summary>
        public Stream ImageData { get; set; }

        public ImageResultsEventArgs(int cameraId, Dictionary<int, Face> faces, Frame frame)
        {
            ImageResult = new Model.ImageResult(cameraId, frame.getWidth(), frame.getHeight(), frame.getTimestamp(), faces.ToLocalFaces());

            ImageData = frame.ToImageStream();
        }
    }
}
