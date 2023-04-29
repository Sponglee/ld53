using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Camera _camera;
    [Header("SETTINGS")]
    public float movementSpeed = 10f;
    public float rotationSpeed = 10f;
    public float jumpForce = 10f;
    public float maxStamina = 10f;
    public float staminaBurnRate = 10f;
    public float staminaRechargeRate = 20f;

    [Space]
    public float stamina = 0f;
    public bool IsGrounded = false;
    private bool isStaminaRecharging = false;
    private float verticalVelocity = 0.005f;
    private float fallTimer = 0f;


    public Animator characterAnimator;

    public bool IsStaminaRecharging
    {
        get => isStaminaRecharging; set
        {
            isStaminaRecharging = value;
        }
    }

    private void Start()
    {
        _camera = Camera.main;
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {

        Vector3 move = _camera.transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        move = Vector3.Scale(move, new Vector3(1, 0, 1));

        if (IsGrounded) fallTimer = 0f;
        else fallTimer += Time.deltaTime;

        verticalVelocity = IsGrounded ? -1f : Physics.gravity.y * Mathf.Sqrt(fallTimer);

        if (Input.GetKey(KeyCode.Space) && !IsStaminaRecharging)
        {
            fallTimer = 0f;
            fallTimer += Time.deltaTime;

            verticalVelocity = jumpForce * Mathf.Sqrt(fallTimer) - Physics.gravity.y * Mathf.Sqrt(fallTimer);

            stamina -= staminaBurnRate * Time.deltaTime;
            if (stamina <= 0)
            {
                IsStaminaRecharging = true;
            }

        }
        else
        {
            stamina = stamina += staminaBurnRate * Time.deltaTime;
            if (stamina >= maxStamina)
            {
                stamina = maxStamina;
                IsStaminaRecharging = false;
            }

        }

        if (move.magnitude >= 0.1f)
        {
            characterController.Move(move.normalized * movementSpeed * Time.deltaTime + Vector3.up * verticalVelocity * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move, Vector3.up), rotationSpeed * Time.deltaTime);
        }
        else
        {
            characterController.Move(Vector3.up * verticalVelocity * Time.deltaTime);
        }


        IsGrounded = characterController.isGrounded;

        characterAnimator.SetBool("IsFalling", (isStaminaRecharging && !IsGrounded));
    }
}
