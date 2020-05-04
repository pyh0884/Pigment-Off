using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstantiater : MonoBehaviour
{
    public GameObject kele;
    public GameObject paoxie;
    public GameObject hudun;
    GameManager gm;
    public float InsGap = 5;
    private float timer = 0;
    private int num;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (gm.PlayTime > 5)
        {
            timer += Time.deltaTime;
            if (timer > InsGap)
            {
                num = Random.Range(0, 10);
                timer = 0;
                if (num<=3)
                    Instantiate(kele, new Vector3(Random.Range(-30, 35), Random.Range(-15, 15), 0), Quaternion.identity);
                else if (num<=6)
                    Instantiate(paoxie, new Vector3(Random.Range(-30, 35), Random.Range(-15, 15), 0), Quaternion.identity);
                else
                    Instantiate(hudun, new Vector3(Random.Range(-30, 35), Random.Range(-15, 15), 0), Quaternion.identity);
            }
        }
    }
}
