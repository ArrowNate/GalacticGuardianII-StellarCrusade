using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{
    Health, Blaster1, Blaster2, Missile, HeavyMissile
}

public class Collectables : MonoBehaviour
{
    public CollectableType type;

    [SerializeField] private float moveSpeed = 5f;

    private float minHealth = 10f, maxHealth = 30f;
    private float healthValue;

    private Vector3 tempPos;

    private void Start()
    {
        healthValue = Random.Range(minHealth, maxHealth);
    }

    private void Update()
    {
        tempPos = transform.position;
        tempPos.y -= moveSpeed * Time.deltaTime;
        transform.position = tempPos;
    }

    private void OnDisable()
    {
        SoundManager.instance.PlayPickUpSound();
    }

    public float GetHealthValue()
    {
        return healthValue;
    }

    public void SetHealthValue(float newHealthValue)
    {
        healthValue = newHealthValue;
    }
}