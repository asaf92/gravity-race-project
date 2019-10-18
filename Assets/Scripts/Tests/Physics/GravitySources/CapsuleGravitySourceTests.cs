using Game.Physics;
using Game.Physics.GravitySources;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tests
{
    public class CapsuleGravitySourceControllerTests
    {
        private IGravitySourceController _controller;
        private ICapsuleGravitySourceComponent _component;
        private IAreaOfEffect<IGravitySubjectController> _aoe;
        private IGravitySubjectController _mockSubject;

        private Vector3 gravitySourcePosition = new Vector3(0f, 0f, 0f);
        private Vector3 gravitySourceZDirection = new Vector3(0f, 0f, 1f);
        private const float gravityStrength = 9.8f;

        [SetUp]
        public void SetUp()
        {
            // Init fake component
            _component = Substitute.For<ICapsuleGravitySourceComponent>();
            _component.Position.Returns(gravitySourcePosition);
            _component.ForwardDirection.Returns(gravitySourceZDirection);
            _component.Strength.Returns(gravityStrength);

            // Init aoe and controller
            _aoe = Substitute.For<IAreaOfEffect<IGravitySubjectController>>();
            _controller = new CapsuleGravitySourceController(_component, _aoe);

            IList<IGravitySubjectController> subjectsList = new List<IGravitySubjectController>();
            _mockSubject = Substitute.For<IGravitySubjectController>();
            subjectsList.Add(_mockSubject);
            _aoe.ObjectsInTrigger.Returns(subjectsList);
        }

        [Test]
        public void EmptyTest()
        {

        }

        [Test]
        public void PhysicsStep_AoeIsNull_Throws() => Assert.Throws<InvalidOperationException>(() =>
        {
            var controller = new CapsuleGravitySourceController(_component, null);

            controller.PhysicsStep();
        });

        [Test]
        public void PhysicsStep_AppliesForceToSubjects()
        {
            _controller.PhysicsStep();

            _mockSubject.ReceivedWithAnyArgs().ApplyForce(default);
        }

        [Test]
        public void PhysicsStep_AppliesForceWithCorrectDirection()
        {
            var subjectPosition = new Vector3(5f, 5f, 0f);
            _mockSubject.Position.Returns(subjectPosition);
            _controller.PhysicsStep();

            var expectedDirection = Vector3.Normalize(gravitySourcePosition - subjectPosition);
            _mockSubject.Received().ApplyForce(expectedDirection * gravityStrength);
        }
    }
}