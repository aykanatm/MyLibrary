using Google.Apis.Vision.v1.Data;

namespace MyLibrary.GoogleVision.Models
{
    public class VertexModel
    {
        public int X { get;}
        public int Y { get;}

        public VertexModel(Vertex vertex)
        {
            X = vertex.X != null ? vertex.X.Value : 0;
            Y = vertex.Y != null ? vertex.Y.Value : 0;
        }
    }
}
