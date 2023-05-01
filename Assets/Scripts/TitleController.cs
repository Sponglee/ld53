using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    private Tween tweenScale;
    public Transform modelHolder;
    public float animationDuration = 0.5f;


    public void ToggleLogo(bool aToggle)
    {
        tweenScale?.Kill();
        modelHolder.localScale = aToggle ? Vector3.zero : Vector3.one;
        tweenScale = modelHolder.DOScale(aToggle ? Vector3.one : Vector3.zero, animationDuration).SetEase(Ease.InOutElastic);
    }
}
