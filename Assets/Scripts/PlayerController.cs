// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""Terrain"",
            ""id"": ""7f09fec7-22e4-47e7-a89a-6ebd0c450d86"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""0e88cd6e-570f-4308-b10e-1423b3412af5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""b6848e19-f7d6-4b5f-bd26-1e455eac5137"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeTypeYin"",
                    ""type"": ""Button"",
                    ""id"": ""54b81d76-c64b-4e4c-b664-55e1a581f0e8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeTypeYang"",
                    ""type"": ""Button"",
                    ""id"": ""5f837f0a-7403-4b7c-ad2c-4d0176ef1883"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AttractionRepution"",
                    ""type"": ""Button"",
                    ""id"": ""5e560d73-de30-4a8e-880a-6f8f65a8b05f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""e2839610-a229-43a2-8775-782cb9aa5a5e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""703b9942-b882-4c51-a568-e23feed774da"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""11eccfc5-05f3-4e1f-8d60-3c3371249f0b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9da63dbd-c24f-4355-b74d-9e8db2feb068"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4944dab5-7f73-4adc-a8ac-a2bd54203a0a"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeTypeYin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47001f5d-08d0-41e3-8884-5964c2117826"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeTypeYang"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd98318d-d81d-40b0-8c1b-c6e5a885817b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttractionRepution"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Terrain
        m_Terrain = asset.FindActionMap("Terrain", throwIfNotFound: true);
        m_Terrain_Movement = m_Terrain.FindAction("Movement", throwIfNotFound: true);
        m_Terrain_Jump = m_Terrain.FindAction("Jump", throwIfNotFound: true);
        m_Terrain_ChangeTypeYin = m_Terrain.FindAction("ChangeTypeYin", throwIfNotFound: true);
        m_Terrain_ChangeTypeYang = m_Terrain.FindAction("ChangeTypeYang", throwIfNotFound: true);
        m_Terrain_AttractionRepution = m_Terrain.FindAction("AttractionRepution", throwIfNotFound: true);
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

    // Terrain
    private readonly InputActionMap m_Terrain;
    private ITerrainActions m_TerrainActionsCallbackInterface;
    private readonly InputAction m_Terrain_Movement;
    private readonly InputAction m_Terrain_Jump;
    private readonly InputAction m_Terrain_ChangeTypeYin;
    private readonly InputAction m_Terrain_ChangeTypeYang;
    private readonly InputAction m_Terrain_AttractionRepution;
    public struct TerrainActions
    {
        private @PlayerController m_Wrapper;
        public TerrainActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Terrain_Movement;
        public InputAction @Jump => m_Wrapper.m_Terrain_Jump;
        public InputAction @ChangeTypeYin => m_Wrapper.m_Terrain_ChangeTypeYin;
        public InputAction @ChangeTypeYang => m_Wrapper.m_Terrain_ChangeTypeYang;
        public InputAction @AttractionRepution => m_Wrapper.m_Terrain_AttractionRepution;
        public InputActionMap Get() { return m_Wrapper.m_Terrain; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TerrainActions set) { return set.Get(); }
        public void SetCallbacks(ITerrainActions instance)
        {
            if (m_Wrapper.m_TerrainActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_TerrainActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_TerrainActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_TerrainActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_TerrainActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_TerrainActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_TerrainActionsCallbackInterface.OnJump;
                @ChangeTypeYin.started -= m_Wrapper.m_TerrainActionsCallbackInterface.OnChangeTypeYin;
                @ChangeTypeYin.performed -= m_Wrapper.m_TerrainActionsCallbackInterface.OnChangeTypeYin;
                @ChangeTypeYin.canceled -= m_Wrapper.m_TerrainActionsCallbackInterface.OnChangeTypeYin;
                @ChangeTypeYang.started -= m_Wrapper.m_TerrainActionsCallbackInterface.OnChangeTypeYang;
                @ChangeTypeYang.performed -= m_Wrapper.m_TerrainActionsCallbackInterface.OnChangeTypeYang;
                @ChangeTypeYang.canceled -= m_Wrapper.m_TerrainActionsCallbackInterface.OnChangeTypeYang;
                @AttractionRepution.started -= m_Wrapper.m_TerrainActionsCallbackInterface.OnAttractionRepution;
                @AttractionRepution.performed -= m_Wrapper.m_TerrainActionsCallbackInterface.OnAttractionRepution;
                @AttractionRepution.canceled -= m_Wrapper.m_TerrainActionsCallbackInterface.OnAttractionRepution;
            }
            m_Wrapper.m_TerrainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @ChangeTypeYin.started += instance.OnChangeTypeYin;
                @ChangeTypeYin.performed += instance.OnChangeTypeYin;
                @ChangeTypeYin.canceled += instance.OnChangeTypeYin;
                @ChangeTypeYang.started += instance.OnChangeTypeYang;
                @ChangeTypeYang.performed += instance.OnChangeTypeYang;
                @ChangeTypeYang.canceled += instance.OnChangeTypeYang;
                @AttractionRepution.started += instance.OnAttractionRepution;
                @AttractionRepution.performed += instance.OnAttractionRepution;
                @AttractionRepution.canceled += instance.OnAttractionRepution;
            }
        }
    }
    public TerrainActions @Terrain => new TerrainActions(this);
    public interface ITerrainActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnChangeTypeYin(InputAction.CallbackContext context);
        void OnChangeTypeYang(InputAction.CallbackContext context);
        void OnAttractionRepution(InputAction.CallbackContext context);
    }
}
