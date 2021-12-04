using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.InputSystem;
using DG.Tweening;
using System.Collections;

public enum GroundType
{
    None,
    Soft,
    Hard
}

public class CharacterController2D : MonoBehaviour
{
    readonly Vector3 flippedScale = new Vector3(-1, 1, 1);
    readonly Quaternion flippedRotation = new Quaternion(0, 0, 1, 0);


    [SerializeField] Test environmentController = null;

    [SerializeField] int acceleration;
    [SerializeField] int maxSpeed;
    private Rigidbody2D controllerRigidbody;
    private Collider2D controllerCollider;
    private LayerMask softGroundMask;
    private LayerMask hardGroundMask;
    private Camera mainCamera;

    private Vector2 movementInput;
    private bool jumpInput;

    private Vector2 prevVelocity;
    private GroundType groundType;

    [SerializeField] bool isCastingMagic = false;





    public bool CanMove { get; set; }

    void Start()
    {
        mainCamera = Camera.main;

        controllerCollider = GetComponent<Collider2D>();
        softGroundMask = LayerMask.GetMask("Ground Soft");
        hardGroundMask = LayerMask.GetMask("Ground Hard");
        controllerRigidbody = GetComponent<Rigidbody2D>();


        CanMove = true;


    }

    void Update()
    {
        var keyboard = Keyboard.current;
        var mouse = Mouse.current;

        if (!CanMove || keyboard == null)
            return;

        // Horizontal movement
        float moveHorizontal = 0.0f;

        if (keyboard.leftArrowKey.isPressed || keyboard.aKey.isPressed)
            moveHorizontal = -1.0f;
        else if (keyboard.rightArrowKey.isPressed || keyboard.dKey.isPressed)
            moveHorizontal = 1.0f;

        movementInput = new Vector2(moveHorizontal, 0);



        Vector3 screenPos = mainCamera.ScreenToWorldPoint(mouse.position.ReadValue());






       // if (mouse.rightButton.wasPressedThisFrame)
        //{
          //  environmentController.AddPoint(screenPos);
           // if (environmentController.canUse)
           //     WandAnimation();

        //}

    }

    Sequence WandAnimation()
    {
        isCastingMagic = true;

        Sequence s = DOTween.Sequence();

        s.AppendCallback(() => isCastingMagic = false);
        return s;
    }

    void FixedUpdate()
    {
        UpdateGrounding();
        UpdateVelocity();
      
        UpdateJump();
      

        prevVelocity = controllerRigidbody.velocity;
    }

    private void UpdateGrounding()
    {
        // Use character collider to check if touching ground layers
        if (controllerCollider.IsTouchingLayers(softGroundMask))
            groundType = GroundType.Soft;
        else if (controllerCollider.IsTouchingLayers(hardGroundMask))
            groundType = GroundType.Hard;
        else
            groundType = GroundType.None;

        // Update animator

    }

    private void UpdateVelocity()
    {
        Vector2 velocity = controllerRigidbody.velocity;

        // Apply acceleration directly as we'll want to clamp
        // prior to assigning back to the body.
        velocity += movementInput * acceleration * Time.fixedDeltaTime;

        // We've consumed the movement, reset it.
        movementInput = Vector2.zero;

        // Clamp horizontal speed.
        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);

        // Assign back to the body.
        controllerRigidbody.velocity = velocity;

        // Update animator running speed
        var horizontalSpeedNormalized = Mathf.Abs(velocity.x) / maxSpeed;

        // Play audio
    }

    private void UpdateJump()
    {
        // Set falling flag


        // Jump
        if (jumpInput && groundType != GroundType.None)
        {
            // Jump using impulse force


            // Set animator

            // We've consumed the jump, reset it.
            jumpInput = false;

            // Set jumping flag


            // Play audio
        }

        // Landed

    }
  


}
