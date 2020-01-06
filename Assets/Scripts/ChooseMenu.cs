using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseMenu : MonoBehaviour
{
    public Image[] img;
    public Sprite[] spr;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    public void Char1()
    {
        img[0].sprite = spr[0];
        img[1].sprite = spr[1];
        gm.playernum = 0;
    }
    public void Char2()
    {
        img[0].sprite = spr[2];
        img[1].sprite = spr[3]; gm.playernum = 1;

    }
    public void Char3()
    {
        img[0].sprite = spr[4];
        img[1].sprite = spr[5]; gm.playernum = 2;

    }
    public void Char4()
    {
        img[0].sprite = spr[6];
        img[1].sprite = spr[7]; gm.playernum = 3;

    }
    public void Char5()
    {
        img[0].sprite = spr[8];
        img[1].sprite = spr[9]; gm.playernum = 4;

    }
    public void Char6()
    {
        img[0].sprite = spr[10];
        img[1].sprite = spr[11]; gm.playernum = 5;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
