using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danmuku : MonoBehaviour
{
    public GameObject bullet;
    public float AttackGap;
    private float z;
    public float DanmuGap;
    public void Shoot()
    {
        z = transform.eulerAngles.z;
        StartCoroutine("Danmu");
    }
    IEnumerator Danmu()
    {
        for (int k = 0; k < 6; k++) 
        {
            for (float i = -DanmuGap * 2; i < DanmuGap * 2; i += DanmuGap)
            {
                var bul = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, z + i));
                bul.GetComponent<Rigidbody2D>().velocity = bul.transform.right * 20;
            }
            yield return new WaitForSeconds(AttackGap);
        }
    }
}
