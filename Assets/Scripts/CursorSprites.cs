using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorSprites : MonoBehaviour
{
    [HideInInspector]public GameManager gm;
    public Image[] images;
    public Sprite[] sprites;

    void Start()
    {

    }
    public void ChangeCursor()
    {
        switch (gm.player1) {
            case 1:
                images[0].sprite = sprites[0];
                break;
            case 2:
                images[0].sprite = sprites[1];
                break;
            case 3:
                images[0].sprite = sprites[2];
                break;
            case 4:
                images[0].sprite = sprites[3];
                break;
            case 5:
                images[0].sprite = sprites[4];
                break;
            case 6:
                images[0].sprite = sprites[5];
                break;
            default:
                images[0].sprite = sprites[6];
                break;
        }
        switch (gm.player2)
        {
            case 1:
                images[1].sprite = sprites[0];
                break;
            case 2:
                images[1].sprite = sprites[1];
                break;
            case 3:
                images[1].sprite = sprites[2];
                break;
            case 4:
                images[1].sprite = sprites[3];
                break;
            case 5:
                images[1].sprite = sprites[4];
                break;
            case 6:
                images[1].sprite = sprites[5];
                break;
            default:
                images[1].sprite = sprites[6];
                break;
        }
        if (gm.player3 != 0)
        {
            switch (gm.player3)
            {
                case 1:
                    images[2].sprite = sprites[0];
                    break;
                case 2:
                    images[2].sprite = sprites[1];
                    break;
                case 3:
                    images[2].sprite = sprites[2];
                    break;
                case 4:
                    images[2].sprite = sprites[3];
                    break;
                case 5:
                    images[2].sprite = sprites[4];
                    break;
                case 6:
                    images[2].sprite = sprites[5];
                    break;
                default:
                    images[2].sprite = sprites[6];
                    break;
            }
        }
        if (gm.player4 != 0)
        {
            switch (gm.player4)
            {
                case 1:
                    images[3].sprite = sprites[0];
                    break;
                case 2:
                    images[3].sprite = sprites[1];
                    break;
                case 3:
                    images[3].sprite = sprites[2];
                    break;
                case 4:
                    images[3].sprite = sprites[3];
                    break;
                case 5:
                    images[3].sprite = sprites[4];
                    break;
                case 6:
                    images[3].sprite = sprites[5];
                    break;
                default:
                    images[3].sprite = sprites[6];
                    break;
            }
        }
    }

    void Update()
    {
        
    }
}
