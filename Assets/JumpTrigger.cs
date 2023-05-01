using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public float jumpForce = 15f;
    public Transform modelHolder;

    public float boucneInDuration = 0.25f;
    public Vector3 bounceIn;
    public float bounceOutDuration = 0.25f;
    public Vector3 bounceOut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController tmpPlayer = other.GetComponent<PlayerController>();
            tmpPlayer.ResetVelocity();

            Bounce(() =>
            {
                tmpPlayer.Jump(jumpForce);
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
