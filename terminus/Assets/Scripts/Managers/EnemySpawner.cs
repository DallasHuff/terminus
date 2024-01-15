using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform playerTrans;
    [SerializeField] GameObject meleeEnemy;
    [SerializeField] GameObject rangedEnemy;
    [SerializeField] float spawnSpeed;
    [SerializeField] float spawnDistance;
    TextMeshProUGUI textMeshProUGUI;
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
        Vector3 randomPosition = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), 0);
        Vector3 position = playerTrans.position + (randomPosition.normalized * spawnDistance);
        Instantiate(enemy, position, Quaternion.identity);
    }
}
