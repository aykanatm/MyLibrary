using Google.Apis.Vision.v1.Data;

namespace GoogleVision.Models.Common
{
    public class LocationInfoModel
    {
        public double? Latitude { get; private set; }
        public double? Longitude { get; private set; }
        public LocationInfoModel(LocationInfo locationInfo)
        {
            Latitude = locationInfo.LatLng.Latitude;
            Longitude = locationInfo.LatLng.Longitude;
        }
    }
}
