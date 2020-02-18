using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //private GameObject player;
    public float BossTimer=20;
    private float bossTimer=0;
    public Vector3[] trans;
    public GameObject[] Players;
    public int playernum=1;
    public GameObject[] Bosss;
    public int BossType;
    public float ItemTimer = 3;
    private float itemTimer;
    public GameObject[] Items;
    //Todo：阵营参数
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
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        int sceneNum = SceneManager.GetActiveScene().buildIndex;
        if (sceneNum == 2) //战斗场景
        {
            //Boss刷新和道具刷新暂时移除！！！
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
                bossTimer += Time.deltaTime;
                if (bossTimer >= BossTimer) //Todo:Boss只有一个
                {
                    bossTimer = 0;
                    switch (Mathf.FloorToInt(Random.Range(0, 2)))
                    {
                        case 0:
                            Instantiate(Bosss[0], trans[Mathf.FloorToInt(Random.Range(0, 4))], Quaternion.identity);
                            BossType = 0;
                            break;
                        case 1:
                            Instantiate(Bosss[1], trans[Mathf.FloorToInt(Random.Range(0, 4))], Quaternion.identity);
                            BossType = 1;
                            break;
                        case 2:
                            Instantiate(Bosss[2], trans[Mathf.FloorToInt(Random.Range(0, 4))], Quaternion.identity);
                            BossType = 2;
                            break;
                        default:
                            break;
                    }
                }*/
            }

        }
    }
}

