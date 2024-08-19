namespace Infra.SoldierTrackingAssesment.Models
{
    public class TrainingData : BaseEntity
    {
        public int SoldierId { get; set; }

        public required Soldier Soldier { get; set; }

        public int SensorId { get; set; }

        public required BaseSensor Sensor { get; set; }

        public int TrainingId { get; set; }

        public required Training Training { get; set; }
    }
}
