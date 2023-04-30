using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVerticalFollower : MonoBehaviour
{
    public Transform playerRef;


    private void Update()
    {
        transform.position = new Vector3(transform.position.x, playerRef.transform.position.y, transform.position.x);
        transform.LookAt(playerRef.transform.position, Vector3.up);
    }
}
