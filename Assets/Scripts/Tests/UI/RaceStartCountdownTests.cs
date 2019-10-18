using NSubstitute;
using NUnit.Framework;
using Presentation.UI;

namespace Tests
{
    public class RaceStartCountdownTests
    {
        private const int DefaultCountdownTime = 1;

        IRaceStartCountdownComp _componentMock;
        RaceStartCountdownController _countdownController;

        [SetUp]
        public void SetUp()
        {
            _componentMock = Substitute.For<IRaceStartCountdownComp>();
            _countdownController = new RaceStartCountdownController(_componentMock);
        }

        [Test]
        public void StartCountdown_ValidInput_CallsComponent()
        {
            _countdownController.StartCountdown(DefaultCountdownTime);

            _componentMock.Received().StartCountDown(DefaultCountdownTime);
        }
    }
}
