using AutoMapper;

namespace SportRadar.Domain.Aggregate.Fixture
{
    public class FixtureRepository : IFixtureRepository
    {
        private readonly IMapper mapper;
        public FixtureRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}
