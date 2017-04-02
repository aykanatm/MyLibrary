using Google.Apis.Vision.v1.Data;

namespace GoogleVision.Models.WebDetectionModel
{
    public class WebEntityModel
    {
        public string EntityId { get; private set; }
        public string Description { get; private set; }
        public float? Score { get; private set; }
        
        public WebEntityModel(WebEntity webEntity)
        {
            Description = webEntity.Description;
            Score = webEntity.Score;
            EntityId = webEntity.EntityId;
        }
    }
}
