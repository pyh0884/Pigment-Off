using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefreshUI : MonoBehaviour
{
    public Image[] imgs;
    void Update()
    {
        foreach(Image sr in imgs)
        {
            sr.SetNativeSize();
        }
    }
}
