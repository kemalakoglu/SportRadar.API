using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportRadar.Application.Contract.Events;

namespace SportRadar.Presentation.API.Controllers
{
    public class FıxtureController : Controller
    {
        private readonly IApplicationCommandQuery applicationCommandQuery;
        private readonly IMapper mapper;
        public FıxtureController(IApplicationCommandQuery applicationCommandQuery, IMapper mapper)
        {
            this.applicationCommandQuery = applicationCommandQuery;
            this.mapper = mapper;
        }
    }
}
