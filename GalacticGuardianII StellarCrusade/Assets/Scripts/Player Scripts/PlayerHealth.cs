using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject playerExplosionFX;
    [SerializeField] GameObject playerDamageFX;
    [SerializeField] private float playerMaxHealth = 100f;
    [SerializeField] private float playerHealth;

    private Collectables collectables;

    private void Awake()
    {
        playerHealth = playerMaxHealth / 2;
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
        if (collision.CompareTag(TagManager.COLLECTABLE_TAG))
        {
            collectables = collision.GetComponent<Collectables>();

            if (collectables.type == CollectableType.Health)
            {
                float healthValue = collectables.GetHealthValue();

                playerHealth += healthValue;

                if (playerHealth > playerMaxHealth)
                    playerHealth = playerMaxHealth;

                Destroy(collision.gameObject);
            }
        }

        if (collision.CompareTag(TagManager.METEOR_TAG))
        {
            TakeDamage(Random.Range(20, 40));
            Destroy(collision.gameObject);
        }
    }
}