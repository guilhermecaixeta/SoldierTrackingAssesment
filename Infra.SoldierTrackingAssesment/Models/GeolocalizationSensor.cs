namespace Infra.SoldierTrackingAssesment.Models
{
    public class GeolocalizationSensor : BaseSensor
    {
        public GeolocalizationSensor()
        {
            Type = "Geolocatization";
        }

        public ICollection<Location> Locations { get; set; } = [];
    }
}
