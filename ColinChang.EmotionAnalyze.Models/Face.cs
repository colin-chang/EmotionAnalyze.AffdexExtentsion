using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinChang.EmotionAnalyze.Model
{
    public class Face
    {
        public FeaturePoint[] FeaturePoints { get; set; }
        public FaceQuality FaceQuality { get; set; }
        public Emojis Emojis { get; set; }
        public Emotions Emotions { get; set; }
        public Expressions Expressions { get; set; }
        public Measurements Measurements { get; set; }
        public Appearance Appearance { get; set; }
        public int Id { get; set; }
    }
}
