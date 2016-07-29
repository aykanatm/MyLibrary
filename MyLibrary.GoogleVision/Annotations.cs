using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Vision.v1.Data;

namespace MyLibrary.GoogleVision
{
    public class Annotations
    {
        public IList<EntityAnnotation> LabelAnnotations { get; private set; }
        public IList<EntityAnnotation> TextAnnotations { get; private set; }
        public IList<EntityAnnotation> LogoAnnotations { get; private set; }
        public IList<EntityAnnotation> LandmarkAnnotations { get; private set; }
        public IList<FaceAnnotation> FaceAnnotations { get; private set; }
        public SafeSearchAnnotation SafeSearchAnnotation { get; private set; }
        public ImageProperties ImageProperties { get; private set; }

        public Annotations(IList<EntityAnnotation> labelAnnotations, IList<EntityAnnotation> textAnnotations, IList<EntityAnnotation> logoAnnotations,
                           IList<EntityAnnotation> landmarkAnnotations, IList<FaceAnnotation> faceAnnotations, SafeSearchAnnotation safeSearchAnnotation,
                           ImageProperties imageProperties)
        {
            LabelAnnotations = labelAnnotations;
            TextAnnotations = textAnnotations;
            LogoAnnotations = logoAnnotations;
            LandmarkAnnotations = landmarkAnnotations;
            FaceAnnotations = faceAnnotations;
            SafeSearchAnnotation = safeSearchAnnotation;
            ImageProperties = imageProperties;
        }
    }
}
