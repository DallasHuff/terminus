using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform playerTrans;
    [SerializeField] GameObject meleeEnemy;
    [SerializeField] GameObject rangedEnemy;
    [SerializeField] float spawnSpeed;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    private float timeSinceSpawn;
    void Start()
    {
        playerTrans = GameObject.Find("Player").transform;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (timeSinceSpawn > spawnSpeed)
        {
            timeSinceSpawn = 0;
            Spawn(meleeEnemy);
        }
        timeSinceSpawn += Time.deltaTime;
    }

    private void Spawn(GameObject enemy)
    {
        Debug.Log("Spawning");
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        Vector3 position = playerTrans.position + randomPosition;
        Instantiate(enemy, position, Quaternion.identity);
    }
}
