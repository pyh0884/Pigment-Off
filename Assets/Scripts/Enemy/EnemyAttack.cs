using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 20;
    public GameObject efx2;
    public bool isBoss;
    public AudioSource StoneSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12) 
        {
            collision.gameObject.GetComponent<HealthBar>().Damage(damage);
            Instantiate(efx2, transform.position, transform.rotation);//TODO
        }
        if (collision.gameObject.layer == 13) //"Wall"
        {
            if (isBoss)
            {
                StoneSound.Play();
                Destroy(collision.gameObject);
            }
        }

    }
}
