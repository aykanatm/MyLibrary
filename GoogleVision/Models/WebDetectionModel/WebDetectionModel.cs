using System.Collections.Generic;
using Google.Apis.Vision.v1.Data;


namespace GoogleVision.Models.WebDetectionModel
{
    public class WebDetectionModel
    {
        public IList<WebEntityModel> WebEntities { get; private set; }
        public IList<WebImageModel> FullyMatchingWebImages { get; private set; }
        public IList<WebImageModel> PartiallyMatchingWebImages { get; private set; }
        public IList<WebImageModel> SimilarWebImages { get; private set; }
        public IList<WebPageModel> PagesWithMatchingImages { get; private set; }

        public WebDetectionModel(WebDetection webDetection)
        {
            WebEntities = new List<WebEntityModel>();
            FullyMatchingWebImages = new List<WebImageModel>();
            PartiallyMatchingWebImages = new List<WebImageModel>();
            SimilarWebImages = new List<WebImageModel>();
            PagesWithMatchingImages = new List<WebPageModel>();

            foreach (var webEntity in webDetection.WebEntities)
            {
                WebEntities.Add(new WebEntityModel(webEntity));
            }
            foreach (var matchingImage in webDetection.FullMatchingImages)
            {
                FullyMatchingWebImages.Add(new WebImageModel(matchingImage));
            }
            foreach (var partialMatchingImage in webDetection.PartialMatchingImages)
            {
                PartiallyMatchingWebImages.Add(new WebImageModel(partialMatchingImage));
            }
            foreach (var similarWebImage in webDetection.VisuallySimilarImages)
            {
                SimilarWebImages.Add(new WebImageModel(similarWebImage));
            }
            foreach (var pageWithMatchingImage in webDetection.PagesWithMatchingImages)
            {
                PagesWithMatchingImages.Add(new WebPageModel(pageWithMatchingImage));
            }
        }
    }
}
