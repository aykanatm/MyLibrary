using Google.Apis.Vision.v1.Data;

namespace GoogleVision.Models.WebDetectionModel
{
    public class WebImageModel
    {
        public string Url { get; private set; }
        public float? Score { get; private set; }

        public WebImageModel(WebImage webImage)
        {
            Url = webImage.Url;
            Score = webImage.Score;
        }
    }
}
