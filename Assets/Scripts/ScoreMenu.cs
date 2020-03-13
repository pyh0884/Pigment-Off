using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class ScoreMenu : MonoBehaviour
{
    public Image[] img;
    public Sprite[] spr;
    public Text[] tex;
    GameManager gm;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        img[0].sprite = spr[gm.WinnerNum - 1];
        tex[0].text = (Mathf.FloorToInt(gm.WinnerTime / 180f * 1000f) / 10f) + " %";
        tex[1].text = gm.player1Time + "S";
        tex[2].text = gm.player2Time + "S";
        if (gm.player3 != 0) 
        tex[3].text = gm.player3Time + "S";  
        if (gm.player4 != 0) 
        tex[4].text = gm.player4Time + "S";
    }
    public void selfDes()
    {
        Destroy(gm.gameObject);
        Destroy(FindObjectOfType<InputManager>().gameObject);
    }
    public void RePlay()
    {
        if (gm.player3 == 0)
            GetComponent<Trans>().QuickLoad(1);
        else if (gm.player4 == 0)
                GetComponent<Trans>().QuickLoad(2);
            else
                GetComponent<Trans>().QuickLoad(3);
    }
    private void LateUpdate()
    {
        img[0].SetNativeSize();
    }
}
