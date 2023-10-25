using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private GameObject destroyEffect;
    [SerializeField] private float health = 100f;

    private Vector3 healthBarScale;

    public void TakeDamage(float damageAmount, float damageResistance)
    {
        damageAmount -= damageResistance;
        health -= damageAmount;

        if (health <= 0)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
        else
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

        SetHealthBar();
    }

    void SetHealthBar()
    {
        if (!healthBar)
            return;

        healthBarScale = healthBar.transform.localScale;
        healthBarScale.x = health / 100f;
        healthBar.transform.localScale = healthBarScale;
    }
}
