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

    public StaminaController staminaController;
    public WingPairController[] wings;

    private bool movementOverride = false;
    private float movementDuration = 3f;
    private float movementTimer = 0f;
    private Vector3 startMovePos;
    private Vector3 endMovePos;

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
            if (staminaController.IsStaminaRecharging) return;
            RotatePivot(true);
            _body.AddForce(upPivot.up * forceAmount, ForceMode.Impulse);
            wings[1].Flap();
            staminaController.SpendStamina(2f);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (staminaController.IsStaminaRecharging) return;

            RotatePivot(false);
            _body.AddForce(upPivot.up * forceAmount, ForceMode.Impulse);
            wings[0].Flap();
            staminaController.SpendStamina(2f);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            if (staminaController.IsStaminaRecharging)
            {
                _body.drag = dragLimits.x;
                return;
            }
            else
            {
                _body.drag = dragLimits.y;
                staminaController.SpendStamina();
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _body.drag = dragLimits.x;
        }
        else
        {
            staminaController.RechargeStamina();
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

    public void Drop()
    {
        _body.velocity = Vector3.zero;
    }

    public void ForceMoveTo(Transform targetPoint, float aDuration)
    {
        if (movementOverride) return;

        startMovePos = transform.position;
        endMovePos = targetPoint.position;
        movementDuration = aDuration;
        movementTimer = 0f;
        movementOverride = true;
    }

    public void ForceMoveTo(Vector3 targetPointPos, float aDuration)
    {
        if (movementOverride) return;

        startMovePos = transform.position;
        endMovePos = targetPointPos;
        movementDuration = aDuration;
        movementTimer = 0f;
        movementOverride = true;
    }
}
