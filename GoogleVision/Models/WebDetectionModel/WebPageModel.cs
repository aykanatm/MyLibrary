using Google.Apis.Vision.v1.Data;

namespace GoogleVision.Models.WebDetectionModel
{
    public class WebPageModel
    {
        public string Url { get; private set; }
        public float? Score { get; private set; }

        public WebPageModel(WebPage webImage)
        {
            Url = webImage.Url;
            Score = webImage.Score;
        }
    }
}
