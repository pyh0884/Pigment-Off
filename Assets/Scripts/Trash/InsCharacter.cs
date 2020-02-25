using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsCharacter : MonoBehaviour
{
    public LayerMask player;
    public GameObject[] characters;
    public void Ins(int num) 
    {if (num <= 1 || num == 8) 
        {
            Instantiate(characters[num], new Vector3(0, 0, 0), Quaternion.identity);
        }
        else 
        {
            Collider2D[] list = Physics2D.OverlapCircleAll(new Vector2(0,0), 100, player);
            foreach (Collider2D col in list)
            {
                if (col.gameObject.layer == 12) 
                {
                    Destroy(col.gameObject);
                }
            }

            Instantiate(characters[num], new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
