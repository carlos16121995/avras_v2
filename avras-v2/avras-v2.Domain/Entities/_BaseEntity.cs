namespace avras_v2.Domain.Entities
{
    public class BaseEntity<T> : BaseEntitWithoutId
    {
        public T Id { get; set; }
    }
    public class BaseEntitWithoutId
    {
        private bool Active { get; set; }
        private bool Delete { get; set; }
        public DateTime UpdateDate { get; set; }

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
