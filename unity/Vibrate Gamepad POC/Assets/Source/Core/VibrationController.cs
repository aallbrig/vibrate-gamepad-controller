using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Core
{
    public class VibrationController : MonoBehaviour
    {

        public Gamepad Gamepad { get; set; }

        public bool IsVibrating { get; private set; }

        private void Awake()
        {
            Gamepad = Gamepad.current;
            InputSystem.onDeviceChange += OnDeviceChange;
        }

        private void OnDestroy()
        {
            InputSystem.onDeviceChange -= OnDeviceChange;
        }

        private void OnDeviceChange(InputDevice device, InputDeviceChange change)
        {
            if (device is Gamepad && (change == InputDeviceChange.Added || change == InputDeviceChange.Reconnected))
            {
                Gamepad = Gamepad.current;
            }
            else if (device is Gamepad && (change == InputDeviceChange.Removed || change == InputDeviceChange.Disconnected))
            {
                Gamepad = Gamepad.current;
            }
        }

        [ExecuteInEditMode]
        public void VibrateController(float duration, float intensity)
        {
            if (Gamepad != null)
            {
                StartCoroutine(VibrationRoutine(duration, intensity));
            }
        }

        [ExecuteInEditMode]
        private IEnumerator VibrationRoutine(float duration, float intensity)
        {
            Gamepad.SetMotorSpeeds(intensity * 0.8f, intensity * 1.2f);
            IsVibrating = true;
            yield return new WaitForSeconds(duration);
            IsVibrating = false;
            Gamepad.SetMotorSpeeds(0, 0);
        }

        private void OnTest1IntensityVibration() => VibrateController(0.25f, 1.1f);
        private void OnTest2IntensityVibration() => VibrateController(0.25f, 2.15f);
        private void OnTest3IntensityVibration() => VibrateController(0.25f, 3.2f);
        private void OnTest4IntensityVibration() => VibrateController(0.25f, 4.3f);
        private void OnTest5IntensityVibration() => VibrateController(0.45f, 0.4f);
        private void OnTest6IntensityVibration() => VibrateController(0.45f, 0.5f);
        private void OnTest7IntensityVibration() => VibrateController(0.45f, 0.6f);
        private void OnTest8IntensityVibration() => VibrateController(0.55f, 0.7f);
    }
}
