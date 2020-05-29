using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopCanvas : MonoBehaviour
{
    GameManager gm;
    public Image[] images;
    public Image[] items;
    public Sprite[] SprItems;
    public Sprite[] sprs;
    public Text txt;
    public GameObject[] gos;
    public Image[] refresh;
    private int[] SkillNum = new int[4];
    private void Start()
    {
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
                SkillNum[2] = 1;
            }
            else if (gm.player3 == 3 || gm.player3 == 4)
            {
                images[6].sprite = sprs[9];
                SkillNum[2] = 2;
            }
            else
            {
                images[6].sprite = sprs[10];
                SkillNum[2] = 3;
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
            images[4].sprite = sprs[10];
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
    public void CD(int playerNum,int playerClass,bool ready) 
    {
        switch (playerNum) 
        {
            case 1:
                if (playerClass == 0)
                {
                    images[4].sprite = ready ? sprs[8]: sprs[11];
                }
                else if (playerClass == 1)
                {
                    images[4].sprite = ready ? sprs[9] : sprs[12];
                }
                else 
                {
                    images[4].sprite = ready ? sprs[10] : sprs[13];
                }
                break;
            case 2:
                if (playerClass == 0)
                {
                    images[5].sprite = ready ? sprs[8] : sprs[11];
                }
                else if (playerClass == 1)
                {
                    images[5].sprite = ready ? sprs[9] : sprs[12];
                }
                else
                {
                    images[5].sprite = ready ? sprs[10] : sprs[13];
                }

                break;
            case 3:
                if (playerClass == 0)
                {
                    images[6].sprite = ready ? sprs[8] : sprs[11];
                }
                else if (playerClass == 1)
                {
                    images[6].sprite = ready ? sprs[9] : sprs[12];
                }
                else
                {
                    images[6].sprite = ready ? sprs[10] : sprs[13];
                }

                break;
            case 4:
                if (playerClass == 0)
                {
                    images[7].sprite = ready ? sprs[8] : sprs[11];
                }
                else if (playerClass == 1)
                {
                    images[7].sprite = ready ? sprs[9] : sprs[12];
                }
                else
                {
                    images[7].sprite = ready ? sprs[10] : sprs[13];
                }
                break;
            default:
                break;
        }
    }

    public void Shield(int num)
    {
        switch (num)
        {
            case 1:
                images[8].sprite = sprs[6];
                break;
            case 2:
                images[9].sprite = sprs[6];
                break;
            case 3:
                images[10].sprite = sprs[6];
                break;
            case 4:
                images[11].sprite = sprs[6];
                break;
        }
    }
    public void ShieldOff(int num)
    {
        switch (num)
        {
            case 1:
                images[8].sprite = sprs[7];
                break;
            case 2:
                images[9].sprite = sprs[7];
                break;
            case 3:
                images[10].sprite = sprs[7];
                break;
            case 4:
                images[11].sprite = sprs[7];
                break;
        }
    }
    public void ChangeItem(int playerNum,int[] ItemList) 
    {
        switch (playerNum) 
        {
            case 0:
                items[0].sprite = SprItems[ItemList[0]];
                items[1].sprite = SprItems[ItemList[1]];
                break;
            case 1:
                items[2].sprite = SprItems[ItemList[0]];
                items[3].sprite = SprItems[ItemList[1]];
                break;
            case 2:
                items[5].sprite = SprItems[ItemList[0]];
                items[4].sprite = SprItems[ItemList[1]];
                break;
            case 3:
                items[7].sprite = SprItems[ItemList[0]];
                items[6].sprite = SprItems[ItemList[1]];
                break;
        }
    }
    void Update()
    {
        txt.text = Mathf.FloorToInt(gm.PlayTime / 60) + " : " + Mathf.FloorToInt(gm.PlayTime - Mathf.FloorToInt(gm.PlayTime / 60) * 60);
    }
    private void LateUpdate()
    {
        foreach (Image img in refresh)
        {
            img.SetNativeSize();
        }
    }
}