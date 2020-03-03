﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Rewired;

public class GameManager : MonoBehaviour
{
    #region parameters
    public int MenuMode = 0;
    public static GameManager instance;
    int sceneNum;
    public int player1 = 0;
    public int player1Life = 2;//剩余复活次数
    public float player1Time = 0;
    public GameObject cursor1;
    public int player1Camp = 0;
    public int player2 = 0;
    public int player2Life = 2;
    public float player2Time = 0;
    public GameObject cursor2;
    public int player2Camp = 1;
    public int player3 = 0;
    public int player3Life = 2;
    public float player3Time = 0;
    public GameObject cursor3;
    public int player3Camp = 2;
    public int player4 = 0;
    public int player4Life = 2;
    public float player4Time = 0;
    public GameObject cursor4;
    public int player4Camp = 2;
    public Vector3[] trans;//boss刷新位置
    public GameObject[] Players;
    public Vector3[] PlayerTrans;
    public int playernum=1;//ChooseMenu
    public GameObject[] Bosss;
    public int BossType;
    private Player Player1;
    private Player Player2;
    private Player Player3;
    private Player Player4;
    public GameObject pauseMenu;
    public bool paused = false;
    public float PlayTime = 180;
    public int WinnerNum = 1;
    public float WinnerTime = 0;
    //public float ItemTimer = 3;
    //private float itemTimer;
    //public GameObject[] Items;
    #endregion    
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "__Main Menu")
            Destroy(gameObject);

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    public void Initial()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        PlayTime = 180;
        player1Time = 0;
        player2Time = 0;
        player3Time = 0;
        player4Time = 0;
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("GameManagerInitialed");
        Player1 = ReInput.players.GetPlayer(0);
        Player2 = ReInput.players.GetPlayer(1);
        if (player3 != 0) 
        Player3 = ReInput.players.GetPlayer(2);
        if (player4 != 0) 
        Player4 = ReInput.players.GetPlayer(3);
        StartInsBoss = false;
        if (sceneNum == 1) //选人场景 2 Players
        {
            player1Camp = 0;
            player2Camp = 1;
            player3 = 0;
            player3Camp = 2;
            player4 = 0;
            player4Camp = 2;
        }
        if (sceneNum == 2) //选人场景 3 Players
        {
            player1Camp = 0;
            player2Camp = 1;
            player3Camp = 2;
            player4 = 0;
            player4Camp = 2;
        }
        if (sceneNum == 3) //选人场景 4 Players
        {
            player1Camp = 0;
            player2Camp = 0;
            player3Camp = 1;
            player4Camp = 1;
        }
        if (sceneNum == 4) //战斗场景
        {
            StartCoroutine("InsBoss1");
            if (player1 != 0)
            {
                cursor1.SetActive(true);
                var p1 = Instantiate(Players[player1], PlayerTrans[0], Quaternion.identity);
                p1.GetComponentInChildren<PlayerMovement>().playerID = 0;
                p1.GetComponentInChildren<Attack>().playerID = 0;
                p1.GetComponentInChildren<Attack>().Camp = player1Camp;
                p1.GetComponentInChildren<PlayerMovement>().cursor = cursor1.transform;
                p1.GetComponentInChildren<Attack>().cursor = cursor1.transform;
                p1.GetComponentInChildren<HeadControl>().cursor = cursor1.transform;
                p1.GetComponentInChildren<HealthBar>().slider = GameObject.FindGameObjectWithTag("Slider1").GetComponent<Slider>();
            }

            if (player2 != 0)
            {
                cursor2.SetActive(true);
                var p2 = Instantiate(Players[player2], PlayerTrans[1], Quaternion.identity);
                p2.GetComponentInChildren<PlayerMovement>().playerID = 1;
                p2.GetComponentInChildren<Attack>().playerID = 1;
                p2.GetComponentInChildren<Attack>().Camp = player2Camp;
                p2.GetComponentInChildren<PlayerMovement>().cursor = cursor2.transform;
                p2.GetComponentInChildren<Attack>().cursor = cursor2.transform;
                p2.GetComponentInChildren<HeadControl>().cursor = cursor2.transform;
                p2.GetComponentInChildren<HealthBar>().slider = GameObject.FindGameObjectWithTag("Slider2").GetComponent<Slider>();
            }

            if (player3 != 0)
            {
                cursor3.SetActive(true);
                var p3 = Instantiate(Players[player3], PlayerTrans[2], Quaternion.identity);
                p3.GetComponentInChildren<PlayerMovement>().playerID = 2;
                p3.GetComponentInChildren<Attack>().playerID = 2;
                p3.GetComponentInChildren<Attack>().Camp = player3Camp;
                p3.GetComponentInChildren<PlayerMovement>().cursor = cursor3.transform;
                p3.GetComponentInChildren<Attack>().cursor = cursor3.transform;
                p3.GetComponentInChildren<HeadControl>().cursor = cursor3.transform;
                p3.GetComponentInChildren<HealthBar>().slider = GameObject.FindGameObjectWithTag("Slider3").GetComponent<Slider>();
            }

            if (player4 != 0)
            {
                cursor4.SetActive(true);
                var p4 = Instantiate(Players[player4], PlayerTrans[3], Quaternion.identity);
                p4.GetComponentInChildren<PlayerMovement>().playerID = 3;
                p4.GetComponentInChildren<Attack>().playerID = 3;
                p4.GetComponentInChildren<Attack>().Camp = player4Camp;
                p4.GetComponentInChildren<PlayerMovement>().cursor = cursor4.transform;
                p4.GetComponentInChildren<Attack>().cursor = cursor4.transform;
                p4.GetComponentInChildren<HeadControl>().cursor = cursor4.transform;
                p4.GetComponentInChildren<HealthBar>().slider = GameObject.FindGameObjectWithTag("Slider4").GetComponent<Slider>();
            }
        }

    }
    public void Respawn(int number)
    {
        StartCoroutine(Res(number, 3));
    }
    IEnumerator Res(int num,int resTime)
    {
        switch (num) 
        {
            case 1:
                yield return new WaitForSeconds(resTime);
                player1Life--;
                if (player1Life >= 0)
                {
                    var p1 = Instantiate(Players[player1], PlayerTrans[0], Quaternion.identity);
                    if (player1 != 0)
                    {
                        p1.GetComponentInChildren<PlayerMovement>().playerID = 0;
                        p1.GetComponentInChildren<Attack>().playerID = 0;
                        p1.GetComponentInChildren<Attack>().Camp = player1Camp;
                        p1.GetComponentInChildren<PlayerMovement>().cursor = cursor1.transform;
                        p1.GetComponentInChildren<Attack>().cursor = cursor1.transform;
                        p1.GetComponentInChildren<HeadControl>().cursor = cursor1.transform;
                        p1.GetComponentInChildren<HealthBar>().slider = GameObject.FindGameObjectWithTag("Slider1").GetComponent<Slider>();
                    }
                }
                else
                {
                    cursor1.SetActive(false);
                }
                break;
            case 2:
                yield return new WaitForSeconds(resTime);
                player2Life--;
                if (player2Life >= 0)
                {
                    var p2 = Instantiate(Players[player2], PlayerTrans[1], Quaternion.identity);
                    if (player2 != 0)
                    {
                        p2.GetComponentInChildren<PlayerMovement>().playerID = 1;
                        p2.GetComponentInChildren<Attack>().playerID = 1;
                        p2.GetComponentInChildren<Attack>().Camp = player2Camp;
                        p2.GetComponentInChildren<PlayerMovement>().cursor = cursor2.transform;
                        p2.GetComponentInChildren<Attack>().cursor = cursor2.transform;
                        p2.GetComponentInChildren<HeadControl>().cursor = cursor2.transform;
                        p2.GetComponentInChildren<HealthBar>().slider = GameObject.FindGameObjectWithTag("Slider2").GetComponent<Slider>();
                    }
                }
                else
                {
                    cursor2.SetActive(false);
                }
                break;
            case 3:
                yield return new WaitForSeconds(resTime);
                player3Life--;
                if (player3Life >= 0)
                {
                    var p3 = Instantiate(Players[player3], PlayerTrans[2], Quaternion.identity);
                    if (player3 != 0)
                    {
                        p3.GetComponentInChildren<PlayerMovement>().playerID = 2;
                        p3.GetComponentInChildren<Attack>().playerID = 2;
                        p3.GetComponentInChildren<Attack>().Camp = player3Camp;
                        p3.GetComponentInChildren<PlayerMovement>().cursor = cursor3.transform;
                        p3.GetComponentInChildren<Attack>().cursor = cursor3.transform;
                        p3.GetComponentInChildren<HeadControl>().cursor = cursor3.transform;
                        p3.GetComponentInChildren<HealthBar>().slider = GameObject.FindGameObjectWithTag("Slider3").GetComponent<Slider>();
                    }
                }
                else
                {
                    cursor3.SetActive(false);
                }
                break;
            case 4:
                yield return new WaitForSeconds(resTime);
                player4Life--;
                if (player4Life >= 0)
                {
                    var p4 = Instantiate(Players[player4], PlayerTrans[3], Quaternion.identity);
                    if (player4 != 0)
                    {
                        p4.GetComponentInChildren<PlayerMovement>().playerID = 3;
                        p4.GetComponentInChildren<Attack>().playerID = 3;
                        p4.GetComponentInChildren<Attack>().Camp = player4Camp;
                        p4.GetComponentInChildren<PlayerMovement>().cursor = cursor4.transform;
                        p4.GetComponentInChildren<Attack>().cursor = cursor4.transform;
                        p4.GetComponentInChildren<HeadControl>().cursor = cursor4.transform;
                        p4.GetComponentInChildren<HealthBar>().slider = GameObject.FindGameObjectWithTag("Slider4").GetComponent<Slider>();
                    }
                }
                else 
                {
                    cursor4.SetActive(false);
                }
                break;
        }
    }
    #region Boss Instantiate
    bool StartInsBoss = false;
    IEnumerator InsBoss1() //150s后在随机位置生成boss2
    {
        yield return new WaitForSeconds(150);
        StartInsBoss = true;
    }
    public void insBoss2() 
    {
        StartCoroutine("InsBoss2");
    }
    IEnumerator InsBoss2() //20s后在随机位置生成boss2
    {
        yield return new WaitForSeconds(20);
        Instantiate(Bosss[1], trans[Mathf.FloorToInt(Random.Range(0, 4))], Quaternion.identity);
    }
    public void insMonster()
    {
        Instantiate(Bosss[2], trans[Mathf.FloorToInt(Random.Range(0, 4))], Quaternion.identity);
        Instantiate(Bosss[2], trans[Mathf.FloorToInt(Random.Range(0, 4))], Quaternion.identity);
    }

    #endregion
    public void selfDes() 
    {
        Destroy(gameObject);
    }
    public void Pause() 
    {
        Debug.Log("Paused");
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        paused = true;
    }
    public void UnPause() 
    {
        Debug.Log("Unpaused");
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        paused = false;
    }
    private void Update()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        if (sceneNum == 4) //战斗场景
        {
            PlayTime -= Time.deltaTime;//倒计时
            #region Pause Menu
            if ((Player1.GetButtonDown("Menu")|| Player2.GetButtonDown("Menu")|| Player3.GetButtonDown("Menu")|| Player4.GetButtonDown("Menu")) && !paused) 
            {
                Pause();
            }
            else if ((Player1.GetButtonDown("Menu") || Player2.GetButtonDown("Menu") || Player3.GetButtonDown("Menu") || Player4.GetButtonDown("Menu")) && paused)
            {
                UnPause();
            }
            #endregion
            if (StartInsBoss) 
            {
                Instantiate(Bosss[0], trans[Mathf.FloorToInt(Random.Range(0, 4))], Quaternion.identity);
                StartInsBoss = false;
            }//生成Boss
            //道具刷新暂时移除！！！
            {
                /*
                itemTimer += Time.deltaTime;
                if (itemTimer >= ItemTimer)
                {
                    itemTimer = 0;
                    if (Random.Range(0, 100) > 50)
                        Instantiate(Items[0], new Vector3(Random.Range(-30, 30), Random.Range(-15, 15), 0), Quaternion.identity);
                    else
                    {
                        Instantiate(Items[1], new Vector3(Random.Range(-30, 30), Random.Range(-15, 15), 0), Quaternion.identity);
                    }
                }
                }*/
            }
            if (PlayTime <= 0)//游戏结束
            {
                if (player4Camp == 1)//组队模式
                {
                    if (player1Time + player2Time >= player3Time + player4Time)
                    {
                        if (player1Time >= player2Time)
                        {
                               WinnerNum = player1;
                        }
                        else
                        {
                            
                            WinnerNum = player2;
                        }
                        WinnerTime = player1Time + player2Time;
                        Debug.Log("Camp 0 胜利 黄色");                        
                    }
                    else
                    {
                        if (player3Time >= player4Time)
                        {
                            WinnerNum = player3;
                        }
                        else
                        {
                            WinnerNum = player4;
                        }
                        WinnerTime = player3Time + player4Time;
                        Debug.Log("Camp 1 胜利 紫色");
                    }

                }
                else if (player4Camp == 2) //乱斗模式
                {
                    if (player3 != 0)//三人乱斗 
                    {
                        if (player1Time >= player2Time && player1Time >= player3Time)
                        {
                            WinnerTime = player1Time;
                            WinnerNum = player1;
                            Debug.Log("Camp 0 胜利 黄色");
                        }
                        else if (player2Time >= player1Time && player2Time >= player3Time)
                        {
                            WinnerTime = player2Time;
                            WinnerNum = player2;
                            Debug.Log("Camp 1 胜利 紫色");
                        }
                        else
                        {
                            WinnerTime = player3Time;
                            WinnerNum = player3;
                            Debug.Log("Camp 2 胜利 蓝色");
                        }
                    }
                    else if (player1 != 0 && player2 != 0) //双人乱斗
                    {
                        if (player1Time >= player2Time)
                        {
                            WinnerTime = player1Time;
                            WinnerNum = player1;
                            Debug.Log("Camp 0 胜利 黄色");
                        }
                        else 
                        {
                            WinnerTime = player2Time;
                            WinnerNum = player2;
                            Debug.Log("Camp 1 胜利 紫色");
                        }
                    }
                }
            }
        }
    }
}

