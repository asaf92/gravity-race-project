using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private const float MaximumBrakeValue = Single.NegativeInfinity;
        private const float MaximumHandbrakeValue = Single.PositiveInfinity;
        private CarController m_Car; // the car controller we want to use
        private bool _applyMaxBrake;
        private bool _overrideControls;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            if (_overrideControls && _applyMaxBrake)
            {
                m_Car.Move(0.0f, MaximumBrakeValue, MaximumBrakeValue, MaximumHandbrakeValue);
                return;
            }

            // pass the input to the car!
            float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
            float vertical = CrossPlatformInputManager.GetAxis("Vertical");
            float roll = CrossPlatformInputManager.GetAxis("Roll");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(horizontal, vertical, vertical, handbrake, roll);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }

        public void MaxBrake()
        {
            _applyMaxBrake = true;
            _overrideControls = true;
        }
    }
}
