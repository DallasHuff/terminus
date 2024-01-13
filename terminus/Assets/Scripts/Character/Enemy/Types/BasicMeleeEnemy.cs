using System.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class BasicMeleeEnemy : MonoBehaviour, IEnemy
{

    private String player = "Player";
    private GameObject playerGO;
    private float health;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        playerGO = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(playerGO.transform.position, gameObject.transform.position);
        if (dist < 2) { Attack(); }
        else { Move(); }
    }

    public void Attack()
    {
        return;
    }

    public void TakeDamage(float dmgVal)
    {
        dmgVal = Math.Clamp(dmgVal, 0, float.MaxValue);

        health -= dmgVal;

        if (health < 1) { Die(); }
    }

    public void Move()
    {
        Vector3 moveVector = playerGO.transform.position - gameObject.transform.position;
        gameObject.transform.position += moveVector.normalized;
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " died");
        Destroy(gameObject);
    }
}
