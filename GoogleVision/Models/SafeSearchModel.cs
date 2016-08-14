using Google.Apis.Vision.v1.Data;

namespace GoogleVision.Models
{
    public class SafeSearchModel
    {
        public string Adult { get;}
        public string Violence { get;}
        public string Spoof { get;}
        public string Medical { get;}

        public SafeSearchModel(SafeSearchAnnotation safeSearchAnnotation)
        {
            Adult = safeSearchAnnotation.Adult;
            Violence = safeSearchAnnotation.Violence;
            Spoof = safeSearchAnnotation.Spoof;
            Medical = safeSearchAnnotation.Medical;
        }
    }
}
