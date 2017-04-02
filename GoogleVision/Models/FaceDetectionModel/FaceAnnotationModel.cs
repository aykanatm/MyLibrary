using System.Collections.Generic;
using Google.Apis.Vision.v1.Data;
using GoogleVision.Models.Common;

namespace GoogleVision.Models.FaceDetectionModel
{
    public class FaceAnnotationModel
    {
        public IList<VertexModel> Vertices { get;}
        public IList<LandmarkModel> Landmarks { get; }

        public float DetectionConfidence { get; }
        public string AngerLikelihood { get;}
        public string JoyLikelihood { get;}
        public string SorrowLikelihood { get; }
        public string HeadWearLikelihood { get; }
        public string BlurredLikelihood { get; }
        public string UnderexposedLikelihood { get; }
        public string SupriseLikelihood { get; set; }
        
        public FaceAnnotationModel(FaceAnnotation faceAnnotation)
        {
            Vertices = new List<VertexModel>();
            foreach (var vertex in faceAnnotation.BoundingPoly.Vertices)
            {
                Vertices.Add(new VertexModel(vertex));
            }

            Landmarks = new List<LandmarkModel>();
            foreach (var landmark in faceAnnotation.Landmarks)
            {
                Landmarks.Add(new LandmarkModel(landmark));
            }

            DetectionConfidence = faceAnnotation.DetectionConfidence != null ? faceAnnotation.DetectionConfidence.Value : 0;
            AngerLikelihood = faceAnnotation.AngerLikelihood;
            JoyLikelihood = faceAnnotation.JoyLikelihood;
            SorrowLikelihood = faceAnnotation.SorrowLikelihood;
            HeadWearLikelihood = faceAnnotation.HeadwearLikelihood;
            BlurredLikelihood = faceAnnotation.BlurredLikelihood;
            UnderexposedLikelihood = faceAnnotation.UnderExposedLikelihood;
            SupriseLikelihood = faceAnnotation.SurpriseLikelihood;
        }
    }
}
