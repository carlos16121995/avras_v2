namespace avras_v2.Domain.Entities
{
    public class BaseEntity<T> : BaseEntitWithoutId
    {
        public T Id { get; set; }
    }
    public class BaseEntitWithoutId
    {
        private bool Active { get; set; } = true;
        private bool Delete { get; set; } = false;
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;

        public virtual void Deleted()
        {
            Active = false;
            Delete = true;
            UpdateDate = DateTime.UtcNow;
        }
        public virtual void UpdeteStatus()
        {
            Active = !Active;
            UpdateDate = DateTime.UtcNow;
        }
    }
}
