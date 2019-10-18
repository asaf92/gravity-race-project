using NSubstitute;
using NUnit.Framework;
using Game.Physics.GravitySources;
using Game.Physics;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Tests
{
    public class BallGravitySourceTests
    {
        // Constants
        private const float fixedDelta = 0.02f;
        private const float range = 50.0f;
        private const float strength = 9.82f;
        private Vector3 defaultPosition = new Vector3(0.0f, 0.0f, 0.0f);

        // Dependencies 
        private IGravitySourceController _controller;
        private IGravitySourceComponent _component;
        private IAreaOfEffect<IGravitySubjectController> _areaOfEffect;

        [SetUp]
        public void SetUp()
        {
            _component = Substitute.For<IGravitySourceComponent>();
            _areaOfEffect = Substitute.For<IAreaOfEffect<IGravitySubjectController>>();
            _controller = new BallGravitySourceController(_component, _areaOfEffect);
        }

        [Test]
        public void PhysicsStep_NoSubject_DoesNothing()
        {
            _controller.PhysicsStep();
        }

        [Test]
        public void Ctor_ComponentIsNull_Throws() => Assert.Throws<ArgumentNullException>(() =>
        {
            new BallGravitySourceController(null, _areaOfEffect);
        });

        [Test]
        public void Ctor_AoeIsNull_Throws() => Assert.Throws<ArgumentNullException>(() =>
        {
            new BallGravitySourceController(_component, null);
        });

        [Test]
        public void PhysicsStep_SubjectsInAoe_AppliesForce()
        {
            var subject = Substitute.For<IGravitySubjectController>();
            var subject2 = Substitute.For<IGravitySubjectController>();
            var subjectsListMock = new List<IGravitySubjectController>
            {
                subject,
                subject2
            };
            _areaOfEffect.ObjectsInTrigger.Returns(subjectsListMock);

            _controller.PhysicsStep();

            var temp = _areaOfEffect.Received().ObjectsInTrigger; // We need to assign the right expression to something in order to compile
            subject.ReceivedWithAnyArgs().ApplyForce(default);
        }

        [Test]
        public void PhysicsStep_SubjectInAoe_AppliesCorrectForceStrengthAndDirection()
        {
            var subject = Substitute.For<IGravitySubjectController>();
            subject.Position.Returns(new Vector3(0f, range/2, 0f)); // Ensuring subject is in range
            var subjectsListMock = new List<IGravitySubjectController> {subject};
            _areaOfEffect.ObjectsInTrigger.Returns(subjectsListMock);

            _component.Strength.Returns(strength);
            _controller.PhysicsStep();

            var temp = _areaOfEffect.Received().ObjectsInTrigger;
            subject.Received().ApplyForce(new Vector3(0f,-strength,0f));
        }
    }
}
