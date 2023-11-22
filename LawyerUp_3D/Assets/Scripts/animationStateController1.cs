using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator animator;
    private int isWalkingHash;
    private int isRunningHash;
    private CharacterController characterController;

    // Enum for character states
    private enum CharacterState { Idle, Walking, Running };
    private CharacterState characterState = CharacterState.Running;

    // Constants for rotation values
    private const float ROTATION_SPEED = 10f;
    private const float TARGET_ROTATION_DEGREES = 90f;
    private const float WALKING_SPEED = 3f;
    private const float RUNNING_SPEED = 5f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool bottomPressed = Input.GetKey(KeyCode.S);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool runPressed = Input.GetKey("left shift");

        Quaternion currentRotation = transform.rotation;
        float rotationStep = ROTATION_SPEED * Time.deltaTime;

        float currentSpeed = runPressed ? RUNNING_SPEED : WALKING_SPEED;

        if (forwardPressed || leftPressed || rightPressed || bottomPressed)
        {
            // Player is moving
            if (characterState != CharacterState.Walking)
            {
                SetCharacterState(CharacterState.Walking);
            }

            Quaternion targetRotation = Quaternion.Euler(0f, GetTargetRotationAngle(), 0f);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationStep);

            // Move the character forward based on its rotation
            Vector3 movementDirection = transform.forward * currentSpeed;
            characterController.Move(movementDirection * Time.deltaTime);
        }
        else
        {
            // Player is not moving
            if (characterState == CharacterState.Walking)
            {
                SetCharacterState(CharacterState.Idle);
            }
        }

        // Handle running state
        if ((forwardPressed && runPressed)|| (leftPressed && runPressed) || (rightPressed && runPressed) || (bottomPressed && runPressed))
        {
            SetCharacterState(CharacterState.Running);
        }
        else if (characterState == CharacterState.Running)
        {
            SetCharacterState(CharacterState.Walking);
        }
    }

    private float GetTargetRotationAngle()
    {
        float targetRotationAngle = 0f;

        if (Input.GetKey(KeyCode.W))
            targetRotationAngle = 0f;
        else if (Input.GetKey(KeyCode.A))
            targetRotationAngle = 270f;
        else if (Input.GetKey(KeyCode.D))
            targetRotationAngle = 90f;
        else if (Input.GetKey(KeyCode.S))
            targetRotationAngle = 180f;

        return targetRotationAngle;
    }

    private void SetCharacterState(CharacterState newState)
    {
        switch (newState)
        {
            case CharacterState.Idle:
                animator.SetBool(isWalkingHash, false);
                animator.SetBool(isRunningHash, false);
                break;
            case CharacterState.Walking:
                animator.SetBool(isWalkingHash, true);
                animator.SetBool(isRunningHash, false);
                break;
            case CharacterState.Running:
                animator.SetBool(isWalkingHash, true);
                animator.SetBool(isRunningHash, true);
                break;
        }

        characterState = newState;
    }
}
