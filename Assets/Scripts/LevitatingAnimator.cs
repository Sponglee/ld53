using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitatingAnimator : MonoBehaviour
{
    public PlayerController playerController;

    public float period;
    public Vector2 verticalOffset;

    private float timer = 0f;

    private bool reverse = false;
    void Update()
    {
        if (playerController.IsGrounded)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, verticalOffset.y, transform.localPosition.z);
            return;
        }
        transform.localPosition = Vector3.Lerp(new Vector3(transform.localPosition.x, verticalOffset.x, transform.localPosition.z),
                                                new Vector3(transform.localPosition.x, verticalOffset.y, transform.localPosition.z), timer / period);

        timer = timer + (reverse ? -Time.deltaTime : Time.deltaTime);

        if (timer >= period)
            reverse = true;
        if (timer <= 0)
            reverse = false;


    }
}
