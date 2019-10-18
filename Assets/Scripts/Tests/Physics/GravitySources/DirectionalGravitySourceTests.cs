using Game.Physics;
using Game.Physics.GravitySources;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Tests
{
    public class DirectionalGravitySourceTests
    {
        private const float deltaTime = 0.02f;
        private IGravitySourceController _controller;
        private IDirectionalGravitySourceComponent _componentMock;
        private IAreaOfEffect<IGravitySubjectController> _aoeMock;

        public DirectionalGravitySourceTests()
        {
            _componentMock = Substitute.For<IDirectionalGravitySourceComponent>();
            _aoeMock = Substitute.For<IAreaOfEffect<IGravitySubjectController>>();
        }

        [SetUp]
        public void SetUp()
        {
            _controller = new DirectionalGravitySourceController(_componentMock, _aoeMock);
        }

        [Test]
        public void Constructor_ComponentIsNull_Throws() => Assert.Throws<ArgumentNullException>(() =>
        {
            var badController = new DirectionalGravitySourceController(null, _aoeMock);
        });

        [Test]
        public void Constructor_AoeIsNull_Throws() => Assert.Throws<ArgumentNullException>(() =>
        {
            var badController = new DirectionalGravitySourceController(_componentMock, null);
        });

        [Test]
        public void PhysicsStep_GravitySubjectsIsNull_ThrowsInvalidOperationException() => Assert.Throws<InvalidOperationException>(()=>
        {
            _aoeMock.ObjectsInTrigger.ReturnsForAnyArgs((IEnumerable<IGravitySubjectController>)null);
            _controller.PhysicsStep();
        });

        [Test]
        public void PhysicsStep_AoeHasGravitySubjects_AppliesForce()
        {
            var subject = Substitute.For<IGravitySubjectController>();
            var subject2 = Substitute.For<IGravitySubjectController>();
            var subjectsListMock = new List<IGravitySubjectController>
            {
                subject,
                subject2
            };
            _aoeMock.ObjectsInTrigger.Returns(subjectsListMock);

            _controller.PhysicsStep();

            subject.ReceivedWithAnyArgs().ApplyForce(default);
            subject2.ReceivedWithAnyArgs().ApplyForce(default);
        }

        [Test]
        public void PhysicsStep_SubjectLeftAoe_ControllerStopsApplyingForce()
        {
            var subject = Substitute.For<IGravitySubjectController>();
            var subject2 = Substitute.For<IGravitySubjectController>();
            var subjectsListMock = new List<IGravitySubjectController>
            {
                subject,
                subject2
            };
            _aoeMock.ObjectsInTrigger.Returns(subjectsListMock);

            _controller.PhysicsStep();
        }
    }
}