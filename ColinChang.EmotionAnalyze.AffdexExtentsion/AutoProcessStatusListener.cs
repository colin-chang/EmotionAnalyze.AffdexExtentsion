using System;
using Affdex;

namespace ColinChang.EmotionAnalyze.AffdexExtentsion
{
    class AutoProcessStatusListener : ProcessStatusListener
    {
        private readonly int _cameraId;
        private event EventHandler<ProcessingExceptionEventArgs> OnProcessingException;
        private event EventHandler<CameraDetectorEventArgs> OnProcessingFinished;
        public AutoProcessStatusListener(int cameraId, EventHandler<ProcessingExceptionEventArgs> onProcessingException, EventHandler<CameraDetectorEventArgs> onProcessingFinished)
        {
            _cameraId = cameraId;
            OnProcessingException = onProcessingException;
            OnProcessingFinished = onProcessingFinished;
        }

        public void onProcessingException(AffdexException ex) =>
            OnProcessingException?.Invoke(this, new ProcessingExceptionEventArgs(_cameraId, ex));

        public void onProcessingFinished() => OnProcessingFinished?.Invoke(this, new CameraDetectorEventArgs(_cameraId));
    }

    public class ProcessingExceptionEventArgs : CameraDetectorEventArgs
    {
        public AffdexException Exception { get; set; }

        public ProcessingExceptionEventArgs(int cameraId, AffdexException exception):base(cameraId)
        {
            this.Exception = exception;
        }
    }
}
