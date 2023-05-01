using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public GameObject[] levels;
    public Transform levelHolder;


    private void Start()
    {
        int levelIndex = GameManager.Instance.GetLevelData();
        Instantiate(levels[levelIndex % levels.Length], levelHolder);
    }
}
