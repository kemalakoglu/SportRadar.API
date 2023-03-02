using Moq;
using SportRadar.Application.Contract.Events;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {

        private readonly IMock<IApplicationCommandQuery> commandQueryMock;

        [Fact]
        public void ShouldStartEventsReturnMatchList()
        {

        }

        [Fact]
        public void ShouldStartEventsReturnEmpty()
        {

        }

        [Fact]
        public void ShouldStartEventsThrowsError()
        {

        }

        [Fact]
        public void ShouldFinishEventsReturnMatchListResult()
        {

        }

        [Fact]
        public void ShouldFinishEventsReturnNoMatchWarning()
        {

        }

        [Fact]
        public void ShouldFinishEventsThrowsError()
        {

        }
    }
}