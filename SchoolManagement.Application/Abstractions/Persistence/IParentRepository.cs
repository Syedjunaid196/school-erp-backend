using SchoolManagement.Application.RR_Models.Parent;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Abstractions.Persistence
{
    public interface IParentRepository: IBaseRepository<Parent>
    {
        public Task<List<ParentListResponse>> GetParentList();
    }
}
