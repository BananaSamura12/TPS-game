using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    // Update is called once per frame
    public void DealDamage(float damage)
    {
        value -= damage;
        if(value <= 0)
        {
            Destroy(gameObject);
        }
    }
}
