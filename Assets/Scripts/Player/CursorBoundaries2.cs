using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBoundaries2 : MonoBehaviour
{
    public Transform PlayerTrans;
    public int PlayerType;
    private bool initialed = false;
    void Update()
    {
        if (PlayerTrans != null)
        {
            if (!initialed)
            {
                Debug.Log("initialed");
                transform.position = Camera.main.WorldToScreenPoint(new Vector3(PlayerTrans.position.x + 10, PlayerTrans.position.y + 5));
                initialed = true;
            }
            switch (PlayerType)
            {
                case 0://Cannon
                    Vector3 viewPos = transform.position;
                    viewPos.x = Mathf.Clamp(viewPos.x, Camera.main.WorldToScreenPoint(new Vector3(PlayerTrans.position.x - 15, 0)).x, Camera.main.WorldToScreenPoint(new Vector3(PlayerTrans.position.x + 15, 0)).x);
                    viewPos.y = Mathf.Clamp(viewPos.y, Camera.main.WorldToScreenPoint(new Vector3(0, PlayerTrans.position.y - 15)).y, Camera.main.WorldToScreenPoint(new Vector3(0, PlayerTrans.position.y + 15)).y);
                    transform.position = viewPos;
                    break;
                case 1://Sniper
                    Vector3 viewPos2 = transform.position;
                    viewPos2.x = Mathf.Clamp(viewPos2.x, Camera.main.WorldToScreenPoint(new Vector3(PlayerTrans.position.x - 30, 0)).x, Camera.main.WorldToScreenPoint(new Vector3(PlayerTrans.position.x + 30, 0)).x);
                    viewPos2.y = Mathf.Clamp(viewPos2.y, Camera.main.WorldToScreenPoint(new Vector3(0, PlayerTrans.position.y - 30)).y, Camera.main.WorldToScreenPoint(new Vector3(0, PlayerTrans.position.y + 30)).y);
                    transform.position = viewPos2;
                    break;
                case 2://Normal
                    Vector3 viewPos3 = transform.position;
                    viewPos3.x = Mathf.Clamp(viewPos3.x, Camera.main.WorldToScreenPoint(new Vector3(PlayerTrans.position.x - 18, 0)).x, Camera.main.WorldToScreenPoint(new Vector3(PlayerTrans.position.x + 18, 0)).x);
                    viewPos3.y = Mathf.Clamp(viewPos3.y, Camera.main.WorldToScreenPoint(new Vector3(0, PlayerTrans.position.y - 18)).y, Camera.main.WorldToScreenPoint(new Vector3(0, PlayerTrans.position.y + 18)).y);
                    transform.position = viewPos3;
                    break;
                default:
                    break;
            }
        }
    }
}
