// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Rocket"",
            ""id"": ""d8481030-8b70-43f6-8acb-93f07f0caa9b"",
            ""actions"": [
                {
                    ""name"": ""RocketRight"",
                    ""type"": ""PassThrough"",
                    ""id"": ""06925ff6-c41e-4266-a69a-22db2e133ee9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RocketLeft"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ba675cda-f0d5-4b9b-a176-be2f76394795"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reset"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b704349b-a28e-4944-a8c7-d9cf0dca15bf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2fe82222-4246-4fc2-b9e9-72d1cc694053"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RocketRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c0ca51f-f204-4972-a258-c69e328341a2"",
                    ""path"": ""<HID::Nintendo Wireless Gamepad>/button6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RocketRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64a90aeb-1eb3-4c38-aaab-485081e94167"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RocketLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3dff864b-fa11-493c-b772-e2c973581939"",
                    ""path"": ""<HID::Nintendo Wireless Gamepad>/button5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RocketLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""520f41d0-af81-4fb6-a371-d7426dff49f5"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Ball"",
            ""id"": ""d8a28251-6844-4196-a767-794dcb15d2ff"",
            ""actions"": [
                {
                    ""name"": ""action"",
                    ""type"": ""Button"",
                    ""id"": ""300af207-de9a-473e-afd4-8c0eaff89821"",
                    ""expectedControlType"": """",
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
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""33db511d-a222-42a8-bd20-16262cbe73d1"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""517999d8-6219-46ce-b220-a928e6dd589b"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
                    ""devicePath"": ""<Gamepad>"",
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
        // Rocket
        m_Rocket = asset.FindActionMap("Rocket", throwIfNotFound: true);
        m_Rocket_RocketRight = m_Rocket.FindAction("RocketRight", throwIfNotFound: true);
        m_Rocket_RocketLeft = m_Rocket.FindAction("RocketLeft", throwIfNotFound: true);
        m_Rocket_Reset = m_Rocket.FindAction("Reset", throwIfNotFound: true);
        // Ball
        m_Ball = asset.FindActionMap("Ball", throwIfNotFound: true);
        m_Ball_action = m_Ball.FindAction("action", throwIfNotFound: true);
        m_Ball_move = m_Ball.FindAction("move", throwIfNotFound: true);
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

    // Rocket
    private readonly InputActionMap m_Rocket;
    private IRocketActions m_RocketActionsCallbackInterface;
    private readonly InputAction m_Rocket_RocketRight;
    private readonly InputAction m_Rocket_RocketLeft;
    private readonly InputAction m_Rocket_Reset;
    public struct RocketActions
    {
        private @Controls m_Wrapper;
        public RocketActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @RocketRight => m_Wrapper.m_Rocket_RocketRight;
        public InputAction @RocketLeft => m_Wrapper.m_Rocket_RocketLeft;
        public InputAction @Reset => m_Wrapper.m_Rocket_Reset;
        public InputActionMap Get() { return m_Wrapper.m_Rocket; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RocketActions set) { return set.Get(); }
        public void SetCallbacks(IRocketActions instance)
        {
            if (m_Wrapper.m_RocketActionsCallbackInterface != null)
            {
                @RocketRight.started -= m_Wrapper.m_RocketActionsCallbackInterface.OnRocketRight;
                @RocketRight.performed -= m_Wrapper.m_RocketActionsCallbackInterface.OnRocketRight;
                @RocketRight.canceled -= m_Wrapper.m_RocketActionsCallbackInterface.OnRocketRight;
                @RocketLeft.started -= m_Wrapper.m_RocketActionsCallbackInterface.OnRocketLeft;
                @RocketLeft.performed -= m_Wrapper.m_RocketActionsCallbackInterface.OnRocketLeft;
                @RocketLeft.canceled -= m_Wrapper.m_RocketActionsCallbackInterface.OnRocketLeft;
                @Reset.started -= m_Wrapper.m_RocketActionsCallbackInterface.OnReset;
                @Reset.performed -= m_Wrapper.m_RocketActionsCallbackInterface.OnReset;
                @Reset.canceled -= m_Wrapper.m_RocketActionsCallbackInterface.OnReset;
            }
            m_Wrapper.m_RocketActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RocketRight.started += instance.OnRocketRight;
                @RocketRight.performed += instance.OnRocketRight;
                @RocketRight.canceled += instance.OnRocketRight;
                @RocketLeft.started += instance.OnRocketLeft;
                @RocketLeft.performed += instance.OnRocketLeft;
                @RocketLeft.canceled += instance.OnRocketLeft;
                @Reset.started += instance.OnReset;
                @Reset.performed += instance.OnReset;
                @Reset.canceled += instance.OnReset;
            }
        }
    }
    public RocketActions @Rocket => new RocketActions(this);

    // Ball
    private readonly InputActionMap m_Ball;
    private IBallActions m_BallActionsCallbackInterface;
    private readonly InputAction m_Ball_action;
    private readonly InputAction m_Ball_move;
    public struct BallActions
    {
        private @Controls m_Wrapper;
        public BallActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @action => m_Wrapper.m_Ball_action;
        public InputAction @move => m_Wrapper.m_Ball_move;
        public InputActionMap Get() { return m_Wrapper.m_Ball; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BallActions set) { return set.Get(); }
        public void SetCallbacks(IBallActions instance)
        {
            if (m_Wrapper.m_BallActionsCallbackInterface != null)
            {
                @action.started -= m_Wrapper.m_BallActionsCallbackInterface.OnAction;
                @action.performed -= m_Wrapper.m_BallActionsCallbackInterface.OnAction;
                @action.canceled -= m_Wrapper.m_BallActionsCallbackInterface.OnAction;
                @move.started -= m_Wrapper.m_BallActionsCallbackInterface.OnMove;
                @move.performed -= m_Wrapper.m_BallActionsCallbackInterface.OnMove;
                @move.canceled -= m_Wrapper.m_BallActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_BallActionsCallbackInterface = instance;
            if (instance != null)
            {
                @action.started += instance.OnAction;
                @action.performed += instance.OnAction;
                @action.canceled += instance.OnAction;
                @move.started += instance.OnMove;
                @move.performed += instance.OnMove;
                @move.canceled += instance.OnMove;
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
    public interface IRocketActions
    {
        void OnRocketRight(InputAction.CallbackContext context);
        void OnRocketLeft(InputAction.CallbackContext context);
        void OnReset(InputAction.CallbackContext context);
    }
    public interface IBallActions
    {
        void OnAction(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}
