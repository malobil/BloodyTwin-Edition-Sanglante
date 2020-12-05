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
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Possess"",
                    ""type"": ""Button"",
                    ""id"": ""755bca78-7415-4661-ae7d-15efbc808b36"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Eject"",
                    ""type"": ""Button"",
                    ""id"": ""599b32cd-74f6-476b-8add-76ad33599e45"",
                    ""expectedControlType"": ""Button"",
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
                    ""path"": ""<Keyboard>/leftAlt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GoDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""525ab667-a81f-4f41-bcf4-76db24f6e360"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Possess"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""286b10c6-fd30-4611-b7d3-c1cb477a6c32"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Eject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Survivor"",
            ""id"": ""10ef5e94-5f61-446c-a723-a109d7a2c6f8"",
            ""actions"": [
                {
                    ""name"": ""ToggleLightTorch"",
                    ""type"": ""Button"",
                    ""id"": ""4fa938a9-1848-48c1-8444-542da435faf0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChargeUpLightTorch"",
                    ""type"": ""Value"",
                    ""id"": ""26d2fb7a-5078-4613-b8ce-457b68cca9f3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""35df1db0-de74-43fd-b181-1bccb42c2c5a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""ba43dba0-c341-438e-94d5-8a706faceb02"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2e2dce6e-4dfa-4247-a2d7-dfad51253f81"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleLightTorch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0890926-661e-4d30-932a-7e8b83c12779"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChargeUpLightTorch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19be8a2b-ab9e-4f8b-a8b7-0cd6fb536c21"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""187c654a-f23e-477d-a9a2-6ac292a71d35"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
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
        m_Ghost_Possess = m_Ghost.FindAction("Possess", throwIfNotFound: true);
        m_Ghost_Eject = m_Ghost.FindAction("Eject", throwIfNotFound: true);
        // Survivor
        m_Survivor = asset.FindActionMap("Survivor", throwIfNotFound: true);
        m_Survivor_ToggleLightTorch = m_Survivor.FindAction("ToggleLightTorch", throwIfNotFound: true);
        m_Survivor_ChargeUpLightTorch = m_Survivor.FindAction("ChargeUpLightTorch", throwIfNotFound: true);
        m_Survivor_Interact = m_Survivor.FindAction("Interact", throwIfNotFound: true);
        m_Survivor_Sprint = m_Survivor.FindAction("Sprint", throwIfNotFound: true);
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
    private readonly InputAction m_Ghost_Possess;
    private readonly InputAction m_Ghost_Eject;
    public struct GhostActions
    {
        private @GameControls m_Wrapper;
        public GhostActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @GoUp => m_Wrapper.m_Ghost_GoUp;
        public InputAction @GoDown => m_Wrapper.m_Ghost_GoDown;
        public InputAction @Possess => m_Wrapper.m_Ghost_Possess;
        public InputAction @Eject => m_Wrapper.m_Ghost_Eject;
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
                @Possess.started -= m_Wrapper.m_GhostActionsCallbackInterface.OnPossess;
                @Possess.performed -= m_Wrapper.m_GhostActionsCallbackInterface.OnPossess;
                @Possess.canceled -= m_Wrapper.m_GhostActionsCallbackInterface.OnPossess;
                @Eject.started -= m_Wrapper.m_GhostActionsCallbackInterface.OnEject;
                @Eject.performed -= m_Wrapper.m_GhostActionsCallbackInterface.OnEject;
                @Eject.canceled -= m_Wrapper.m_GhostActionsCallbackInterface.OnEject;
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
                @Possess.started += instance.OnPossess;
                @Possess.performed += instance.OnPossess;
                @Possess.canceled += instance.OnPossess;
                @Eject.started += instance.OnEject;
                @Eject.performed += instance.OnEject;
                @Eject.canceled += instance.OnEject;
            }
        }
    }
    public GhostActions @Ghost => new GhostActions(this);

    // Survivor
    private readonly InputActionMap m_Survivor;
    private ISurvivorActions m_SurvivorActionsCallbackInterface;
    private readonly InputAction m_Survivor_ToggleLightTorch;
    private readonly InputAction m_Survivor_ChargeUpLightTorch;
    private readonly InputAction m_Survivor_Interact;
    private readonly InputAction m_Survivor_Sprint;
    public struct SurvivorActions
    {
        private @GameControls m_Wrapper;
        public SurvivorActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToggleLightTorch => m_Wrapper.m_Survivor_ToggleLightTorch;
        public InputAction @ChargeUpLightTorch => m_Wrapper.m_Survivor_ChargeUpLightTorch;
        public InputAction @Interact => m_Wrapper.m_Survivor_Interact;
        public InputAction @Sprint => m_Wrapper.m_Survivor_Sprint;
        public InputActionMap Get() { return m_Wrapper.m_Survivor; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SurvivorActions set) { return set.Get(); }
        public void SetCallbacks(ISurvivorActions instance)
        {
            if (m_Wrapper.m_SurvivorActionsCallbackInterface != null)
            {
                @ToggleLightTorch.started -= m_Wrapper.m_SurvivorActionsCallbackInterface.OnToggleLightTorch;
                @ToggleLightTorch.performed -= m_Wrapper.m_SurvivorActionsCallbackInterface.OnToggleLightTorch;
                @ToggleLightTorch.canceled -= m_Wrapper.m_SurvivorActionsCallbackInterface.OnToggleLightTorch;
                @ChargeUpLightTorch.started -= m_Wrapper.m_SurvivorActionsCallbackInterface.OnChargeUpLightTorch;
                @ChargeUpLightTorch.performed -= m_Wrapper.m_SurvivorActionsCallbackInterface.OnChargeUpLightTorch;
                @ChargeUpLightTorch.canceled -= m_Wrapper.m_SurvivorActionsCallbackInterface.OnChargeUpLightTorch;
                @Interact.started -= m_Wrapper.m_SurvivorActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_SurvivorActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_SurvivorActionsCallbackInterface.OnInteract;
                @Sprint.started -= m_Wrapper.m_SurvivorActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_SurvivorActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_SurvivorActionsCallbackInterface.OnSprint;
            }
            m_Wrapper.m_SurvivorActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ToggleLightTorch.started += instance.OnToggleLightTorch;
                @ToggleLightTorch.performed += instance.OnToggleLightTorch;
                @ToggleLightTorch.canceled += instance.OnToggleLightTorch;
                @ChargeUpLightTorch.started += instance.OnChargeUpLightTorch;
                @ChargeUpLightTorch.performed += instance.OnChargeUpLightTorch;
                @ChargeUpLightTorch.canceled += instance.OnChargeUpLightTorch;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
            }
        }
    }
    public SurvivorActions @Survivor => new SurvivorActions(this);
    public interface IGeneralActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnMouseDelta(InputAction.CallbackContext context);
    }
    public interface IGhostActions
    {
        void OnGoUp(InputAction.CallbackContext context);
        void OnGoDown(InputAction.CallbackContext context);
        void OnPossess(InputAction.CallbackContext context);
        void OnEject(InputAction.CallbackContext context);
    }
    public interface ISurvivorActions
    {
        void OnToggleLightTorch(InputAction.CallbackContext context);
        void OnChargeUpLightTorch(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
    }
}
