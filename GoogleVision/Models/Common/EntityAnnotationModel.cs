using System.Collections.Generic;
using Google.Apis.Vision.v1.Data;

namespace GoogleVision.Models.Common
{
    public class EntityAnnotationModel
    {
        public string Description { get; private set; }
        public IList<VertexModel> Vertices { get; private set; }
        public string Locale { get; private set; }
        public IList<LocationInfoModel> Locations { get; private set; }
        public EntityAnnotationModel(EntityAnnotation entityAnnotation)
        {
            Description = entityAnnotation.Description;
            Locale = entityAnnotation.Locale;

            Vertices = new List<VertexModel>();
            foreach (var boundingPolyVertex in entityAnnotation.BoundingPoly.Vertices)
            {
                Vertices.Add(new VertexModel(boundingPolyVertex));
            }

            Locations = new List<LocationInfoModel>();
            foreach (var location in entityAnnotation.Locations)
            {
                Locations.Add(new LocationInfoModel(location));
            }
        }
    }
}
