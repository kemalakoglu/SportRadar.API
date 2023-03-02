using MediatR;
using SportRadar.Application.Contract.Events;

namespace SportRadar.Application.Commands
{
    public partial class ApplicationCommandQuery: IApplicationCommandQuery
    {
        private readonly IMediator mediator;

        public ApplicationCommandQuery(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
