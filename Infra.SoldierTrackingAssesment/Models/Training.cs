namespace Infra.SoldierTrackingAssesment.Models
{
    public class Training : BaseEntity
    {
        public required string Information { get; set; }

        public ICollection<Soldier> Soldiers { get; set; } = [];

        public ICollection<TrainingData> Data { get; set; } = [];
    }
}
