using Affdex;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinChang.EmotionAnalyze.AffdexExtentsion
{
    /// <summary>
    /// 自动化摄像头探测器
    /// </summary>
    public class AutoCameraDetector : CameraDetector
    {
        //private int CameraId;
        public int CameraId { get; set; }

        /// <summary>
        /// 创建自动化摄像头探测器
        /// </summary>
        /// <param name="classifierPath">分级器路径,默认在SDK安装目录下'AffdexSDK\data'</param>
        /// <param name="cameraId">系统摄像头Id</param>
        /// <param name="cameraFps">捕捉帧频(帧/秒)</param>
        /// <param name="processFps">处理帧频(帧/秒)</param>
        public AutoCameraDetector(string classifierPath, int cameraId, double cameraFps = 15, double processFps = 30) :
            base(cameraId, cameraFps, processFps)
        {
            InitDetectConfiguration(cameraId, classifierPath);
        }

        /// <summary>
        /// 创建自动化摄像头探测器
        /// </summary>
        /// <param name="classifierPath">分级器路径,默认在SDK安装目录下'AffdexSDK\data'</param>
        /// <param name="cameraId">系统摄像头Id</param>
        /// <param name="cameraFps">捕捉帧频(帧/秒)</param>
        /// <param name="processFps">处理帧频(帧/秒)</param>
        /// <param name="maxNumFaces">最多识别人脸</param>
        /// <param name="faceConfig">人脸识别尺寸(LARGE_FACES/SMALL_FACES)</param>
        public AutoCameraDetector(string classifierPath, int cameraId, double cameraFps, double processFps,
            uint maxNumFaces = 1000,
            FaceDetectorMode faceConfig = FaceDetectorMode.LARGE_FACES) : base(cameraId,
            cameraFps, processFps, maxNumFaces, faceConfig)
        {
            InitDetectConfiguration(cameraId, classifierPath);
        }


        //初始化默认配置
        private void InitDetectConfiguration(int cameraId, string classifierPath)
        {
            CameraId = cameraId;

            //捕捉内容配置
            setDetectAllEmotions(true);
            setDetectAllExpressions(true);
            setDetectAllAppearances(true);
            setDetectAllEmojis(true);
            setDetectGender(true);
            setDetectGlasses(true);

            //ClassifierPath
            setClassifierPath(classifierPath);
        }

        /// <summary>
        /// 启动探测器
        /// </summary>
        public void Start()
        {
            if (this.isRunning())
                return;

            //状态监测
            setProcessStatusListener(new AutoProcessStatusListener(CameraId, OnProcessingException,
                OnProcessingFinished));

            //人脸识别监测
            setFaceListener(new AutoFaceListener(CameraId, OnFaceFound, OnFaceLost));

            //数据处理监测
            setImageListener(new AutoImageListener(CameraId, OnImageCapture, OnImageResults));


            OnDetectorStarting?.Invoke(this, new CameraDetectorEventArgs(CameraId));
            start();
            OnDetectorStarted?.Invoke(this, new CameraDetectorEventArgs(CameraId));
        }

        /// <summary>
        /// 停止探测器
        /// </summary>
        public void Stop()
        {
            OnDetectorStopping?.Invoke(this, new CameraDetectorEventArgs(CameraId));
            if (isRunning()) stop();
            Dispose();
            OnDetectorStopped?.Invoke(this, new CameraDetectorEventArgs(CameraId));
        }

        /// <summary>
        /// 启用数据分析
        /// </summary>
        public void EnableAnalytics()
        {
            OnEnablingAnalytics?.Invoke(this, new CameraDetectorEventArgs(CameraId));
            enableAnalytics();
            OnEnabledAnalytics?.Invoke(this, new CameraDetectorEventArgs(CameraId));
        }

        /// <summary>
        /// 禁用数据分析
        /// </summary>
        public void DisableAnalytics()
        {
            OnDisablingAnalytics?.Invoke(this, new CameraDetectorEventArgs(CameraId));
            disableAnalytics();
            OnDisabledAnalytics?.Invoke(this, new CameraDetectorEventArgs(CameraId));
        }

        /// <summary>
        /// 准备启动探测器
        /// </summary>
        public event EventHandler<CameraDetectorEventArgs> OnDetectorStarting;

        /// <summary>
        /// 探测器启动完毕
        /// </summary>
        public event EventHandler<CameraDetectorEventArgs> OnDetectorStarted;

        /// <summary>
        /// 准备停止探测器
        /// </summary>
        public event EventHandler<CameraDetectorEventArgs> OnDetectorStopping;

        /// <summary>
        /// 探测器停止完毕
        /// </summary>
        public event EventHandler<CameraDetectorEventArgs> OnDetectorStopped;

        /// <summary>
        /// 准备启用数据分析
        /// </summary>
        public event EventHandler<CameraDetectorEventArgs> OnEnablingAnalytics;

        /// <summary>
        /// 数据分析启用完毕
        /// </summary>
        public event EventHandler<CameraDetectorEventArgs> OnEnabledAnalytics;

        /// <summary>
        /// 准备禁用数据分析
        /// </summary>
        public event EventHandler<CameraDetectorEventArgs> OnDisablingAnalytics;

        /// <summary>
        /// 禁用数据分析完毕
        /// </summary>
        public event EventHandler<CameraDetectorEventArgs> OnDisabledAnalytics;

        /// <summary>
        /// 数据处理异常
        /// </summary>
        public event EventHandler<ProcessingExceptionEventArgs> OnProcessingException;

        /// <summary>
        /// 数据处理完毕
        /// </summary>
        public event EventHandler<CameraDetectorEventArgs> OnProcessingFinished;

        /// <summary>
        /// 监测到人脸
        /// </summary>
        public event EventHandler<FaceEventArgs> OnFaceFound;

        /// <summary>
        /// 人脸监测丢失
        /// </summary>
        public event EventHandler<FaceEventArgs> OnFaceLost;

        /// <summary>
        /// 捕捉到帧图
        /// </summary>
        public event EventHandler<ImageCaptureEventArgs> OnImageCapture;

        /// <summary>
        /// 帧图分析数据完毕
        /// </summary>
        public event EventHandler<ImageResultsEventArgs> OnImageResults;
    }

    public class CameraDetectorEventArgs : EventArgs
    {
        public int CameraId { get; set; }

        public CameraDetectorEventArgs(int cameraId)
        {
            CameraId = cameraId;
        }
    }
}