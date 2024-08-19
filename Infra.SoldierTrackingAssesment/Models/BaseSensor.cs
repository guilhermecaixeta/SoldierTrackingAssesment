namespace Infra.SoldierTrackingAssesment.Models
{
    public abstract class BaseSensor : BaseEntity
    {
        public required string Name { get; set; }
        public required string Type { get; set; }
    }
}
