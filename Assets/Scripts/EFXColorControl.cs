using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EFXColorControl : MonoBehaviour
{
    public int camp = 0;
    private void Start()
    {
        Color camp0 = new Color(0.454902f, 0.8980392f, 0.04705882f);//绿色
        Color camp1 = new Color(0.9803922f, 0.1843137f, 0.6745098f);//粉色
        Color camp2 = new Color(0.9215686f, 0.6431373f, 0);//黄色
        switch (camp)
        {
            case 0:
                GetComponent<SpriteRenderer>().color = camp0;
                break;
            case 1:
                GetComponent<SpriteRenderer>().color = camp1;
                break;
            case 2:
                GetComponent<SpriteRenderer>().color = camp2;
                break;
        }

    }
}
