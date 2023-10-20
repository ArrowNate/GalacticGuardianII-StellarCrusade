using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLife : MonoBehaviour
{
    [SerializeField] private float timer = 3f;

    private void OnEnable()
    {
        Invoke("DeactivateProjectile", timer);
    }

    void DeactivateProjectile()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }
}
