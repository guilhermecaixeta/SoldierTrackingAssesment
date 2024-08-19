namespace Infra.SoldierTrackingAssesment.Models
{
    public class Country : BaseEntity
    {
        public required string Name { get; set; }

        public ICollection<Soldier> Soldiers { get; set; } = [];
    }
}