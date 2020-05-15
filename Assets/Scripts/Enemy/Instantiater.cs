using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiater : MonoBehaviour
{
    float insTimer;
    public float insTime = 15;
    public GameObject enemy;
    public Vector3[] trans;
    bool canIns = true;
    GameObject enemy1;
    GameObject enemy2;
    void Start()
    {
        insTimer = 0;
    }

    void Update()
    {
        if (canIns)
        {
            insTimer += Time.deltaTime;
        }
        if (insTimer >= insTime && canIns) 
        {
            enemy1 = Instantiate(enemy, trans[Mathf.FloorToInt(Random.Range(0, 3))], Quaternion.identity);
            enemy2 = Instantiate(enemy, trans[Mathf.FloorToInt(Random.Range(1, 4))], Quaternion.identity);
            insTimer = 0;
            canIns = false;
        }
        if (enemy1 == null && enemy2 == null)
        {
            canIns = true;
        }
    }
}
