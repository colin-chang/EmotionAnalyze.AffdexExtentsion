using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ColinChang.EmotionAnalyze.Models;

namespace ColinChang.EmotionAnalyze.AffdexExtentsion
{
    public static class FaceMapper
    {
        static FaceMapper() => Mapper.Initialize(cfg => cfg.CreateMap<Affdex.Face, Face>());

        public static IEnumerable<Face> ToLocalFaces(this Dictionary<int, Affdex.Face> faces)
        {
            var localFaces = new List<Face>();
            if (faces == null || !faces.Any())
                return localFaces;

            foreach (var face in faces.Values)
                localFaces.Add(Mapper.Map<Face>(face));

            return localFaces;
        }
    }
}
