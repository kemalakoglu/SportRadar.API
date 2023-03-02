using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportRadar.Application.Contract.Events;

namespace SportRadar.Presentation.API.Controllers
{
    public class FıxtureController : Controller
    {
        private readonly IApplicationCommandQuery applicationCommandQuery;
        public FıxtureController(IApplicationCommandQuery applicationCommandQuery)
        {
            this.applicationCommandQuery = applicationCommandQuery;
        }
    }
}
