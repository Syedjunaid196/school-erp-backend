using SchoolManagement.Application.RR_Models.Parent;
using SchoolManagement.Application.Utils;

namespace SchoolManagement.Application.Abstractions.Services
{
    public interface IParentService
    {
        Task<Result<ParentResponse>> AddParent(ParentRequest model);
    }
}
