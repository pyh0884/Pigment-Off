using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EFXColorControl : MonoBehaviour
{
    public int camp = 0;
    private void Start()
    {
        Color camp0 = new Color(0.9215686f, 0.6431373f, 0);//黄色 0.9215686f,0.6431373f
        Color camp1 = new Color(0.6235294f, 0.5529412f, 0.9137255f);//紫色
        Color camp2 = new Color(0,0.6745098f,0.9215686f);//蓝色

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
