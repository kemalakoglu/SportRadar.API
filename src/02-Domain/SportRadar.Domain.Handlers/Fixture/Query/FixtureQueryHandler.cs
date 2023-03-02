using SportRadar.Domain.Aggregate.Fixture;
using AutoMapper;

namespace SportRadar.Domain.Handlers
{
    public class FixtureQueryHandler
    {
        private readonly IMapper mapper;
        private readonly IFixtureRepository fixtureRepository;
        public FixtureQueryHandler(IMapper mapper, IFixtureRepository fixtureRepository)
        {
            this.mapper = mapper;
            this.fixtureRepository = fixtureRepository;
        }
    }
}
