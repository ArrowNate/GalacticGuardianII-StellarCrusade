using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] meteors;
    [SerializeField] private float minX, maxX;
    [SerializeField] private float minSpawnInterval = 4f, maxSpawnInterval = 10f;
    [SerializeField] private int randSpawnNum;
    [SerializeField] private int minSpawnNum = 1, maxSpawnNum = 5;

    private Vector3 randSpawnPos;

    private void Start()
    {
        Invoke("SpawnMeteors", Random.Range(minSpawnInterval, maxSpawnInterval));
    }

    void SpawnMeteors()
    {
        randSpawnNum = Random.Range(minSpawnNum, maxSpawnNum);

        for (int i = 0; i < randSpawnNum; i++)
        {
            randSpawnPos = new Vector3(Random.Range(minX, maxX), transform.position.y, 0f);
            Instantiate(meteors[Random.Range(0, meteors.Length)], randSpawnPos, Quaternion.identity);
        }

        Invoke("SpawnMeteors", Random.Range(minSpawnInterval, maxSpawnInterval));
    }
}
