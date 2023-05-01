using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public float jumpForce = 15f;
    public Transform modelHolder;
    public Transform bouncePoint;
    public float boucneInDuration = 0.25f;
    public Vector3 bounceIn;
    public float bounceOutDuration = 0.25f;
    public Vector3 bounceOut;

    private bool isInternalCooldown = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            // if (other.transform.position.y < transform.position.y) return;

            if (isInternalCooldown) return;
            isInternalCooldown = true;

            PlayerController tmpPlayer = other.GetComponent<PlayerController>();
            tmpPlayer.ResetVelocity();
            tmpPlayer.ForceMoveTo(new Vector3(tmpPlayer.transform.position.x, bouncePoint.position.y, tmpPlayer.transform.position.z), boucneInDuration / 2f);
            Bounce(() =>
            {
                tmpPlayer.Jump(jumpForce);
                DOVirtual.DelayedCall(0.2f, () => isInternalCooldown = false);
            });

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Bounce(() => { });
        }
    }
    Sequence bounce;
    private void Bounce(Action onFinish)
    {

        bounce?.Kill();
        bounce = DOTween.Sequence().Append(modelHolder.DOScale(bounceIn, boucneInDuration)
                      .OnComplete(() =>
                      {
                          modelHolder.DOScale(bounceOut, bounceOutDuration);
                          onFinish?.Invoke();
                      }))
                      .AppendInterval(0.1f)
                      .OnComplete(() =>
                      {
                      })
                      .Append(modelHolder.DOScale(Vector3.one, bounceOutDuration))
                       .AppendInterval(0.1f)
                      .Play();
    }
}
