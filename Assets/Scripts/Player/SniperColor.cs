using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperColor : MonoBehaviour
{
    public GameObject ColorPool1;
    public GameObject ColorPool2;
    public GameObject ColorPool3;
    private int ColorType;
    private float ColorTimer = 10;
    public float Timer = 0.75f;
    void Update()
    {
        ColorTimer += Time.deltaTime;
        if (ColorTimer >= Timer)
        {
            ColorType = Mathf.FloorToInt(Random.Range(0, 2.9f));
            switch (ColorType)
            {
                case 0:
                    Instantiate(ColorPool1, gameObject.transform.position, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(ColorPool2, gameObject.transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(ColorPool3, gameObject.transform.position, Quaternion.identity);
                    break;
                default:
                    Instantiate(ColorPool1, gameObject.transform.position, Quaternion.identity);
                    break;
            }

        }
    }
}
