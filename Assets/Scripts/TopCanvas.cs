using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopCanvas : MonoBehaviour
{
    public GameObject ai1;
    public GameObject ai2;
    public GameObject ai3;
    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;
    public Sprite[] sprs;
    void Update()
    {

        if (ai1 == null)
        {
            image1.sprite = sprs[0];
        }
        if (ai2 == null)
        {
            image2.sprite = sprs[0];
        }
        if (ai3 == null)
        {
            image3.sprite = sprs[0];
        }
            switch (FindObjectOfType<GameManager>().BossType)
            { case 0:
                    image4.sprite = sprs[1];
                    break;
                case 1:
                    image4.sprite = sprs[2];
                    break;
                case 2:
                    image4.sprite = sprs[3];
                    break;
            }
        }
    }