namespace Infra.SoldierTrackingAssesment.Models
{
    public class Rank : BaseEntity
    {
        public required string Title { get; set; }

        public ICollection<Soldier> Soldiers { get; set; } = [];
    }
}
