using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private AudioClip spawnSound;
    [SerializeField] private AudioClip destroySound;
    [SerializeField] private GameObject boomEffect;

    [SerializeField] private float minDamage = 10f;
    [SerializeField] private float maxDamage = 30f;

    private float projectileDamage;

    private void Start()
    {
        projectileDamage = (int)Random.Range(minDamage, maxDamage);
    }

    private void OnEnable()
    {
        if (spawnSound)
        {
            AudioSource.PlayClipAtPoint(spawnSound, new Vector3(0f, 6f, 0f));
        }
    }

    private void Update()
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.PLAYER_TAG))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(projectileDamage);
        }

        if (collision.CompareTag(TagManager.ENEMY_TAG) || collision.CompareTag(TagManager.METEOR_TAG))
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(projectileDamage, 0);
        }

        if (!collision.CompareTag(TagManager.UNTAGGED_TAG) && !collision.CompareTag(TagManager.COLLECTABLE_TAG))
        {
            gameObject.SetActive(false);
        }
    }
}