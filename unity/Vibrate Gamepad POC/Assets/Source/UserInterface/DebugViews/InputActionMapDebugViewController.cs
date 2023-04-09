using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace Source.UserInterface.DebugViews
{
    public class InputActionMapDebugViewController : MonoBehaviour
    {
        public InputActionAsset inputActionAsset;
        public string debugLabelSelector = "debugLabel";
        private Label _debugLabel;
        private UIDocument _uiDocument;
        private VisualElement _root;
        private void Awake()
        {
            inputActionAsset ??= GetComponent<PlayerInput>().actions;
            if (inputActionAsset == null)
            {
                Debug.LogError($"{name} | InputActionAsset is not defined");
                return;
            }
            _uiDocument = GetComponent<UIDocument>();
            if (_uiDocument == null)
            {
                Debug.LogError($"{name} | UI Document component cannot be found");
                return;
            }
            _root = _uiDocument.rootVisualElement;
            if (_root == null)
            {
                Debug.LogError($"{name} | UI Document root visual element is not defined (check the UI document component)");
                return;
            }
            _debugLabel = _root.Q<Label>(debugLabelSelector);
            if (_debugLabel == null)
            {
                Debug.LogError(
                    $"{name} | unable to find selector {debugLabelSelector} in UI document (is this the right ui document?)"
                );
                return;
            }

            foreach (var action in inputActionAsset)
                action.performed += context => _debugLabel.text = context.action.name;
        }
    }
}
