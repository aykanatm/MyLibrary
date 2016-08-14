using System.Collections.Generic;
using Google.Apis.Vision.v1.Data;

namespace GoogleVision.Models
{
    public class ImagePropertiesModel
    {
        public IList<ColorRgba> DominantColors { get; }
        public ImagePropertiesModel(ImageProperties imageProperties)
        {
            DominantColors = new List<ColorRgba>();
            foreach (var colorInfo in imageProperties.DominantColors.Colors)
            {
                DominantColors.Add(new ColorRgba(colorInfo));
            }
        }
    }
}
