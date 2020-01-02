using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float CurrentHp;
    public float HpCapacity;
    public int CurrentDMG;
    public float CritPos;
    //public Vector3 spawnPos;
    public float HorizontalSpeed;
    private GameObject player;
    private void Awake()
    {

        if (SceneManager.GetActiveScene().name == "__Main Menu")   //TODO:Scene name
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
    public float HP
    {
        get
        {
            return CurrentHp;
        }
    }
    public float CRIT
    {
        get
        {
            return CritPos;
        }
    }

    public float MAXHP
    {
        get
        {
            return HpCapacity;
        }
    }
    public int DAMAGE
    {
        get
        {
            return CurrentDMG;
        }
    }
    public void increaseATK(int ATK)
    {
        CurrentDMG += ATK;
    }

    public void increaseCrit(int CRIT)
    {
        CritPos += CRIT;
    }
    void Start()
    {
        CurrentHp = HpCapacity;
        //HorizontalSpeed = 7.75f;
        //HpCapacity = PlayerPrefs.GetInt("MAXHP", 150);
    }
    //public void Respawn()
    //{
    //    int index = 17;
    //    /*		if(SceneManager.GetActiveScene().buildIndex!=index)*/
    //    SceneManager.LoadScene(index);
    //    CurrentHp = HpCapacity;
    //}
    private void Update()
    {
        int sceneNum = SceneManager.GetActiveScene().buildIndex;
        //if (player == null && sceneNum != 0 && sceneNum != 1 && sceneNum != 2 && sceneNum != 7 && sceneNum != 10 && sceneNum != 13 && sceneNum != 15 && sceneNum != 16 && sceneNum != 17)
        //{
        //    player = Instantiate(playerPrefab, spawnPos, new Quaternion());
        //}
        //if (player)
        //{
        //    CurrentHp = player.GetComponent<HealthBar>().Hp;
        //}
        //HpCapacity = player.GetComponent<HealthBarControl>().HpMax;
    }
}

