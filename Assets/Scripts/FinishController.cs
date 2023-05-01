using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    public Transform finishPoint;
    public Animator zeusAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().staminaController.DeInitializeStamina();
            other.gameObject.GetComponent<PlayerController>().ForceMoveTo(finishPoint, 3f);
            CameraManager.Instance.SetLive("finishCam");
            GameManager.Instance.StopTimer();
            DOVirtual.DelayedCall(3f, () =>
            {
                GameManager.Instance.LevelComplete();
                zeusAnimator.SetTrigger("React");

            });
        }
    }
}
