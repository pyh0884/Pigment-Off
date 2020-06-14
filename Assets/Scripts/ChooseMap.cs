using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseMap : Trans
{
    public bool locked;
    public GameManager gm;
    public int playerID = 0;//0-3
    private Player player;
    public int MapNum = 0;
    public GameObject pauseMenu;
    public bool paused;
    public AudioSource Click;
    public GameObject LeftCheck;
    public GameObject RightCheck;
    public GameObject LeftLock;
    public GameObject RightLock;
    public Image[] imgs;
    void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (MapNum == 0)
        {
            LeftCheck.SetActive(true);
            RightCheck.SetActive(false);
        }
        else
        {
            LeftCheck.SetActive(false);
            RightCheck.SetActive(true);
        }
        #region Input
        if (player.GetButtonDown("MoveLeft") && !locked && !paused)
        {
            Click.Play();
            if (MapNum == 0)
                MapNum = 1;
            else MapNum = 0;
        }
        if (player.GetButtonDown("MoveRight") && !locked && !paused)
        {
            Click.Play();
            if (MapNum == 0)
                MapNum = 1;
            else MapNum = 0;
        }
        if (player.GetButtonLongPress("MoveLeft") && !locked && !paused)
        {
            Click.Play();
            if (MapNum == 0)
                MapNum = 1;
            else MapNum = 0;
        }
        if (player.GetButtonLongPress("MoveRight") && !locked && !paused)
        {
            Click.Play();
            if (MapNum == 0)
                MapNum = 1;
            else MapNum = 0;
        }
        if (player.GetButtonDown("Confirm") && !locked && !paused)
        {
            Click.Play();
            locked = true;
            if (MapNum == 0)
            {
                LeftLock.SetActive(true);
                RightLock.SetActive(false);
            }
            else
            {
                LeftLock.SetActive(false);
                RightLock.SetActive(true);
            }
        }
        if (player.GetButtonDown("Cancel") && locked && !paused)
        {
            Click.Play();
            locked = false;
            LeftLock.SetActive(false);
            RightLock.SetActive(false);
        }
        else if (player.GetButtonDown("Cancel") && !locked && !paused)
        {
            Click.Play();
            pauseMenu.SetActive(true);
            paused = true;
        }
        else if (paused)
        {
            if (player.GetButtonDown("Cancel"))
            {
                paused = false;
                pauseMenu.SetActive(false);
            }
            else if (player.GetButton("Confirm"))
            {
                QuickLoad(0);
            }

        }
        if (player.GetButton("Start") && locked && !paused)
        {
            Click.Play();
            if (MapNum == 0)
            {
                QuickLoad(4);
            }
            else
            {
                QuickLoad(5);
            }
        }
        #endregion
    }
    private void LateUpdate()
    {
        if (imgs.Length != 0)
        {
            foreach (Image img in imgs)
            {
                img.SetNativeSize();
            }
        }
    }
}
