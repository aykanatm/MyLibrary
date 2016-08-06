using System.Collections.Generic;
using System.Linq;
using Google.Apis.Vision.v1.Data;
using MyLibrary.GoogleVision.ExtensionMethods;
using MyLibrary.GoogleVision.Models;

namespace MyLibrary.GoogleVision
{
    public class Annotations
    {
        public string LabelAnnotations { get; private set; }
        public string TextAnnotations { get; private set; }
        public string LogoAnnotations { get; private set; }
        public string LandmarkAnnotations { get; private set; }
        public IList<FaceAnnotation> FaceAnnotations { get; private set; }
        public SafeSearchModel SafeSearchAnnotation { get; private set; }
        public ImageProperties ImageProperties { get; }

        public Annotations(IList<EntityAnnotation> labelAnnotations, IList<EntityAnnotation> textAnnotations, IList<EntityAnnotation> logoAnnotations,
                           IList<EntityAnnotation> landmarkAnnotations, IList<FaceAnnotation> faceAnnotations, SafeSearchAnnotation safeSearchAnnotation,
                           ImageProperties imageProperties)
        {
            LabelAnnotations = labelAnnotations.EntityAnnotationListToString();
            TextAnnotations = textAnnotations.EntityAnnotationListToString();
            LogoAnnotations = logoAnnotations.EntityAnnotationListToString();
            LandmarkAnnotations = landmarkAnnotations.EntityAnnotationListToString();
            FaceAnnotations = faceAnnotations;
            SafeSearchAnnotation = safeSearchAnnotation.SafeSearchAnnotationsToModel();
            ImageProperties = imageProperties;
        }

        public IList<ColorRgba> GetDominantColors()
        {
            var colors = new List<ColorRgba>();
            foreach (var color in ImageProperties.DominantColors.Colors)
            {
                colors.Add(new ColorRgba()
                {
                    R = color.Color.Red == null ? 0 : color.Color.Red.Value,
                    G = color.Color.Green == null ? 0 : color.Color.Green.Value,
                    B = color.Color.Blue == null ? 0 : color.Color.Blue.Value,
                    A = color.Color.Alpha == null ? 0 : color.Color.Alpha.Value
                });
            }

            return colors;
        }
    }
}
