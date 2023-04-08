using System.Collections;
using NUnit.Framework;
using Source.Core;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;

namespace Tests.Runtime
{
    public class VibrationControllerTests
    {
        private VibrationController CreateVibrationController()
        {
            return new GameObject().AddComponent<VibrationController>();
        }

        [UnityTest]
        public IEnumerator Test_VibrateGamepad_WhenGamepadDeviceExists()
        {
            InputSystem.AddDevice<Gamepad>();
            var vibrationController = CreateVibrationController();
            Assert.IsNotNull(vibrationController.Gamepad);

            vibrationController.VibrateController(0.3f, 0.8f);
            Assert.IsTrue(vibrationController.IsVibrating);

            yield return new WaitForSeconds(0.3f);
            Assert.IsFalse(vibrationController.IsVibrating);
        }
    }
}
