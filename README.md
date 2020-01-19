# EmotionAnalyze.AffdexExtentsion

This is an extension of [Affectiva Emotion SDK for Windows](https://knowledge.affectiva.com/docs/analyze-the-camera-stream).It will be much more easier to use Affectiva SDK with this extension.

The AutoCameraDetector can access a webcam connected to the device to capture frames and feed them directly to the facial expression engine.

The unit test project `ColinChang.EmotionAnalyze.Test` shows you how to use it.Check it to have a quick start.

**[Nuget](https://www.nuget.org/packages/ColinChang.EmotionAnalyze.AffdexExtentsion/)**
```sh
# Package Manager
Install-Package ColinChang.EmotionAnalyze.AffdexExtentsion

# .NET CLI
dotnet add package ColinChang.EmotionAnalyze.AffdexExtentsion
```

* Add reference of the `Affdex.dll` to your project. 
* Set `affdex-native.dll`,`tensorflow.dll` Copy to Output Directory be "Always Copy"

>Requirements

**Runtime Requirements**

* Microsoft .NET framework v 4.6.1 or newer
* Visual C++ Redistributable runtime for VS 2015
* [Affectiva SDK](https://knowledge.affectiva.com/docs/getting-started-with-the-emotion-sdk-for-windows#section-1-download-and-run-the-sdk-installer) installed
* Only x64 OS was supported. 

**Hardware requirements (recommended)**
* Processor, 2 GHz
* RAM, 1 GB
* Disk Space (min) : 950 MB

Here is the Affdex Windows (.NET) SDK Document
http://affectiva.github.io/developerportal/pages/platforms/v3_4_1/windows/classdocs/Affdex/html/b8038333-b12e-8ea1-a2ce-74c8d611fa89.htm

> Remark - How to build nuget package
```sh
# generate nuspec file
nuget spec

# pack to nupkg file
nuget pack ColinChang.EmotionAnalyze.AffdexExtentsion.csproj
```
