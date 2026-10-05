using UnityEngine;
using UnityEngine.InputSystem;
using Unity.XR.CoreUtils;

[RequireComponent(typeof(XROrigin))]
public class JoystickLocomotion : MonoBehaviour
{
    [Header("Input System actions")]
    [Tooltip("Left stick (Vector2): forward/backward and strafe")]
    [SerializeField] private InputActionReference moveAction;
    [Tooltip("Right stick (Vector2): snap turn left/right")]
    [SerializeField] private InputActionReference turnAction;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 2f;

    [Header("Snap turn")]
    [Tooltip("Rotation per step (30 or 45 degrees)")]
    [SerializeField] private float snapAngle = 45f;
    [Range(0.1f, 1f)]
    [SerializeField] private float turnThreshold = 0.7f;

    private XROrigin origin;
    private CharacterController characterController;
    private bool canTurn = true;

    private void Awake()
    {
        origin = GetComponent<XROrigin>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        SnapTurn();
    }

    private void Move()
    {
        if (moveAction == null) return;

        Vector2 input = moveAction.action.ReadValue<Vector2>();
        if (input.sqrMagnitude < 0.01f) return;

        // Move relative to where the player is looking, on the horizontal plane
        Transform head = origin.Camera.transform;
        Vector3 forward = Vector3.ProjectOnPlane(head.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(head.right, Vector3.up).normalized;
        Vector3 motion = (forward * input.y + right * input.x) * moveSpeed * Time.deltaTime;

        if (characterController != null && characterController.enabled)
            characterController.Move(motion);
        else
            transform.position += motion;
    }

    private void SnapTurn()
    {
        if (turnAction == null) return;

        float x = turnAction.action.ReadValue<Vector2>().x;

        if (canTurn && Mathf.Abs(x) >= turnThreshold)
        {
            // Rotate around the player's head so they don't drift sideways
            origin.RotateAroundCameraUsingOriginUp(Mathf.Sign(x) * snapAngle);
            canTurn = false;   // wait for the stick to return before the next step
        }
        else if (Mathf.Abs(x) < 0.2f)
        {
            canTurn = true;
        }
    }
}
