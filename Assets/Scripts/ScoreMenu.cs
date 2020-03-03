using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        tex[0].text = gm.WinnerTime/180+" %";
        tex[1].text = gm.player1Time + "";
        tex[2].text = gm.player2Time + "";
        if (gm.player3 != 0) 
        tex[3].text = gm.player3Time + "";
        if (gm.player4 != 0) 
        tex[4].text = gm.player4Time + "";
    }
    public void selfDes()
    {
        gm.selfDes();
    }
    // Update is called once per frame
    private void LateUpdate()
    {
        img[0].SetNativeSize();
    }
}
