using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace HeadhuntersCandidatesDatabase.Controllers
{
    public abstract class BaseHrController : ControllerBase
    {
        protected IMapper _mapper;
        protected BaseHrController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
