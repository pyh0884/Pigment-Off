using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Intromenu : MonoBehaviour
{
    public int playerID = 0;
    private Player player;
    void Start()
    {
        Time.timeScale = 0;
    }
    public void Initial()
    {        
            FindObjectOfType<GameManager>().Initial(); 
    }

    void Update()
    {
        //todo:点击确定后运行Initial，删除scene2的InitialGM
        if (Input.anyKeyDown) 
        {
            Time.timeScale = 1;
            Initial();
            FindObjectOfType<FlagIn>().Unpaused = true;
            Destroy(FindObjectOfType<FlagIn>().gameObject, 1);
            Destroy(gameObject);
        }
    }
}
