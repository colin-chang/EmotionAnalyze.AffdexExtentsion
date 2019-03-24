using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinChang.EmotionAnalyze.AffdexExtentsion.Model
{
    public class Emojis
    {
        public float Scream { get; set; }
        public float Flushed { get; set; }
        public float StuckOutTongue { get; set; }
        public float StuckOutTongueWinkingEye { get; set; }
        public float Wink { get; set; }
        public float Smirk { get; set; }
        public float Rage { get; set; }
        public float Disappointed { get; set; }
        public float Kissing { get; set; }
        public float Laughing { get; set; }
        public float Smiley { get; set; }
        public float Relaxed { get; set; }
        public Emoji DominantEmoji { get; set; }
    }
}
