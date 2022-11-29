namespace avras_v2.Domain.Entities
{
    public class BaseEntity<T> : BaseEntityWithoutId
    {
        public T Id { get; set; }
    }
    public class BaseEntityWithoutId
    {
        private bool Activated { get; set; } = true;
        private bool Deleted { get; set; } = false;
        public DateTime UpdateDate { get; set; }

        public virtual void Delete()
        {
            Activated = false;
            Deleted = true;
            UpdateDate = DateTime.UtcNow;
        }
        public virtual void Inactivate()
        {
            Activated = !Activated;
            UpdateDate = DateTime.UtcNow;
        }
    }
}
