// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""General"",
            ""id"": ""5111979e-b2d8-4a4b-8909-7f6a0d0cb861"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d206b2e5-2f0f-460b-b654-8f15ee92796b"",
                    ""expectedControlType"": ""Dpad"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseDelta"",
                    ""type"": ""PassThrough"",
                    ""id"": ""751b21ad-e045-4945-a371-1f6e654bd684"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""bc68b127-d775-4306-93d1-7d12b562629b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""29005601-5a30-4d39-a866-a614c13a7790"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9bd8e5fd-eeaa-46d8-8822-31dccd79a76b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5a6460b9-bf49-4d68-a2d0-7d348b0eb6c3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c1554f45-b898-4ec0-8ea5-6dfbba7e3179"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0647cb89-6c05-4330-9a00-62abb6b696ed"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Ghost"",
            ""id"": ""f1e26670-698e-4eff-a582-a78cbad919e9"",
            ""actions"": [
                {
                    ""name"": ""GoUp"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a6b83b87-4f77-4e95-a6bd-022240ac7c63"",
                    ""expectedControlType"": ""Digital"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GoDown"",
                    ""type"": ""PassThrough"",
                    ""id"": ""388f1dca-3c65-4347-83b1-55f53b61d24b"",
                    ""expectedControlType"": ""Digital"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""654be943-34b6-4b8c-b15c-f6a7c0412ef0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GoUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9a248e5-9b2b-4f0a-8e7e-9017c751f3fd"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GoDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // General
        m_General = asset.FindActionMap("General", throwIfNotFound: true);
        m_General_Move = m_General.FindAction("Move", throwIfNotFound: true);
        m_General_MouseDelta = m_General.FindAction("MouseDelta", throwIfNotFound: true);
        // Ghost
        m_Ghost = asset.FindActionMap("Ghost", throwIfNotFound: true);
        m_Ghost_GoUp = m_Ghost.FindAction("GoUp", throwIfNotFound: true);
        m_Ghost_GoDown = m_Ghost.FindAction("GoDown", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // General
    private readonly InputActionMap m_General;
    private IGeneralActions m_GeneralActionsCallbackInterface;
    private readonly InputAction m_General_Move;
    private readonly InputAction m_General_MouseDelta;
    public struct GeneralActions
    {
        private @GameControls m_Wrapper;
        public GeneralActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_General_Move;
        public InputAction @MouseDelta => m_Wrapper.m_General_MouseDelta;
        public InputActionMap Get() { return m_Wrapper.m_General; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GeneralActions set) { return set.Get(); }
        public void SetCallbacks(IGeneralActions instance)
        {
            if (m_Wrapper.m_GeneralActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMove;
                @MouseDelta.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMouseDelta;
            }
            m_Wrapper.m_GeneralActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @MouseDelta.started += instance.OnMouseDelta;
                @MouseDelta.performed += instance.OnMouseDelta;
                @MouseDelta.canceled += instance.OnMouseDelta;
            }
        }
    }
    public GeneralActions @General => new GeneralActions(this);

    // Ghost
    private readonly InputActionMap m_Ghost;
    private IGhostActions m_GhostActionsCallbackInterface;
    private readonly InputAction m_Ghost_GoUp;
    private readonly InputAction m_Ghost_GoDown;
    public struct GhostActions
    {
        private @GameControls m_Wrapper;
        public GhostActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @GoUp => m_Wrapper.m_Ghost_GoUp;
        public InputAction @GoDown => m_Wrapper.m_Ghost_GoDown;
        public InputActionMap Get() { return m_Wrapper.m_Ghost; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GhostActions set) { return set.Get(); }
        public void SetCallbacks(IGhostActions instance)
        {
            if (m_Wrapper.m_GhostActionsCallbackInterface != null)
            {
                @GoUp.started -= m_Wrapper.m_GhostActionsCallbackInterface.OnGoUp;
                @GoUp.performed -= m_Wrapper.m_GhostActionsCallbackInterface.OnGoUp;
                @GoUp.canceled -= m_Wrapper.m_GhostActionsCallbackInterface.OnGoUp;
                @GoDown.started -= m_Wrapper.m_GhostActionsCallbackInterface.OnGoDown;
                @GoDown.performed -= m_Wrapper.m_GhostActionsCallbackInterface.OnGoDown;
                @GoDown.canceled -= m_Wrapper.m_GhostActionsCallbackInterface.OnGoDown;
            }
            m_Wrapper.m_GhostActionsCallbackInterface = instance;
            if (instance != null)
            {
                @GoUp.started += instance.OnGoUp;
                @GoUp.performed += instance.OnGoUp;
                @GoUp.canceled += instance.OnGoUp;
                @GoDown.started += instance.OnGoDown;
                @GoDown.performed += instance.OnGoDown;
                @GoDown.canceled += instance.OnGoDown;
            }
        }
    }
    public GhostActions @Ghost => new GhostActions(this);
    public interface IGeneralActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnMouseDelta(InputAction.CallbackContext context);
    }
    public interface IGhostActions
    {
        void OnGoUp(InputAction.CallbackContext context);
        void OnGoDown(InputAction.CallbackContext context);
    }
}
