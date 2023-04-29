using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Camera _camera;

    public float movementSpeed = 10f;

    private void Start()
    {
        _camera = Camera.main;
        characterController = GetComponent<CharacterController>();
    }


    private void Update()
    {

        Vector3 move = _camera.transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        characterController.SimpleMove(move.normalized * movementSpeed);
    }
}
