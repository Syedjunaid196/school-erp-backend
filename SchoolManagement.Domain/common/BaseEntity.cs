namespace SchoolManagement.Domain.common
{
    public class BaseEntity
    {
        public Guid Id { get; private set; } = Guid.CreateVersion7();

        public DateTime CreatedAt {  get; private set; }

        public DateTime UpdatedAt { get; private set; }

        protected BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }

        public void MarkUpdated()
        {
            UpdatedAt = DateTime.Now;
        }
    }
}
