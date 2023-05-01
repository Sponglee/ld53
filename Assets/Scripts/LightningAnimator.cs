using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LightningAnimator : MonoBehaviour
{

    public float waitTime = 2f;



    private IEnumerator Start()
    {
        while (true)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(-30, 31));
            yield return new WaitForSeconds(waitTime);
        }
    }



}
