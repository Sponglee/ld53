using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelTilter : MonoBehaviour
{
    public float dampeningValue = 0.5f;

    public PlayerController playerController;

    void Update()
    {
        if (playerController.IsGrounded) return;

        transform.rotation = Quaternion.Lerp(transform.rotation, playerController.upPivot.rotation, dampeningValue);
    }
}
