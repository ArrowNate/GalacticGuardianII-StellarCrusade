using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    [SerializeField] private WeaponUpgrade weaponUpgrade;

    private Collectables collectables;

    void DestroyCollectable(Collectables collect)
    {
        if (collect.type != CollectableType.Health)
        {
            Destroy(collect.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.COLLECTABLE_TAG))
        {
            collectables = collision.GetComponent<Collectables>();

            if (collectables.type == CollectableType.Blaster1)
            {
                weaponUpgrade.ActivateWeapon(0);
            }

            if (collectables.type == CollectableType.Blaster2)
            {
                weaponUpgrade.ActivateWeapon(1);
            }

            if (collectables.type == CollectableType.Missile)
            {
                weaponUpgrade.ActivateWeapon(2);
            }

            if (collectables.type == CollectableType.HeavyMissile)
            {
                weaponUpgrade.ActivateWeapon(3);
            }

            DestroyCollectable(collectables);
        }
    }
}
