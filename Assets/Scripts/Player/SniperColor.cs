using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperColor : MonoBehaviour
{
    public GameObject[] ColorPool1;
    public GameObject[] ColorPool2;
    public GameObject[] ColorPool3;
    private float ColorTimer = 10;
    public float Timer = 0.75f;
    private int Camp;
    private void Start()
    {
        Camp = gameObject.transform.parent.GetComponent<BulletAI>().Camp;
    }
    void Update()
    {
        ColorTimer += Time.deltaTime;
        if (ColorTimer >= Timer)
        {
            if (Camp == 0)
            {
                switch (Mathf.FloorToInt(Random.Range(0, 13.9f)))
                {
                    case 0:
                        var bul = Instantiate(ColorPool1[0], gameObject.transform.position, Quaternion.identity);
                        bul.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 1:
                        var bul2 = Instantiate(ColorPool1[1], gameObject.transform.position, Quaternion.identity);
                        bul2.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 2:
                        var bul3 = Instantiate(ColorPool1[2], gameObject.transform.position, Quaternion.identity);
                        bul3.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 3:
                        var bul4 = Instantiate(ColorPool1[3], gameObject.transform.position, Quaternion.identity);
                        bul4.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 4:
                        var bul5 = Instantiate(ColorPool1[4], gameObject.transform.position, Quaternion.identity);
                        bul5.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 5:
                        var bul6 = Instantiate(ColorPool1[5], gameObject.transform.position, Quaternion.identity);
                        bul6.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 6:
                        var bul7 = Instantiate(ColorPool1[6], gameObject.transform.position, Quaternion.identity);
                        bul7.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 7:
                        var bul8 = Instantiate(ColorPool1[7], gameObject.transform.position, Quaternion.identity);
                        bul8.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 8:
                        var bul9 = Instantiate(ColorPool1[8], gameObject.transform.position, Quaternion.identity);
                        bul9.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 9:
                        var bul10 = Instantiate(ColorPool1[9], gameObject.transform.position, Quaternion.identity);
                        bul10.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 10:
                        var bul11 = Instantiate(ColorPool1[10], gameObject.transform.position, Quaternion.identity);
                        bul11.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 11:
                        var bul12 = Instantiate(ColorPool1[11], gameObject.transform.position, Quaternion.identity);
                        bul12.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 12:
                        var bul13 = Instantiate(ColorPool1[12], gameObject.transform.position, Quaternion.identity);
                        bul13.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 13:
                        var bul14 = Instantiate(ColorPool1[13], gameObject.transform.position, Quaternion.identity);
                        bul14.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    default:
                        var bul15 = Instantiate(ColorPool1[0], gameObject.transform.position, Quaternion.identity);
                        bul15.GetComponent<ColorPool>().Camp = Camp;
                        break;
                }
            }
            if (Camp == 1)
            {
                switch (Mathf.FloorToInt(Random.Range(0, 13.9f)))
                {
                    case 0:
                        var bul = Instantiate(ColorPool2[0], gameObject.transform.position, Quaternion.identity);
                        bul.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 1:
                        var bul2 = Instantiate(ColorPool2[1], gameObject.transform.position, Quaternion.identity);
                        bul2.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 2:
                        var bul3 = Instantiate(ColorPool2[2], gameObject.transform.position, Quaternion.identity);
                        bul3.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 3:
                        var bul4 = Instantiate(ColorPool2[3], gameObject.transform.position, Quaternion.identity);
                        bul4.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 4:
                        var bul5 = Instantiate(ColorPool2[4], gameObject.transform.position, Quaternion.identity);
                        bul5.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 5:
                        var bul6 = Instantiate(ColorPool2[5], gameObject.transform.position, Quaternion.identity);
                        bul6.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 6:
                        var bul7 = Instantiate(ColorPool2[6], gameObject.transform.position, Quaternion.identity);
                        bul7.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 7:
                        var bul8 = Instantiate(ColorPool2[7], gameObject.transform.position, Quaternion.identity);
                        bul8.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 8:
                        var bul9 = Instantiate(ColorPool2[8], gameObject.transform.position, Quaternion.identity);
                        bul9.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 9:
                        var bul10 = Instantiate(ColorPool2[9], gameObject.transform.position, Quaternion.identity);
                        bul10.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 10:
                        var bul11 = Instantiate(ColorPool2[10], gameObject.transform.position, Quaternion.identity);
                        bul11.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 11:
                        var bul12 = Instantiate(ColorPool2[11], gameObject.transform.position, Quaternion.identity);
                        bul12.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 12:
                        var bul13 = Instantiate(ColorPool2[12], gameObject.transform.position, Quaternion.identity);
                        bul13.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 13:
                        var bul14 = Instantiate(ColorPool2[13], gameObject.transform.position, Quaternion.identity);
                        bul14.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    default:
                        var bul15 = Instantiate(ColorPool2[0], gameObject.transform.position, Quaternion.identity);
                        bul15.GetComponent<ColorPool>().Camp = Camp;
                        break;
                }
            }
            if (Camp == 2)
            {
                switch (Mathf.FloorToInt(Random.Range(0, 13.9f)))
                {
                    case 0:
                        var bul = Instantiate(ColorPool3[0], gameObject.transform.position, Quaternion.identity);
                        bul.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 1:
                        var bul2 = Instantiate(ColorPool3[1], gameObject.transform.position, Quaternion.identity);
                        bul2.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 2:
                        var bul3 = Instantiate(ColorPool3[2], gameObject.transform.position, Quaternion.identity);
                        bul3.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 3:
                        var bul4 = Instantiate(ColorPool3[3], gameObject.transform.position, Quaternion.identity);
                        bul4.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 4:
                        var bul5 = Instantiate(ColorPool3[4], gameObject.transform.position, Quaternion.identity);
                        bul5.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 5:
                        var bul6 = Instantiate(ColorPool3[5], gameObject.transform.position, Quaternion.identity);
                        bul6.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 6:
                        var bul7 = Instantiate(ColorPool3[6], gameObject.transform.position, Quaternion.identity);
                        bul7.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 7:
                        var bul8 = Instantiate(ColorPool3[7], gameObject.transform.position, Quaternion.identity);
                        bul8.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 8:
                        var bul9 = Instantiate(ColorPool3[8], gameObject.transform.position, Quaternion.identity);
                        bul9.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 9:
                        var bul10 = Instantiate(ColorPool3[9], gameObject.transform.position, Quaternion.identity);
                        bul10.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 10:
                        var bul11 = Instantiate(ColorPool3[10], gameObject.transform.position, Quaternion.identity);
                        bul11.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 11:
                        var bul12 = Instantiate(ColorPool3[11], gameObject.transform.position, Quaternion.identity);
                        bul12.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 12:
                        var bul13 = Instantiate(ColorPool3[12], gameObject.transform.position, Quaternion.identity);
                        bul13.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    case 13:
                        var bul14 = Instantiate(ColorPool3[13], gameObject.transform.position, Quaternion.identity);
                        bul14.GetComponent<ColorPool>().Camp = Camp;
                        break;
                    default:
                        var bul15 = Instantiate(ColorPool3[0], gameObject.transform.position, Quaternion.identity);
                        bul15.GetComponent<ColorPool>().Camp = Camp;
                        break;
                }
            }
        }
    }
}
