using System.Collections.Generic;
using Google.Apis.Vision.v1.Data;

namespace GoogleVision.Models.CropHintsModel
{
    public class CropHintsAnnotationModel
    {
        public IList<CropHintModel> CropHints { get; private set; }
        public CropHintsAnnotationModel(CropHintsAnnotation cropHintsAnnotation)
        {
            CropHints = new List<CropHintModel>();
            foreach (var cropHint in cropHintsAnnotation.CropHints)
            {
                CropHints.Add(new CropHintModel(cropHint));
            }
        }
    }
}
