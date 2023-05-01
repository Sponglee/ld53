using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ThunderCloud : MonoBehaviour
{
    public Vector2 moveLimits;
    public float moveDuration = 5f;
    public float waitDuration = 5f;

    Sequence tmpSequence;
    Tween tmpForward;
    Tween tmpBackward;

    public Transform modelHolder;

    private void Start()
    {
        transform.position = new Vector3(moveLimits.y, transform.position.y, transform.position.z);

        DOTween.Sequence().Append(transform.DOMove(new Vector3(moveLimits.x, transform.position.y, transform.position.z), moveDuration)
        .OnComplete(() =>
        {
            transform.DOMove(new Vector3(moveLimits.x, transform.position.y, transform.position.z), moveDuration);
        }))
        .AppendInterval(waitDuration).SetLoops(-1, LoopType.Yoyo).Play();

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().Drop();
            DOTween.Sequence().Append(modelHolder.DOScale(Vector3.one * 1.5f, 0.1f)
                 .OnComplete(() =>
                 {
                     modelHolder.DOScale(Vector3.one, 0.25f);
                 }))
                 .Play();
        }
    }
}
