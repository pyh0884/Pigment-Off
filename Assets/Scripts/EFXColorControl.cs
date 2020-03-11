using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EFXColorControl : MonoBehaviour
{
    public int camp = 0;
    private void Awake()
    {
        Color camp0 = new Color(0.8f, 0.8666667f, 0.5058824f);//黄色
        Color camp1 = new Color(0.6235294f, 0.5529412f, 0.9137255f);//紫色
        Color camp2 = new Color(0.4313726f, 0.6980392f, 0.6509804f);//蓝色
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
