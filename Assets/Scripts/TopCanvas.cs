using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopCanvas : MonoBehaviour
{
    GameManager gm;
    public Image[] images;
    public Sprite[] sprs;
    public Text txt;
    public GameObject[] gos;
    private void Start()
    {
        Color camp0 = new Color(0.8f, 0.8666667f, 0.5058824f);//黄色
        Color camp1 = new Color(0.6235294f, 0.5529412f, 0.9137255f);//紫色
        Color camp2 = new Color(0.4313726f, 0.6980392f, 0.6509804f);//蓝色
        gm = FindObjectOfType<GameManager>();
        images[4].color = camp0;
        images[7].color = camp1;
        if (gm.player4 != 0) 
        {
            images[5].color = camp0;
            images[6].color = camp1;
        }
        else
        {
            images[5].color = camp1;
            images[6].color = camp2;
        }
        #region 头像
        images[0].sprite = sprs[gm.player1];
        images[1].sprite = sprs[gm.player2];
        if (gm.player3 != 0)
        {
            images[2].sprite = sprs[gm.player3];
        }
        else 
        {
            gos[2].SetActive(false);
        }
        if (gm.player4 != 0)
        {
            images[3].sprite = sprs[gm.player4];
        }
        else
        {
            gos[3].SetActive(false);
        }
        #endregion
    }
    void Update()
    {
        txt.text = Mathf.FloorToInt(gm.PlayTime / 60) + ":" + Mathf.FloorToInt(gm.PlayTime - Mathf.FloorToInt(gm.PlayTime / 60) * 60);
    }
    private void LateUpdate()
    {
        images[0].SetNativeSize();
        images[1].SetNativeSize();
        images[2].SetNativeSize();
        images[3].SetNativeSize();
        images[8].SetNativeSize();
        images[9].SetNativeSize();
        images[10].SetNativeSize();
        images[11].SetNativeSize();
    }
}