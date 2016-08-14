using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Vision.v1.Data;

namespace MyLibrary.GoogleVision.Models
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
