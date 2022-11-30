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
        public DateTime UpdateAt { get; set; }

        public virtual void Delete()
        {
            Activated = false;
            Deleted = true;
            UpdateAt = DateTime.UtcNow;
        }
        public virtual void Inactivate()
        {
            Activated = !Activated;
            UpdateAt = DateTime.UtcNow;
        }
    }
}
