using Google.Apis.Vision.v1.Data;

namespace GoogleVision.Models
{
    public class LandmarkModel
    {
        public string Type { get; }
        public float X { get; }
        public float Y { get; }
        public float Z { get; }

        public LandmarkModel(Landmark landmark)
        {
            Type = landmark.Type;
            X = landmark.Position.X != null ? landmark.Position.X.Value : 0;
            Y = landmark.Position.Y != null ? landmark.Position.Y.Value : 0;
            Z = landmark.Position.Z != null ? landmark.Position.Z.Value : 0;
        }
    }
}
