namespace Infra.SoldierTrackingAssesment.Models
{
    public class Soldier : BaseEntity
    {
        public required string Name { get; set; }

        public int CountryId { get; set; }
        public required Country Country { get; set; }

        public int RankId { get; set; }
        public required Rank Rank { get; set; }

        public ICollection<Training> Trainings { get; set; } = [];
    }
}
