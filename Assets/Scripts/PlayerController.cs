using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _body;
    public float forceAmount = 10f;
    public float rotationAmount = 10f;
    public float rotationDamper = 0.5f;
    public Vector2 dragLimits;
    public Transform upPivot;


    private bool movementOverride = false;
    private float movementDuration = 3f;
    private float movementTimer = 0f;

    private Vector3 startMovePos;
    private Vector3 endMovePos;

    public WingPairController[] wings;
    private void Start()
    {
        _body = GetComponent<Rigidbody>();
        _body.drag = dragLimits.x;
    }

    private void Update()
    {
        if (movementOverride)
        {
            transform.position = Vector3.Lerp(startMovePos, endMovePos, movementTimer / movementDuration);
            movementTimer += Time.deltaTime;
            if (movementTimer >= movementDuration)
            {
                movementTimer = 0f;
                movementOverride = false;
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            RotatePivot(true);
            _body.AddForce(upPivot.up * forceAmount, ForceMode.Impulse);
            wings[1].Flap();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            RotatePivot(false);
            _body.AddForce(upPivot.up * forceAmount, ForceMode.Impulse);
            wings[0].Flap();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            _body.drag = dragLimits.y;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _body.drag = dragLimits.x;
        }
        upPivot.rotation = Quaternion.Lerp(upPivot.rotation, Quaternion.identity, rotationDamper * Time.deltaTime);



    }

    public void RotatePivot(bool isLeft)
    {
        upPivot.Rotate(Vector3.forward, isLeft ? -rotationAmount : rotationAmount, Space.Self);
    }

    public void ResetVelocity()
    {
        _body.velocity = new Vector3(_body.velocity.x, 0f, _body.velocity.z);
    }
    public void Jump(float aForce)
    {
        _body.AddForce(upPivot.up * aForce, ForceMode.Impulse);
    }
    public void ForceMoveTo(Transform targetPoint)
    {
        if (movementOverride) return;

        startMovePos = transform.position;
        endMovePos = targetPoint.position;
        movementTimer = 0f;
        movementOverride = true;
    }
}
