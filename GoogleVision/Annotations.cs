using System.Collections.Generic;
using Google.Apis.Vision.v1.Data;
using GoogleVision.ExtensionMethods;
using GoogleVision.Models;

namespace GoogleVision
{
    public class Annotations
    {
        public string LabelAnnotations { get; private set; }
        public string TextAnnotations { get; private set; }
        public string LogoAnnotations { get; private set; }
        public string LandmarkAnnotations { get; private set; }
        public IList<FaceAnnotationModel> FaceAnnotations { get;}
        public SafeSearchModel SafeSearchAnnotation { get;}
        public ImagePropertiesModel ImageProperties { get; }

        public Annotations(IList<EntityAnnotation> labelAnnotations, IList<EntityAnnotation> textAnnotations, IList<EntityAnnotation> logoAnnotations,
                           IList<EntityAnnotation> landmarkAnnotations, IList<FaceAnnotation> faceAnnotations, SafeSearchAnnotation safeSearchAnnotation,
                           ImageProperties imageProperties)
        {
            LabelAnnotations = labelAnnotations.EntityAnnotationListToString();
            TextAnnotations = textAnnotations.EntityAnnotationListToString();
            LogoAnnotations = logoAnnotations.EntityAnnotationListToString();
            LandmarkAnnotations = landmarkAnnotations.EntityAnnotationListToString();
            SafeSearchAnnotation = new SafeSearchModel(safeSearchAnnotation);
            ImageProperties = new ImagePropertiesModel(imageProperties);

            foreach (var faceAnnotation in faceAnnotations)
            {
                FaceAnnotations.Add(new FaceAnnotationModel(faceAnnotation));
            }
        }
    }
}
