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
    private bool s1, s2, s3, s4;
    public Image[] refresh;
    private void Start()
    {
        //Color camp0 = new Color(0.9215686f, 0.6431373f, 0);//黄色
        //Color camp1 = new Color(0.6235294f, 0.5529412f, 0.9137255f);//紫色
        //Color camp2 = new Color(0, 0.6745098f, 0.9215686f);//蓝色
        gm = FindObjectOfType<GameManager>();
        //images[4].color = camp0;
        //images[7].color = camp1;
        //if (gm.player4 != 0) 
        //{
        //    images[5].color = camp0;
        //    images[6].color = camp1;
        //}
        //else
        //{
        //    images[5].color = camp1;
        //    images[6].color = camp2;
        //}
        #region 头像+Skill
        images[0].sprite = sprs[gm.player1 - 1];
        images[1].sprite = sprs[gm.player2 - 1];
        if (gm.player3 != 0)
        {
            images[2].sprite = sprs[gm.player3 - 1];
            if (gm.player3 == 1 || gm.player3 == 2)
            {
                images[6].sprite = sprs[8];
            }
            else if (gm.player3 == 3 || gm.player3 == 4)
            {
                images[6].sprite = sprs[9];
            }
            else
            {
                images[6].sprite = sprs[10];
            }
        }
        else 
        {
            gos[2].SetActive(false);
        }
        if (gm.player4 != 0)
        {
            images[3].sprite = sprs[gm.player4 - 1];
            if (gm.player4 == 1 || gm.player4 == 2)
            {
                images[7].sprite = sprs[8];
            }
            else if (gm.player4 == 3 || gm.player4 == 4)
            {
                images[7].sprite = sprs[9];
            }
            else
            {
                images[7].sprite = sprs[10];
            }
        }
        else
        {
            gos[3].SetActive(false);
        }
        if (gm.player1 == 1 || gm.player1 == 2)
        {
            images[4].sprite = sprs[8];
        }
        else if (gm.player1 == 3 || gm.player1 == 4)
        {
            images[4].sprite = sprs[9];
        }
        else
        {
            images[5].sprite = sprs[10];
        }
        if (gm.player2 == 1 || gm.player2 == 2)
        {
            images[5].sprite = sprs[8];
        }
        else if (gm.player2 == 3 || gm.player2 == 4)
        {
            images[5].sprite = sprs[9];
        }
        else
        {
            images[5].sprite = sprs[10];
        }
        #endregion
    }
    public void Shield(int num)
    {
        switch (num)
        {
            case 1:
                images[8].sprite = sprs[s1 ? 6 : 7];
                s1 = !s1;
                break;
            case 2:
                images[9].sprite = sprs[s2 ? 6 : 7];
                s2 = !s2;
                break;
            case 3:
                images[10].sprite = sprs[s3 ? 6 : 7];
                s3 = !s3;
                break;
            case 4:
                images[11].sprite = sprs[s4 ? 6 : 7];
                s4 = !s4;
                break;
        }
    }
    void Update()
    {
        txt.text = Mathf.FloorToInt(gm.PlayTime / 60) + ":" + Mathf.FloorToInt(gm.PlayTime - Mathf.FloorToInt(gm.PlayTime / 60) * 60);
    }
    private void LateUpdate()
    {
        foreach (Image img in refresh)
        {
            img.SetNativeSize();
        }
    }
}