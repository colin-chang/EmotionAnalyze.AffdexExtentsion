namespace ColinChang.EmotionAnalyze.Models
{
    public class Face
    {
        public int Id { get; set; }
        public FeaturePoint[] FeaturePoints { get; set; }
        public FaceQuality FaceQuality { get; set; }
        public Emojis Emojis { get; set; }
        public Emotions Emotions { get; set; }
        public Expressions Expressions { get; set; }
        public Measurements Measurements { get; set; }
        public Appearance Appearance { get; set; }
        public string Who { get; set; }
        public float Similarity { get; set; }
    }
}
