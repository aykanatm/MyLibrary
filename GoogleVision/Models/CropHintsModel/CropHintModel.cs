using System.Collections.Generic;
using Google.Apis.Vision.v1.Data;
using GoogleVision.Models.Common;

namespace GoogleVision.Models.CropHintsModel
{
    public class CropHintModel
    {
        public IList<VertexModel> Vertices { get; private set; }
        public CropHintModel(CropHint cropHint)
        {
            Vertices = new List<VertexModel>();
            foreach (var boundingPolyVertex in cropHint.BoundingPoly.Vertices)
            {
                Vertices.Add(new VertexModel(boundingPolyVertex));
            }
        }
    }
}
