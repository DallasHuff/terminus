using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] FloatReference health;
    [SerializeField] FloatReference speed;


    public void TakeDamage(float dmgVal)
    {
        dmgVal = Mathf.Clamp(dmgVal, 0, dmgVal);
        health.Variable.Value -= dmgVal;

        if (health.Value < 0) { Die(); }
    }

    private void Die()
    {
        Debug.Log(transform + "died");
        //
    }
}
