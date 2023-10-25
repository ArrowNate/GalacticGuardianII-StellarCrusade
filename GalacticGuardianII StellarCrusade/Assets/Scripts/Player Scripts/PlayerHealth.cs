using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject playerExplosionFX;
    [SerializeField] GameObject playerDamageFX;
    [SerializeField] private float playerMaxHealth = 100f;
    [SerializeField] private float playerHealth;

    private void Awake()
    {
        playerHealth = playerMaxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        playerHealth -= damageAmount;

        if (playerHealth <= 0)
        {
            Instantiate(playerExplosionFX, transform.position, Quaternion.identity);

            SoundManager.instance.PlayDestroySound();

            Destroy(gameObject);
        }
        else
        {
            Instantiate(playerDamageFX, transform.position, Quaternion.identity);

            SoundManager.instance.PlayDamageSound();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.METEOR_TAG))
        {
            TakeDamage(Random.Range(20, 40));
            Destroy(collision.gameObject);
        }
    }
}