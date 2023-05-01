using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    public Transform finishPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().ForceMoveTo(finishPoint);
            CameraManager.Instance.SetLive("finishCam");
        }
    }
}
