using NetTopologySuite.Geometries;

namespace Infra.SoldierTrackingAssesment.Models
{
    public class Location : BaseEntity
    {
        public int SensorId { get; set; }

        public required GeolocalizationSensor Sensor { get; set; }

        public required Point Coordinates { get; set; }
    }
}