using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject playerExplosionFX;
    [SerializeField] GameObject playerDamageFX;
    [SerializeField] private float playerMaxHealth = 100f;
    [SerializeField] private float playerHealth;

    private Collectables collectables;

    private Slider playerHealthSlider;

    private void Awake()
    {
        playerHealthSlider = GameObject.FindWithTag(TagManager.PLAYER_HEALTH_SLIDER_TAG).GetComponent<Slider>();

        playerHealth = playerMaxHealth;

        playerHealthSlider.minValue = 0;
        playerHealthSlider.maxValue = playerHealth;
        playerHealthSlider.value = playerHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        playerHealth -= damageAmount;
        playerHealthSlider.value = playerHealth;

        if (playerHealth <= 0)
        {
            Instantiate(playerExplosionFX, transform.position, Quaternion.identity);

            SoundManager.instance.PlayDestroySound();

            GameoverUIController.instance.GameoverPanel();

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
                playerHealthSlider.value = playerHealth;

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