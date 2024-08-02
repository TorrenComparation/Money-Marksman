using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private PlayerStatistic playerStatistic;
    [SerializeField] private Animator animator;

    private float rotationX;
    private float currentSpeedX;
    private float currentSpeedY;
    private float moveX;
    private float moveY;
    private float lastWalkSpeed;
    private float lastRunSpeed;
    private bool isRunning;

    private Vector3 direction = Vector3.zero;
    [HideInInspector] public bool canMove = true;


    private void Start()
    {
        lastRunSpeed = playerStatistic.runSpeed;
        lastWalkSpeed = playerStatistic.walkSpeed;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Walk();
        Jump();
        CameraFollowing();
    }

    private void Walk()
    {
        isRunning = Input.GetKey(KeyCode.LeftShift);
        moveX = Input.GetAxis("Vertical");
        moveY = Input.GetAxis("Horizontal");

        if (canMove == true)
        {
            if (isRunning == true)
            {
                CameraShake(2);
                currentSpeedX = playerStatistic.runSpeed * moveX;
                currentSpeedY = playerStatistic.runSpeed * moveY;

                if (moveY != 0 && moveX != 0)
                {
                    currentSpeedY = (playerStatistic.runSpeed / 1.4f) * moveY;
                    currentSpeedX = (playerStatistic.runSpeed / 1.4f) * moveX;
                }
            }
            else
            {
                CameraShake(1);
                currentSpeedX = playerStatistic.walkSpeed * moveX;
                currentSpeedY = playerStatistic.walkSpeed * moveY;

                if (moveY != 0 && moveX != 0)
                {
                    currentSpeedY = (playerStatistic.walkSpeed / 1.4f) * moveY;
                    currentSpeedX = (playerStatistic.walkSpeed / 1.4f) * moveX;
                }
            }
        }
        else
        {
            currentSpeedY = 0;
            currentSpeedX = 0;
        }
        Crouch();
    }
    private void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl) && canMove == true)
        {
            CameraShake(3);
            characterController.height = playerStatistic.crouchHeigth;
            playerStatistic.walkSpeed = playerStatistic.crouchSpeed;
            playerStatistic.runSpeed = playerStatistic.crouchSpeed;
        }
        else
        {

            characterController.height = playerStatistic.defaultHeight;
            playerStatistic.walkSpeed = lastWalkSpeed;
            playerStatistic.runSpeed = lastRunSpeed;
        }
    }

    private void CameraFollowing()
    {
        if (canMove == true)
        {
            rotationX += Input.GetAxis("Mouse Y") * playerStatistic.lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -playerStatistic.lookXLimit, playerStatistic.lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(-rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * playerStatistic.lookSpeed, 0);
        }
    }
    public void CameraShake(int index)
    {

        if (canMove)
        {
            if (moveY != 0 || moveX != 0)
            {
                animator.SetInteger("TypeOfShacking", index);
            }
            else
            {
                animator.SetInteger("TypeOfShacking", 0);
            }
        }
        else
        {
            animator.SetInteger("TypeOfShacking", 0);
        }

    }
    private void Jump()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float movementDirectionY = direction.y;

        direction = (forward * currentSpeedX) + (right * currentSpeedY);

        if (Input.GetKey(KeyCode.Space) && canMove == true && characterController.isGrounded == true)
        {
            direction.y = playerStatistic.jumpForce;
        }
        else
        {
            direction.y = movementDirectionY;


        }
        if (characterController.isGrounded == false)
        {
            direction.y -= playerStatistic.gravity * Time.deltaTime;
        }

        characterController.Move(direction * Time.deltaTime);

    }


}
