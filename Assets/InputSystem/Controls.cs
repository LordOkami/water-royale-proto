// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Ball"",
            ""id"": ""d8a28251-6844-4196-a767-794dcb15d2ff"",
            ""actions"": [
                {
                    ""name"": ""spawn"",
                    ""type"": ""Button"",
                    ""id"": ""300af207-de9a-473e-afd4-8c0eaff89821"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""3d9619f9-26e1-432b-9ab7-f6a473fc4e0b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""interact"",
                    ""type"": ""Value"",
                    ""id"": ""b9832453-93ae-49a4-81d8-239235fd8ee3"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9b4e1a11-7496-4dca-b003-e4b9368beefe"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""spawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a84c907-e405-4132-86ee-b357a707aa91"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""spawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86f1eaf3-1dbf-4b79-8f34-4b38e23e4098"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53173255-d1a5-4eda-8868-91d7910971c6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be7a4ea3-57be-455d-8045-d8d34db7d9ce"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""505e658c-1845-4eba-ad6a-1efec289df18"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""82b45605-3479-42f7-bbf2-2ed3cce291dc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""62a49a07-77ff-44e4-b075-8a47851debc1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Ball
        m_Ball = asset.FindActionMap("Ball", throwIfNotFound: true);
        m_Ball_spawn = m_Ball.FindAction("spawn", throwIfNotFound: true);
        m_Ball_move = m_Ball.FindAction("move", throwIfNotFound: true);
        m_Ball_interact = m_Ball.FindAction("interact", throwIfNotFound: true);
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

    // Ball
    private readonly InputActionMap m_Ball;
    private IBallActions m_BallActionsCallbackInterface;
    private readonly InputAction m_Ball_spawn;
    private readonly InputAction m_Ball_move;
    private readonly InputAction m_Ball_interact;
    public struct BallActions
    {
        private @Controls m_Wrapper;
        public BallActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @spawn => m_Wrapper.m_Ball_spawn;
        public InputAction @move => m_Wrapper.m_Ball_move;
        public InputAction @interact => m_Wrapper.m_Ball_interact;
        public InputActionMap Get() { return m_Wrapper.m_Ball; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BallActions set) { return set.Get(); }
        public void SetCallbacks(IBallActions instance)
        {
            if (m_Wrapper.m_BallActionsCallbackInterface != null)
            {
                @spawn.started -= m_Wrapper.m_BallActionsCallbackInterface.OnSpawn;
                @spawn.performed -= m_Wrapper.m_BallActionsCallbackInterface.OnSpawn;
                @spawn.canceled -= m_Wrapper.m_BallActionsCallbackInterface.OnSpawn;
                @move.started -= m_Wrapper.m_BallActionsCallbackInterface.OnMove;
                @move.performed -= m_Wrapper.m_BallActionsCallbackInterface.OnMove;
                @move.canceled -= m_Wrapper.m_BallActionsCallbackInterface.OnMove;
                @interact.started -= m_Wrapper.m_BallActionsCallbackInterface.OnInteract;
                @interact.performed -= m_Wrapper.m_BallActionsCallbackInterface.OnInteract;
                @interact.canceled -= m_Wrapper.m_BallActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_BallActionsCallbackInterface = instance;
            if (instance != null)
            {
                @spawn.started += instance.OnSpawn;
                @spawn.performed += instance.OnSpawn;
                @spawn.canceled += instance.OnSpawn;
                @move.started += instance.OnMove;
                @move.performed += instance.OnMove;
                @move.canceled += instance.OnMove;
                @interact.started += instance.OnInteract;
                @interact.performed += instance.OnInteract;
                @interact.canceled += instance.OnInteract;
            }
        }
    }
    public BallActions @Ball => new BallActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    private int m_XRSchemeIndex = -1;
    public InputControlScheme XRScheme
    {
        get
        {
            if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
            return asset.controlSchemes[m_XRSchemeIndex];
        }
    }
    public interface IBallActions
    {
        void OnSpawn(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}
