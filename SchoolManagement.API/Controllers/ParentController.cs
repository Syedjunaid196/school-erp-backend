using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.Parent;
using SchoolManagement.Application.Utils;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/Parents")]
    public class ParentController(IParentService parentService) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<Result<ParentResponse>> AddParent(ParentRequest model)
        {
            var result = await parentService.AddParent(model);
            return result;
        }
    }
}
