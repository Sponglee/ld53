using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSegmentRotator : MonoBehaviour
{
    public bool IsRotating = true;
    public bool IsRandomize = false;
    public Vector2 cloudSpeedRange;

    public float cloudSpeed = 0f;

    void Start()
    {
        // cloudSpeed = Random.Range(cloudSpeedRange.x, cloudSpeedRange.y);

        if (IsRandomize)
            transform.rotation = Quaternion.Euler(0f, Random.Range(0, 360), 0f);
    }

    void Update()
    {
        if (!IsRotating) return;
        transform.Rotate(new Vector3(0f, cloudSpeed * Time.deltaTime), 0f);
    }
}
