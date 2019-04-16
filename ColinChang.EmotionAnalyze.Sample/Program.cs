﻿using ColinChang.EmotionAnalyze.AffdexExtentsion;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

namespace ColinChang.EmotionAnalyze.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            string _classifierPath = @"C:\Program Files\Affectiva\AffdexSDK\data";
            int _cameraId = 1;

            var detector = new AutoCameraDetector(_classifierPath, _cameraId);
            detector.OnImageCapture += Detector_OnImageCapture;
            detector.OnImageResults += Detector_OnImageResults;
            detector.OnProcessingException += Detector_OnProcessingException;
            detector.Start();

            Thread.Sleep(5000);
            detector.Stop();
            Console.ReadKey();
        }

        private static void Detector_OnImageCapture(object sender, ImageCaptureEventArgs e)
        {
            //if (DateTime.Now.Millisecond % 10 == 0)
            //    new Bitmap(e.ImageData).Save($"{Guid.NewGuid()}.jpg", ImageFormat.Jpeg);
        }

        private static void Detector_OnImageResults(object sender, ImageResultsEventArgs e)
        {
            var guid = Guid.NewGuid();

            if (DateTime.Now.Millisecond % 10 == 0)
                new Bitmap(e.ImageData).Save($"{guid}.jpg", ImageFormat.Jpeg);
            e.ImageResult.Tag = guid;

            Console.WriteLine(JsonConvert.SerializeObject(e.ImageResult));
        }

        private static void Detector_OnProcessingException(object sender, ProcessingExceptionEventArgs e)
        {
            Console.WriteLine($"An exception occured when process on camera {e.CameraId}:{e.Exception.Message}");
        }
    }
}
