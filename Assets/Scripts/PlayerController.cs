using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Camera _camera;

    public float movementSpeed = 10f;
    public float rotationSpeed = 10f;

    public bool IsGrounded = false;

    private void Start()
    {
        _camera = Camera.main;
        characterController = GetComponent<CharacterController>();
    }


    private void Update()
    {

        Vector3 move = _camera.transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        move = Vector3.Scale(move, new Vector3(1, 0, 1));

        if (move.magnitude >= 0.1f)
        {
            characterController.Move(move.normalized * movementSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move, Vector3.up), rotationSpeed * Time.deltaTime);
        }
        else
        {
            characterController.Move(Vector3.down * 0.005f);
        }


        IsGrounded = characterController.isGrounded;
    }
}
