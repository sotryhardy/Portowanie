using RoboRyanTron.Unite2017.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] InputActionReference jumpActionl;
    [SerializeField] InputActionReference movementArction;
    [SerializeField] InputActionReference sprintAction;

    public static PlayerController Instance;

    [SerializeField] private FloatVariable HealthVariable;
    [SerializeField] private FloatVariable ManaVariable;
    [SerializeField] private FloatVariable StaminaVariable;

    private CharacterController characterController;

    [Header("Movmeent Settings")]
    [SerializeField] private float velocity = 5;
    [SerializeField] private float sprintModificator = 3;
    [SerializeField] private float staminaUse = 0.5f;
    [SerializeField] private LayerMask layerMask;

    [Header("Skill Settings")]
    [SerializeField] SkillSO JumpSkill;
    [SerializeField] SkillSO SprintSkill;

    private float yMovement = -9.81f;

    public Vector2 moveAxis;
    public bool isJumping;
    public bool isSprinting;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("There is more than one instance of this!", gameObject);

        Instance = this;
        characterController = GetComponent<CharacterController>();
        PlatformServices.PlatformUserStats.SetAchievement("playercontrolled");
    }

    private void Update()
    {
        var movementValue = moveAxis;

        if (SprintSkill.IsActive && isSprinting && StaminaVariable.Value > 0)
        {
            movementValue *= sprintModificator;
            StaminaVariable.Value -= staminaUse * Time.deltaTime;
        }
        else
        {
            StaminaVariable.Value += Time.fixedDeltaTime;
            StaminaVariable.Value = Mathf.Clamp01(StaminaVariable.Value);
        }

        movementValue *= velocity;
        movementValue *= Time.deltaTime;

        characterController.Move(new Vector3(movementValue.x, yMovement * Time.deltaTime, movementValue.y));
        if (characterController.velocity.sqrMagnitude > 0.1)
            transform.forward = new Vector3(movementValue.x, 0f, movementValue.y);

        if (JumpSkill.IsActive && isJumping && characterController.isGrounded)
            yMovement = 10f;

        yMovement = Mathf.Max(-9.81f, yMovement - Time.deltaTime * 30f);
    }

    private void OnEnable()
    {
        jumpActionl.action.Enable();
        movementArction.action.Enable();
        sprintAction.action.Enable();
    }

    private void OnDisable()
    {
        jumpActionl.action.Disable();
        movementArction.action.Disable();
        sprintAction.action.Disable();
    }

}
