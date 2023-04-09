using Source.Core;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Editor.Core
{
    [CustomEditor(typeof(VibrationController))]
    public class VibrationControllerEditor : UnityEditor.Editor
    {
        private Gamepad _gamepad;
        private float _intensity = 1.0f;
        private float _duration = 0.25f;
        
        public override void OnInspectorGUI()
        {
            // text input takes in float value for duration
            _gamepad = Gamepad.current;
            if (_gamepad == null)
            {
                EditorGUILayout.LabelField("No gamepad detected");
                base.OnInspectorGUI();
                return;
            }

            EditorGUILayout.LabelField("Current Gamepad: " + _gamepad.displayName);
            
            _duration = EditorGUILayout.FloatField("Duration", _duration);
            _intensity = EditorGUILayout.FloatField("Intensity", _intensity);
            
            if (GUILayout.Button("Vibrate"))
                ((VibrationController) target).VibrateController(_duration, _intensity);
            
            base.OnInspectorGUI();
        }
    }
}
