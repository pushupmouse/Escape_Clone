using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Board _board;
    [SerializeField] private Block _block;

    private void Start()
    {
        for(int i = 0;  i < 4; i++)
        {
            Debug.Log("hi");
        }
    }
}
