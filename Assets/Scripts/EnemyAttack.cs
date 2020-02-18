using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 20;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12) 
        {
            collision.gameObject.GetComponent<HealthBar>().Damage(damage);
        }
    }
}
