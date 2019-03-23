using Affdex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinChang.EmotionAnalyze.AffdexExtentsion
{
    class AutoFaceListener : FaceListener
    {
        private readonly int _cameraId;
        private event EventHandler<FaceEventArgs> OnFaceFound;
        private event EventHandler<FaceEventArgs> OnFaceLost;

        public AutoFaceListener(int cameraId, EventHandler<FaceEventArgs> onFaceFound,EventHandler<FaceEventArgs> onFaceLost)
        {
            _cameraId = cameraId;
            OnFaceFound = onFaceFound;
            OnFaceLost = onFaceLost;
        }

        public void onFaceFound(float timestamp, int faceId)
        {
            OnFaceFound?.Invoke(this,new FaceEventArgs(_cameraId,timestamp,faceId));
        }

        public void onFaceLost(float timestamp, int faceId)
        {
            OnFaceLost?.Invoke(this,new FaceEventArgs(_cameraId,timestamp,faceId));
        }
    }

    public class FaceEventArgs : CameraDetectorEventArgs
    {
        public float Timestamp { get; set; }
        public int FaceId { get; set; }

        public FaceEventArgs(int cameraId, float timestamp, int faceId) : base(cameraId)
        {
            Timestamp = timestamp;
            FaceId = faceId;
        }
    }
}
