using System.Collections.Generic;
using Google.Apis.Vision.v1.Data;
using GoogleVision.Models.Common;
using GoogleVision.Models.CropHintsModel;
using GoogleVision.Models.FaceDetectionModel;
using GoogleVision.Models.ImagePropertiesModel;
using GoogleVision.Models.SafeSearchModel;
using GoogleVision.Models.WebDetectionModel;

namespace GoogleVision
{
    public class Annotations
    {
        public IList<EntityAnnotationModel> Labels { get; }
        public IList<EntityAnnotationModel> Text{ get; }
        public IList<EntityAnnotationModel> Logos { get; }
        public IList<EntityAnnotationModel> Landmarks { get; }
        public IList<FaceAnnotationModel> Faces { get; }
        public SafeSearchModel SafeSearch{ get; private set; }
        public ImagePropertiesModel ImageProperties { get; private set; }
        public WebDetectionModel WebDetections { get; private set; }
        public CropHintsAnnotationModel CropHints { get; private set; }

        public Annotations(IList<EntityAnnotation> labelAnnotations, IList<EntityAnnotation> textAnnotations, IList<EntityAnnotation> logoAnnotations,
                           IList<EntityAnnotation> landmarkAnnotations, IList<FaceAnnotation> faceAnnotations, SafeSearchAnnotation safeSearchAnnotation,
                           ImageProperties imageProperties, WebDetection webDetection, CropHintsAnnotation cropHintsAnnoation)
        {
            Labels = new List<EntityAnnotationModel>();
            Text = new List<EntityAnnotationModel>();
            Logos = new List<EntityAnnotationModel>();
            Landmarks = new List<EntityAnnotationModel>();
            Faces = new List<FaceAnnotationModel>();

            SafeSearch = new SafeSearchModel(safeSearchAnnotation);
            ImageProperties = new ImagePropertiesModel(imageProperties);
            WebDetections = new WebDetectionModel(webDetection);
            CropHints = new CropHintsAnnotationModel(cropHintsAnnoation);

            foreach (var labelAnnotation in labelAnnotations)
            {
                Labels.Add(new EntityAnnotationModel(labelAnnotation));
            }
            foreach (var textAnnotation in textAnnotations)
            {
                Text.Add(new EntityAnnotationModel(textAnnotation));
            }
            foreach (var logoAnnotation in logoAnnotations)
            {
                Logos.Add(new EntityAnnotationModel(logoAnnotation));
            }
            foreach (var landmarkAnnotation in landmarkAnnotations)
            {
                Landmarks.Add(new EntityAnnotationModel(landmarkAnnotation));
            }
            foreach (var faceAnnotation in faceAnnotations)
            {
                Faces.Add(new FaceAnnotationModel(faceAnnotation));
            }
        }
    }
}
