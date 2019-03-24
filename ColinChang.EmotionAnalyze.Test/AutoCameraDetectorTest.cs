using System;
using System.Linq;
using System.Threading;
using ColinChang.EmotionAnalyze.AffdexExtentsion;
using ColinChang.EmotionAnalyze.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ColinChang.EmotionAnalyze.Test
{
    [TestClass]
    public class AutoCameraDetectorTest
    {
        private string _classifierPath;
        private int _cameraId;

        [TestInitialize]
        public void Init()
        {
            /* Data folder
             * 
             The Affdex classifier data files are used in frame analysis processing. These files are supplied as part of the SDK. The location of the data files on the physical storage needs to be passed to a detector in order to initialize it by calling the following with the fully qualified path to the folder containing them
             */
            _classifierPath = @"C:\Program Files\Affectiva\AffdexSDK\data";

            //id of the camera connected in your pc.The id of default camera on your PC usually is 0.
            _cameraId = 0;
        }


        [TestMethod]
        public void CameraDetectorTest()
        {
            var detector = new AutoCameraDetector(_classifierPath, _cameraId);
            detector.OnImageResults += Detector_OnImageResults;
            detector.OnProcessingException += Detector_OnProcessingException;
            detector.Start();

            Thread.Sleep(5000);
            detector.Stop();
        }

        private void Detector_OnImageResults(object sender, ImageResultsEventArgs e)
        {
            Console.WriteLine(JsonConvert.SerializeObject(e.ImageResult));
        }

        private void Detector_OnProcessingException(object sender, ProcessingExceptionEventArgs e)
        {
            Console.WriteLine($"An exception occured when process on camera {e.CameraId}:{e.Exception.Message}");
        }
    }
}
