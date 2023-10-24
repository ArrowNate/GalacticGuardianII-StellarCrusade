using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
    [SerializeField] private bool isFlipped;

    private void Start()
    {
        if (isFlipped == true)
        {
            this.transform.rotation = Quaternion.Euler(180, 0, 0);
        }
    }
}
