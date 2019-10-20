using Game.Race;
using NSubstitute;
using NUnit.Framework;
using Presentation.UI;

namespace Tests
{
    public class RaceStartCountdownTests
    {
        private const int DefaultCountdownTime = 1;

        private IRaceStartCountdownComp _componentMock;
        private IRaceManager _raceManager;
        private RaceStartCountdownController _countdownController;

        [SetUp]
        public void SetUp()
        {
            _componentMock = Substitute.For<IRaceStartCountdownComp>();
            _raceManager = Substitute.For<IRaceManager>();
            _countdownController = new RaceStartCountdownController(_componentMock, _raceManager);
        }
    }
}
