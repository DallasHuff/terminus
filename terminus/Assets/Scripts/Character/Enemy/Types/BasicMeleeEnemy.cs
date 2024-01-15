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
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    // Start is called before the first frame update
    void Start()
    {
        playerGO = GameObject.Find(player);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(playerGO.transform.position, gameObject.transform.position);
        Move();
    }

    public void TakeDamage(float dmgVal)
    {
        dmgVal = Math.Clamp(dmgVal, 0, float.MaxValue);

        health -= dmgVal;

        if (health < 1) { Die(); }
    }

    private void Move()
    {
        Vector3 moveVector = playerGO.transform.position - gameObject.transform.position;
        gameObject.transform.position += moveVector.normalized * speed;
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " died");
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            PlayerStats pStats = collision.collider.GetComponent<PlayerStats>();
            pStats.TakeDamage(damage);
        }
    }
}
