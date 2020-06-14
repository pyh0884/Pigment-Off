using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Intromenu : MonoBehaviour
{
    public GameObject[] objs;
    private float timer = 0;
    bool loading = true;
    bool start = false;
    public int playerID = 0;//0-3
    private Player player;
    private Player player2;
    int currentNum = 0;
    bool m_isAxisInUse = false;
    public AudioSource[] audios;
    void Start()
    {
        player = ReInput.players.GetPlayer(1);
        player2 = ReInput.players.GetPlayer(0);
        Time.timeScale = 0;
    }
    public void Initial()
    {        
            FindObjectOfType<GameManager>().Initial(); 
    }
    void Update()
    {
        timer += Time.fixedDeltaTime;
        if (timer > 2 && loading)
        {
            loading = false;
            Destroy(objs[0]);
            objs[1].SetActive(true);
        }
        if (timer > 2 && !start && Input.anyKey) 
        {
            if (FindObjectOfType<MenuBGM>())
            Destroy(FindObjectOfType<MenuBGM>().gameObject);
            audios[0].Play();
            start = true;
            Destroy(objs[2]);
        }
        if (timer > 2 && start) 
        {
            if (currentNum == 3 && (player.GetButtonDown("Confirm")|| player2.GetButtonDown("Confirm")))
            {
                Time.timeScale = 1;
                audios[1].Play();
                Initial();
                FindObjectOfType<FlagIn>().Unpaused = true;
                Destroy(FindObjectOfType<FlagIn>().gameObject, 1);
                Destroy(gameObject);
            }

            if ((player.GetAxisRaw("MoveHorizontal") < 0|| player2.GetAxisRaw("MoveHorizontal") < 0) && !m_isAxisInUse)
            {
                m_isAxisInUse = true;
                currentNum = Mathf.Clamp(currentNum - 1, 0, 3);
                switch (currentNum)
                {
                    case 0:
                        objs[3].SetActive(true);
                        objs[4].SetActive(false);
                        objs[5].SetActive(false);
                        objs[6].SetActive(false);
                        break;
                    case 1:
                        objs[3].SetActive(false);
                        objs[4].SetActive(true);
                        objs[5].SetActive(false);
                        objs[6].SetActive(false);
                        break;
                    case 2:
                        objs[3].SetActive(false);
                        objs[4].SetActive(false);
                        objs[5].SetActive(true);
                        objs[6].SetActive(false);
                        break;
                    case 3:
                        objs[3].SetActive(false);
                        objs[4].SetActive(false);
                        objs[5].SetActive(false);
                        objs[6].SetActive(true);
                        break;
                    default:
                        break;
                }
            }
            if (player.GetAxisRaw("MoveHorizontal") == 0&& player2.GetAxisRaw("MoveHorizontal") == 0)
            {
                m_isAxisInUse = false;
            }
            if ((player.GetAxisRaw("MoveHorizontal") > 0 || (player.GetButtonDown("Confirm")|| player2.GetAxisRaw("MoveHorizontal") > 0 || player2.GetButtonDown("Confirm")) && currentNum < 3) && !m_isAxisInUse)
            {
                m_isAxisInUse = true;
                currentNum = Mathf.Clamp(currentNum + 1, 0, 3);
                switch (currentNum)
                {
                    case 0:
                        objs[3].SetActive(true);
                        objs[4].SetActive(false);
                        objs[5].SetActive(false);
                        objs[6].SetActive(false);
                        break;
                    case 1:
                        objs[3].SetActive(false);
                        objs[4].SetActive(true);
                        objs[5].SetActive(false);
                        objs[6].SetActive(false);
                        break;
                    case 2:
                        objs[3].SetActive(false);
                        objs[4].SetActive(false);
                        objs[5].SetActive(true);
                        objs[6].SetActive(false);
                        break;
                    case 3:
                        objs[3].SetActive(false);
                        objs[4].SetActive(false);
                        objs[5].SetActive(false);
                        objs[6].SetActive(true);
                        break;
                    default:
                        break;
                }
            }
            if (player.GetAxisRaw("MoveHorizontal") == 0&& player2.GetAxisRaw("MoveHorizontal") == 0)
            {
                m_isAxisInUse = false;
            }
        }
    }
}
