// GENERATED AUTOMATICALLY FROM 'Assets/Settings/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""playerControls"",
            ""id"": ""32f525de-626f-4219-85e5-56bf242f28c0"",
            ""actions"": [
                {
                    ""name"": ""xMovment"",
                    ""type"": ""Button"",
                    ""id"": ""c65a4c43-5eca-4ccf-979f-82630a38c815"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""zMovement"",
                    ""type"": ""Button"",
                    ""id"": ""ccfe10bf-44b5-4172-b7c7-7e161cb42cbd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""jump"",
                    ""type"": ""Button"",
                    ""id"": ""136f6c20-9eea-4413-a0b1-d7c638243d73"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""fireLeft"",
                    ""type"": ""Button"",
                    ""id"": ""4cc0edae-f368-42ea-9d9f-990838a84bf2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""fireRight"",
                    ""type"": ""Button"",
                    ""id"": ""37cfb968-a034-44ec-b7c9-58a0f7ac879b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""kick"",
                    ""type"": ""Button"",
                    ""id"": ""203eca01-ac6a-49fa-943f-6561660c172a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""ReloadLevel"",
                    ""type"": ""Button"",
                    ""id"": ""07428a98-4242-4518-8c08-bc6a02905da1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""loadMenu"",
                    ""type"": ""Button"",
                    ""id"": ""ad3ff34f-009c-4175-9b21-b3819dd7efae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""pickLeft"",
                    ""type"": ""Button"",
                    ""id"": ""d8f7f8e0-aca8-421a-a1af-6bf61017faf1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""pickRight"",
                    ""type"": ""Button"",
                    ""id"": ""f46b15f6-e986-4532-a1ea-eee58b365e00"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""KeyBoard"",
                    ""id"": ""a4e0a4e2-2669-4323-928a-4a1e468704d7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""xMovment"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b6d98fa8-8882-4ca0-9c2e-b626a413aedc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""xMovment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e0df8129-7e05-4160-a197-7c1c91bd4ae0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""xMovment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""KeyBoard"",
                    ""id"": ""f62a0260-d9b9-44e5-b8b7-692ffb0c34b6"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""zMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3c5336b5-e7f9-4c30-9e7a-8d0e7561e8e3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""zMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""dab9e2a7-c6a1-4a6a-a30f-a40312e69c9a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""zMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d3aefa44-2902-416f-a553-bd9d4dc71958"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6bc491cc-7add-484f-b349-cb94e141c033"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""fireLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""815020ba-5c74-45f4-9356-f233ec18e443"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""fireRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07cd8431-9d35-41af-95ce-ee21dd4f1319"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""kick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b22dcf0-28b8-4b36-adaa-91fa63fb16f3"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReloadLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c3ccb60-df54-4f80-be61-b4bbd12595ff"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""loadMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7509e0b2-3481-4236-ba6d-cc04c59ea251"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""pickLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d80b788-aef7-46a1-94dd-bd84ff71293c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""pickRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // playerControls
        m_playerControls = asset.FindActionMap("playerControls", throwIfNotFound: true);
        m_playerControls_xMovment = m_playerControls.FindAction("xMovment", throwIfNotFound: true);
        m_playerControls_zMovement = m_playerControls.FindAction("zMovement", throwIfNotFound: true);
        m_playerControls_jump = m_playerControls.FindAction("jump", throwIfNotFound: true);
        m_playerControls_fireLeft = m_playerControls.FindAction("fireLeft", throwIfNotFound: true);
        m_playerControls_fireRight = m_playerControls.FindAction("fireRight", throwIfNotFound: true);
        m_playerControls_kick = m_playerControls.FindAction("kick", throwIfNotFound: true);
        m_playerControls_ReloadLevel = m_playerControls.FindAction("ReloadLevel", throwIfNotFound: true);
        m_playerControls_loadMenu = m_playerControls.FindAction("loadMenu", throwIfNotFound: true);
        m_playerControls_pickLeft = m_playerControls.FindAction("pickLeft", throwIfNotFound: true);
        m_playerControls_pickRight = m_playerControls.FindAction("pickRight", throwIfNotFound: true);
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

    // playerControls
    private readonly InputActionMap m_playerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_playerControls_xMovment;
    private readonly InputAction m_playerControls_zMovement;
    private readonly InputAction m_playerControls_jump;
    private readonly InputAction m_playerControls_fireLeft;
    private readonly InputAction m_playerControls_fireRight;
    private readonly InputAction m_playerControls_kick;
    private readonly InputAction m_playerControls_ReloadLevel;
    private readonly InputAction m_playerControls_loadMenu;
    private readonly InputAction m_playerControls_pickLeft;
    private readonly InputAction m_playerControls_pickRight;
    public struct PlayerControlsActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerControlsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @xMovment => m_Wrapper.m_playerControls_xMovment;
        public InputAction @zMovement => m_Wrapper.m_playerControls_zMovement;
        public InputAction @jump => m_Wrapper.m_playerControls_jump;
        public InputAction @fireLeft => m_Wrapper.m_playerControls_fireLeft;
        public InputAction @fireRight => m_Wrapper.m_playerControls_fireRight;
        public InputAction @kick => m_Wrapper.m_playerControls_kick;
        public InputAction @ReloadLevel => m_Wrapper.m_playerControls_ReloadLevel;
        public InputAction @loadMenu => m_Wrapper.m_playerControls_loadMenu;
        public InputAction @pickLeft => m_Wrapper.m_playerControls_pickLeft;
        public InputAction @pickRight => m_Wrapper.m_playerControls_pickRight;
        public InputActionMap Get() { return m_Wrapper.m_playerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @xMovment.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnXMovment;
                @xMovment.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnXMovment;
                @xMovment.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnXMovment;
                @zMovement.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnZMovement;
                @zMovement.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnZMovement;
                @zMovement.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnZMovement;
                @jump.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @jump.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @jump.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @fireLeft.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnFireLeft;
                @fireLeft.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnFireLeft;
                @fireLeft.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnFireLeft;
                @fireRight.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnFireRight;
                @fireRight.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnFireRight;
                @fireRight.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnFireRight;
                @kick.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnKick;
                @kick.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnKick;
                @kick.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnKick;
                @ReloadLevel.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnReloadLevel;
                @ReloadLevel.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnReloadLevel;
                @ReloadLevel.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnReloadLevel;
                @loadMenu.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLoadMenu;
                @loadMenu.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLoadMenu;
                @loadMenu.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLoadMenu;
                @pickLeft.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPickLeft;
                @pickLeft.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPickLeft;
                @pickLeft.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPickLeft;
                @pickRight.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPickRight;
                @pickRight.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPickRight;
                @pickRight.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPickRight;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @xMovment.started += instance.OnXMovment;
                @xMovment.performed += instance.OnXMovment;
                @xMovment.canceled += instance.OnXMovment;
                @zMovement.started += instance.OnZMovement;
                @zMovement.performed += instance.OnZMovement;
                @zMovement.canceled += instance.OnZMovement;
                @jump.started += instance.OnJump;
                @jump.performed += instance.OnJump;
                @jump.canceled += instance.OnJump;
                @fireLeft.started += instance.OnFireLeft;
                @fireLeft.performed += instance.OnFireLeft;
                @fireLeft.canceled += instance.OnFireLeft;
                @fireRight.started += instance.OnFireRight;
                @fireRight.performed += instance.OnFireRight;
                @fireRight.canceled += instance.OnFireRight;
                @kick.started += instance.OnKick;
                @kick.performed += instance.OnKick;
                @kick.canceled += instance.OnKick;
                @ReloadLevel.started += instance.OnReloadLevel;
                @ReloadLevel.performed += instance.OnReloadLevel;
                @ReloadLevel.canceled += instance.OnReloadLevel;
                @loadMenu.started += instance.OnLoadMenu;
                @loadMenu.performed += instance.OnLoadMenu;
                @loadMenu.canceled += instance.OnLoadMenu;
                @pickLeft.started += instance.OnPickLeft;
                @pickLeft.performed += instance.OnPickLeft;
                @pickLeft.canceled += instance.OnPickLeft;
                @pickRight.started += instance.OnPickRight;
                @pickRight.performed += instance.OnPickRight;
                @pickRight.canceled += instance.OnPickRight;
            }
        }
    }
    public PlayerControlsActions @playerControls => new PlayerControlsActions(this);
    public interface IPlayerControlsActions
    {
        void OnXMovment(InputAction.CallbackContext context);
        void OnZMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnFireLeft(InputAction.CallbackContext context);
        void OnFireRight(InputAction.CallbackContext context);
        void OnKick(InputAction.CallbackContext context);
        void OnReloadLevel(InputAction.CallbackContext context);
        void OnLoadMenu(InputAction.CallbackContext context);
        void OnPickLeft(InputAction.CallbackContext context);
        void OnPickRight(InputAction.CallbackContext context);
    }
}
