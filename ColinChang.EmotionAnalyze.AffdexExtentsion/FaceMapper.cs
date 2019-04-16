using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ColinChang.EmotionAnalyze.Model;

namespace ColinChang.EmotionAnalyze.AffdexExtentsion
{
    public static class FaceMapper
    {
        static FaceMapper() => Mapper.Initialize(cfg => cfg.CreateMap<Affdex.Face, Face>());

        public static IList<KeyValuePair<int, Face>> ToLocalFaces(this Dictionary<int, Affdex.Face> faces)
        {
            var localFaces = new List<KeyValuePair<int, Face>>();
            if (faces == null || !faces.Any())
                return localFaces;

            foreach (var id in faces.Keys)
                localFaces.Add(new KeyValuePair<int, Face>(id, Mapper.Map<Face>(faces[id])));

            return localFaces;
        }
    }
}
