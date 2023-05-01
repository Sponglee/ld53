using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVerticalFollower : MonoBehaviour
{
    public Transform playerRef;
    public Vector3 offset;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + offset.x, playerRef.transform.position.y + offset.y, transform.position.z + offset.z);
        // transform.LookAt(playerRef.transform.position + offset, Vector3.up);
    }
}
