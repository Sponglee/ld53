using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingPairController : MonoBehaviour
{
    public Animator[] wingAnimators;


    public void Flap()
    {
        for (int i = 0; i < wingAnimators.Length; i++)
        {
            wingAnimators[i].SetTrigger("Flap");
        }
    }
}
