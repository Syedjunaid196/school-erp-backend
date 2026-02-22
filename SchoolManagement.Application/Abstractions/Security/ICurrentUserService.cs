namespace SchoolManagement.Application.Abstractions.Security
{
    public interface ICurrentUserService
    {
        Guid GetUserId();
        string GetEmail();
        string GetRole();
    }
}
