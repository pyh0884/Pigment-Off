using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    GameManager gm;
    Image img;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        img = GetComponent<Image>();
    }

    void Update()
    {
        img.fillAmount = gm.PlayTime / 300f;
    }
}
