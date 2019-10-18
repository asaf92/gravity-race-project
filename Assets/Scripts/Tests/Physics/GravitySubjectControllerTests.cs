using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using Game.Physics;
using System;

namespace Tests
{
    public class GravitySubjectControllerTests
    {
        private readonly Vector3 defaultGravityVector = new Vector3(0.0f, 2.0f, 3.0f);
        private IGravitySubjectController _gravitySubject;
        private IGravitySubjectComp _mockComponent;

        [SetUp]
        public void SetUp()
        {
            _mockComponent = Substitute.For<IGravitySubjectComp>();
            _gravitySubject = new GravitySubjectController(_mockComponent);
        }

        [Test]
        public void ApplyForce_CallsApplyForceOnComponent()
        {
            _gravitySubject.ApplyForce(defaultGravityVector);

            _mockComponent.Received().ApplyForce(defaultGravityVector);
        }

        [Test]
        public void GravitySubjectController_IGravitySubjectIsNull_Throws() => Assert.Throws<ArgumentNullException>
        (() =>
        {
            new GravitySubjectController(null);
        });

    }
}
