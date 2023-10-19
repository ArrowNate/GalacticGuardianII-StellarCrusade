using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject[] projectiles;
    [SerializeField] private Transform[] projectileSpawnPoints;
    [SerializeField] private float shootTimerThreshold = 0.2f;
    [SerializeField] private float shootTimer;
    [SerializeField] bool canShoot;

    private void Update()
    {
        if (Time.time > shootTimer)
        {
            canShoot = true;
        }

        HandlePlayerShooting();
    }

    void HandlePlayerShooting()
    {
        if (!canShoot)
        {
            return;
        }

        // Shoot Blaster 1
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projectiles[0], projectileSpawnPoints[0].position, Quaternion.identity);

            Instantiate(projectiles[0], projectileSpawnPoints[1].position, Quaternion.identity);

            ResetShootingTimer();
        }

        // Shoot Blaster 2
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Instantiate(projectiles[1], projectileSpawnPoints[0].position, Quaternion.identity);

            Instantiate(projectiles[1], projectileSpawnPoints[1].position, Quaternion.identity);

            ResetShootingTimer();
        }

        // Shoot Laser
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Instantiate(projectiles[2], projectileSpawnPoints[0].position, Quaternion.identity);

            Instantiate(projectiles[2], projectileSpawnPoints[1].position, Quaternion.identity);

            ResetShootingTimer();
        }

        // Shoot Missile
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(projectiles[3], projectileSpawnPoints[2].position, Quaternion.identity);

            ResetShootingTimer();
        }

        // Shoot Heavy Missile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectiles[4], projectileSpawnPoints[2].position, Quaternion.identity);

            ResetShootingTimer();
        }
    }

    void ResetShootingTimer()
    {
        canShoot = false;
        shootTimer = Time.time + shootTimerThreshold;
    }
}