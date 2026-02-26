namespace SchoolManagement.Domain.common
{
    public class BaseEntity
    {
        public Guid Id { get; protected set; } = Guid.CreateVersion7();

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        protected BaseEntity()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public void MarkUpdated()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
