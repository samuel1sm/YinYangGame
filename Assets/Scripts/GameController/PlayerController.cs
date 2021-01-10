// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/GameController/PlayerController.inputactions'

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
            ""name"": ""Abilities"",
            ""id"": ""7f09fec7-22e4-47e7-a89a-6ebd0c450d86"",
            ""actions"": [
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
                },
                {
                    ""name"": ""SpiritForm"",
                    ""type"": ""Button"",
                    ""id"": ""80ca343f-33c7-477a-988c-0aed23bcc356"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""10100f95-28f0-45a7-9820-acdc21a37ee7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
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
                },
                {
                    ""name"": """",
                    ""id"": ""b88dcaa6-3f22-454f-87d7-34e202cb246c"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttractionRepution"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40244fe9-56d8-4327-8e47-db94a8ac8c0a"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpiritForm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56a98be0-6d45-4c63-a9d5-ea6f5f13011a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Terrain"",
            ""id"": ""b07120b8-5841-4547-90a6-7c403ca04103"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""5144dc2e-8a4e-4471-ba57-9eeeb4d5d7f6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""e5c88a95-3b90-41ff-9a8b-35e3c6ba3d00"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""16ce5b1f-253d-4adc-a1ce-89e3573b8a8f"",
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
                    ""id"": ""d32c66c2-8c86-4c36-a794-dedc5638bad1"",
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
                    ""id"": ""abcf5305-f772-4e40-9051-d3262bf841d2"",
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
                    ""id"": ""59102c20-17d2-4260-b672-3226193f2790"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Air"",
            ""id"": ""b7a0126d-3db3-4716-844b-92d24cc4121f"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""0c18dd6b-2c1c-499f-9f06-c94a54122b9b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""8ad56b6a-16c2-419d-9e94-88e7a1a36596"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""764090d6-871d-4d71-8565-e3cac6bc8da7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""98a5ab8a-0180-4169-a9dd-2b4fbe969637"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7f3dd9d8-ba7a-4d97-a822-57370f146912"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ece52cc9-4b9f-4246-abc1-c771e31ff873"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""MenuController"",
            ""id"": ""b40207a5-7930-4f67-a292-643693021105"",
            ""actions"": [
                {
                    ""name"": ""OpenMenu"",
                    ""type"": ""Button"",
                    ""id"": ""ca15796a-f00e-469d-9d7c-619560bf83e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""54200181-14ed-4598-bacb-f8acc5af2e21"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Abilities
        m_Abilities = asset.FindActionMap("Abilities", throwIfNotFound: true);
        m_Abilities_ChangeTypeYin = m_Abilities.FindAction("ChangeTypeYin", throwIfNotFound: true);
        m_Abilities_ChangeTypeYang = m_Abilities.FindAction("ChangeTypeYang", throwIfNotFound: true);
        m_Abilities_AttractionRepution = m_Abilities.FindAction("AttractionRepution", throwIfNotFound: true);
        m_Abilities_SpiritForm = m_Abilities.FindAction("SpiritForm", throwIfNotFound: true);
        m_Abilities_Interact = m_Abilities.FindAction("Interact", throwIfNotFound: true);
        // Terrain
        m_Terrain = asset.FindActionMap("Terrain", throwIfNotFound: true);
        m_Terrain_Movement = m_Terrain.FindAction("Movement", throwIfNotFound: true);
        m_Terrain_Jump = m_Terrain.FindAction("Jump", throwIfNotFound: true);
        // Air
        m_Air = asset.FindActionMap("Air", throwIfNotFound: true);
        m_Air_Movement = m_Air.FindAction("Movement", throwIfNotFound: true);
        // MenuController
        m_MenuController = asset.FindActionMap("MenuController", throwIfNotFound: true);
        m_MenuController_OpenMenu = m_MenuController.FindAction("OpenMenu", throwIfNotFound: true);
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

    // Abilities
    private readonly InputActionMap m_Abilities;
    private IAbilitiesActions m_AbilitiesActionsCallbackInterface;
    private readonly InputAction m_Abilities_ChangeTypeYin;
    private readonly InputAction m_Abilities_ChangeTypeYang;
    private readonly InputAction m_Abilities_AttractionRepution;
    private readonly InputAction m_Abilities_SpiritForm;
    private readonly InputAction m_Abilities_Interact;
    public struct AbilitiesActions
    {
        private @PlayerController m_Wrapper;
        public AbilitiesActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @ChangeTypeYin => m_Wrapper.m_Abilities_ChangeTypeYin;
        public InputAction @ChangeTypeYang => m_Wrapper.m_Abilities_ChangeTypeYang;
        public InputAction @AttractionRepution => m_Wrapper.m_Abilities_AttractionRepution;
        public InputAction @SpiritForm => m_Wrapper.m_Abilities_SpiritForm;
        public InputAction @Interact => m_Wrapper.m_Abilities_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Abilities; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AbilitiesActions set) { return set.Get(); }
        public void SetCallbacks(IAbilitiesActions instance)
        {
            if (m_Wrapper.m_AbilitiesActionsCallbackInterface != null)
            {
                @ChangeTypeYin.started -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnChangeTypeYin;
                @ChangeTypeYin.performed -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnChangeTypeYin;
                @ChangeTypeYin.canceled -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnChangeTypeYin;
                @ChangeTypeYang.started -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnChangeTypeYang;
                @ChangeTypeYang.performed -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnChangeTypeYang;
                @ChangeTypeYang.canceled -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnChangeTypeYang;
                @AttractionRepution.started -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnAttractionRepution;
                @AttractionRepution.performed -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnAttractionRepution;
                @AttractionRepution.canceled -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnAttractionRepution;
                @SpiritForm.started -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnSpiritForm;
                @SpiritForm.performed -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnSpiritForm;
                @SpiritForm.canceled -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnSpiritForm;
                @Interact.started -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_AbilitiesActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ChangeTypeYin.started += instance.OnChangeTypeYin;
                @ChangeTypeYin.performed += instance.OnChangeTypeYin;
                @ChangeTypeYin.canceled += instance.OnChangeTypeYin;
                @ChangeTypeYang.started += instance.OnChangeTypeYang;
                @ChangeTypeYang.performed += instance.OnChangeTypeYang;
                @ChangeTypeYang.canceled += instance.OnChangeTypeYang;
                @AttractionRepution.started += instance.OnAttractionRepution;
                @AttractionRepution.performed += instance.OnAttractionRepution;
                @AttractionRepution.canceled += instance.OnAttractionRepution;
                @SpiritForm.started += instance.OnSpiritForm;
                @SpiritForm.performed += instance.OnSpiritForm;
                @SpiritForm.canceled += instance.OnSpiritForm;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public AbilitiesActions @Abilities => new AbilitiesActions(this);

    // Terrain
    private readonly InputActionMap m_Terrain;
    private ITerrainActions m_TerrainActionsCallbackInterface;
    private readonly InputAction m_Terrain_Movement;
    private readonly InputAction m_Terrain_Jump;
    public struct TerrainActions
    {
        private @PlayerController m_Wrapper;
        public TerrainActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Terrain_Movement;
        public InputAction @Jump => m_Wrapper.m_Terrain_Jump;
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
            }
        }
    }
    public TerrainActions @Terrain => new TerrainActions(this);

    // Air
    private readonly InputActionMap m_Air;
    private IAirActions m_AirActionsCallbackInterface;
    private readonly InputAction m_Air_Movement;
    public struct AirActions
    {
        private @PlayerController m_Wrapper;
        public AirActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Air_Movement;
        public InputActionMap Get() { return m_Wrapper.m_Air; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AirActions set) { return set.Get(); }
        public void SetCallbacks(IAirActions instance)
        {
            if (m_Wrapper.m_AirActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_AirActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_AirActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_AirActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_AirActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public AirActions @Air => new AirActions(this);

    // MenuController
    private readonly InputActionMap m_MenuController;
    private IMenuControllerActions m_MenuControllerActionsCallbackInterface;
    private readonly InputAction m_MenuController_OpenMenu;
    public struct MenuControllerActions
    {
        private @PlayerController m_Wrapper;
        public MenuControllerActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @OpenMenu => m_Wrapper.m_MenuController_OpenMenu;
        public InputActionMap Get() { return m_Wrapper.m_MenuController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuControllerActions set) { return set.Get(); }
        public void SetCallbacks(IMenuControllerActions instance)
        {
            if (m_Wrapper.m_MenuControllerActionsCallbackInterface != null)
            {
                @OpenMenu.started -= m_Wrapper.m_MenuControllerActionsCallbackInterface.OnOpenMenu;
                @OpenMenu.performed -= m_Wrapper.m_MenuControllerActionsCallbackInterface.OnOpenMenu;
                @OpenMenu.canceled -= m_Wrapper.m_MenuControllerActionsCallbackInterface.OnOpenMenu;
            }
            m_Wrapper.m_MenuControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @OpenMenu.started += instance.OnOpenMenu;
                @OpenMenu.performed += instance.OnOpenMenu;
                @OpenMenu.canceled += instance.OnOpenMenu;
            }
        }
    }
    public MenuControllerActions @MenuController => new MenuControllerActions(this);
    public interface IAbilitiesActions
    {
        void OnChangeTypeYin(InputAction.CallbackContext context);
        void OnChangeTypeYang(InputAction.CallbackContext context);
        void OnAttractionRepution(InputAction.CallbackContext context);
        void OnSpiritForm(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface ITerrainActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IAirActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
    public interface IMenuControllerActions
    {
        void OnOpenMenu(InputAction.CallbackContext context);
    }
}
