namespace Infra.SoldierTrackingAssesment.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }

        protected BaseEntity()
        {
            Guid = Guid.NewGuid();
        }
    }
}
