using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;
using UnityEngine.SceneManagement;


public class ChooseMenu : MonoBehaviour
{
    public bool locked;
    public float adderNum;
    public int sceneNum;
    [HideInInspector] public int lockedNum = 0;
    public ChooseMenu[] cm;
    //public Image[] CharacterBack;//背景
    //public Image[] CharacterIcon;//角色头像
    public Image CharacterName;//背景黄色部分
    public Image CharacterInfo;//角色属性介绍
    public Image PlayerFront;//角色小图
    public Image PlayerBack;//角色大图    
    public Image Lock;
    //public Sprite[] SprCharacterBack;
    //public Sprite[] SprCharacterIcon;
    public Sprite[] SprPlayerFront;
    public Sprite[] SprName;
    public Sprite[] SprPlayersBack;
    public Sprite[] SprInfo;
    //public GameObject[] LowerIcon;//下，P1P2P3P4标识
    public GameManager gm;
    public int playerID = 10;//0-3
    private Player player;
    public int currentNum;//1-6
    public GameObject pauseMenu;
    public bool paused;
    public AudioSource Click;

    void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
        gm = FindObjectOfType<GameManager>();
    }
    //void CloseUI(int num)
    //{
    //    switch (sceneNum)//todo:修改不同场景的sceneNum，为游戏人数
    //    {
    //        case 4:
    //            if (cm[0].currentNum == num || cm[1].currentNum == num || cm[2].currentNum == num)
    //                return;
    //            break;
    //        case 3:
    //            if (cm[0].currentNum == num || cm[1].currentNum == num)
    //                return;
    //            break;
    //        case 2:
    //            if (cm[0].currentNum == num)
    //                return;
    //            break;
    //    }
    //    switch (num)
    //    {
    //        case 1:
    //            CharacterBack[0].sprite = SprCharacterBack[0];
    //            CharacterBack[0].SetNativeSize();
    //            CharacterIcon[0].sprite = SprCharacterIcon[0];
    //            CharacterIcon[0].SetNativeSize();
    //            //LowerIcon[0].sprite=?? todo
    //            break;
    //        case 2:
    //            CharacterBack[2].sprite = SprCharacterBack[2];
    //            CharacterBack[2].SetNativeSize();
    //            CharacterIcon[2].sprite = SprCharacterIcon[2];
    //            CharacterIcon[2].SetNativeSize();
    //            //LowerIcon[0].sprite=??
    //            break;
    //        case 3:
    //            CharacterBack[4].sprite = SprCharacterBack[4];
    //            CharacterBack[4].SetNativeSize();
    //            CharacterIcon[4].sprite = SprCharacterIcon[4];
    //            CharacterIcon[4].SetNativeSize();
    //            //LowerIcon[0].sprite=??
    //            break;
    //        case 4:
    //            CharacterBack[3].sprite = SprCharacterBack[3];
    //            CharacterBack[3].SetNativeSize();
    //            CharacterIcon[3].sprite = SprCharacterIcon[3];
    //            CharacterIcon[3].SetNativeSize();
    //            //LowerIcon[0].sprite=??
    //            break;
    //        case 5:
    //            CharacterBack[5].sprite = SprCharacterBack[5];
    //            CharacterBack[5].SetNativeSize();
    //            CharacterIcon[5].sprite = SprCharacterIcon[5];
    //            CharacterIcon[5].SetNativeSize();
    //            //LowerIcon[0].sprite=??
    //            break;
    //        case 6:
    //            CharacterBack[1].sprite = SprCharacterBack[1];
    //            CharacterBack[1].SetNativeSize();
    //            CharacterIcon[1].sprite = SprCharacterIcon[1];
    //            CharacterIcon[1].SetNativeSize();
    //            //LowerIcon[0].sprite=??
    //            break;

    //    }
    //}
    void ChangeSelectBack()
    {
        switch (currentNum)
        {
            case 1:
                PlayerFront.sprite = SprPlayerFront[0];
                PlayerBack.sprite = SprPlayersBack[0];
                CharacterName.sprite = SprName[0];
                CharacterInfo.sprite = SprInfo[0];
                PlayerFront.SetNativeSize();
                PlayerBack.SetNativeSize();
                break;
            case 2:
                PlayerFront.sprite = SprPlayerFront[1];
                PlayerBack.sprite = SprPlayersBack[1];
                CharacterName.sprite = SprName[1];
                CharacterInfo.sprite = SprInfo[1];
                PlayerFront.SetNativeSize();
                PlayerBack.SetNativeSize();
                break;
            case 3:
                PlayerFront.sprite = SprPlayerFront[2];
                PlayerBack.sprite = SprPlayersBack[2];
                CharacterName.sprite = SprName[2];
                CharacterInfo.sprite = SprInfo[2];
                PlayerFront.SetNativeSize();
                PlayerBack.SetNativeSize();
                break;
            case 4:
                PlayerFront.sprite = SprPlayerFront[3];
                PlayerBack.sprite = SprPlayersBack[3];
                CharacterName.sprite = SprName[3];
                CharacterInfo.sprite = SprInfo[3];
                PlayerFront.SetNativeSize();
                PlayerBack.SetNativeSize();
                break;
            case 5:
                PlayerFront.sprite = SprPlayerFront[4];
                PlayerBack.sprite = SprPlayersBack[4];
                CharacterName.sprite = SprName[4];
                CharacterInfo.sprite = SprInfo[4];
                PlayerFront.SetNativeSize();
                PlayerBack.SetNativeSize();
                break;
            case 6:
                PlayerFront.sprite = SprPlayerFront[5];
                PlayerBack.sprite = SprPlayersBack[5];
                CharacterName.sprite = SprName[5];
                CharacterInfo.sprite = SprInfo[5];
                PlayerFront.SetNativeSize();
                PlayerBack.SetNativeSize();
                break;
        }
    }
    //void KeepOpen()
    //{
    //    switch (currentNum)
    //    {
    //        case 1:
    //            CharacterBack[0].sprite = SprCharacterBack[6];
    //            CharacterBack[0].SetNativeSize();
    //            CharacterIcon[0].sprite = SprCharacterIcon[6];
    //            CharacterIcon[0].SetNativeSize();
    //            break;
    //        case 2:
    //            CharacterBack[2].sprite = SprCharacterBack[8];
    //            CharacterBack[2].SetNativeSize();
    //            CharacterIcon[2].sprite = SprCharacterIcon[8];
    //            CharacterIcon[2].SetNativeSize();
    //            break;
    //        case 3:
    //            CharacterBack[4].sprite = SprCharacterBack[10];
    //            CharacterBack[4].SetNativeSize();
    //            CharacterIcon[4].sprite = SprCharacterIcon[10];
    //            CharacterIcon[4].SetNativeSize();
    //            break;
    //        case 4:
    //            CharacterBack[3].sprite = SprCharacterBack[9];
    //            CharacterBack[3].SetNativeSize();
    //            CharacterIcon[3].sprite = SprCharacterIcon[9];
    //            CharacterIcon[3].SetNativeSize();
    //            break;
    //        case 5:
    //            CharacterBack[5].sprite = SprCharacterBack[11];
    //            CharacterBack[5].SetNativeSize();
    //            CharacterIcon[5].sprite = SprCharacterIcon[11];
    //            CharacterIcon[5].SetNativeSize();
    //            break;
    //        case 6:
    //            CharacterBack[1].sprite = SprCharacterBack[7];
    //            CharacterBack[1].SetNativeSize();
    //            CharacterIcon[1].sprite = SprCharacterIcon[7];
    //            CharacterIcon[1].SetNativeSize();
    //            break;
    //    }
    //}
    //void ChangeUI()
    //{
    //    switch (currentNum)
    //    {
    //        case 1:
    //            CharacterBack[0].sprite = SprCharacterBack[6];
    //            CharacterBack[0].SetNativeSize();
    //            CharacterIcon[0].sprite = SprCharacterIcon[6];
    //            CharacterIcon[0].SetNativeSize();
    //            Players.sprite = SprPlayers[0];
    //            Players.SetNativeSize();
    //            //LowerIcon[0].sprite=?? todo
    //            break;
    //        case 2:
    //            CharacterBack[2].sprite = SprCharacterBack[8];
    //            CharacterBack[2].SetNativeSize();
    //            CharacterIcon[2].sprite = SprCharacterIcon[8];
    //            CharacterIcon[2].SetNativeSize();
    //            Players.sprite = SprPlayers[2];
    //            Players.SetNativeSize();
    //            //LowerIcon[0].sprite=??
    //            break;
    //        case 3:
    //            CharacterBack[4].sprite = SprCharacterBack[10];
    //            CharacterBack[4].SetNativeSize();
    //            CharacterIcon[4].sprite = SprCharacterIcon[10];
    //            CharacterIcon[4].SetNativeSize();
    //            Players.sprite = SprPlayers[4];
    //            Players.SetNativeSize();
    //            //LowerIcon[0].sprite=??
    //            break;
    //        case 4:
    //            CharacterBack[3].sprite = SprCharacterBack[9];
    //            CharacterBack[3].SetNativeSize();
    //            CharacterIcon[3].sprite = SprCharacterIcon[9];
    //            CharacterIcon[3].SetNativeSize();
    //            Players.sprite = SprPlayers[3];
    //            Players.SetNativeSize();
    //            //LowerIcon[0].sprite=??
    //            break;
    //        case 5:
    //            CharacterBack[5].sprite = SprCharacterBack[11];
    //            CharacterBack[5].SetNativeSize();
    //            CharacterIcon[5].sprite = SprCharacterIcon[11];
    //            CharacterIcon[5].SetNativeSize();
    //            Players.sprite = SprPlayers[5];
    //            Players.SetNativeSize();
    //            //LowerIcon[0].sprite=??
    //            break;
    //        case 6:
    //            CharacterBack[1].sprite = SprCharacterBack[7];
    //            CharacterBack[1].SetNativeSize();
    //            CharacterIcon[1].sprite = SprCharacterIcon[7];
    //            CharacterIcon[1].SetNativeSize();
    //            Players.sprite = SprPlayers[1];
    //            Players.SetNativeSize();
    //            //LowerIcon[0].sprite=??
    //            break;
    //    }
    //}
    void LockIn()
    {
        switch (currentNum)
        {
            case 1:
                //SelectBack.sprite = SprSelectBack[1];
                switch (playerID) {
                    case 0:
                        gm.player1 = 1;
                        break;
                    case 1:
                        gm.player2 = 1;
                        break;
                    case 2:
                        gm.player3 = 1;
                        break;
                    case 3:
                        gm.player4 = 1;
                        break;
                }
                break;
            case 2:
                //SelectBack.sprite = SprSelectBack[3];
                switch (playerID)
                {
                    case 0:
                        gm.player1 = 2;
                        break;
                    case 1:
                        gm.player2 = 2;
                        break;
                    case 2:
                        gm.player3 = 2;
                        break;
                    case 3:
                        gm.player4 = 2;
                        break;
                }
                break;
            case 3:
                //SelectBack.sprite = SprSelectBack[5];
                switch (playerID)
                {
                    case 0:
                        gm.player1 = 3;
                        break;
                    case 1:
                        gm.player2 = 3;
                        break;
                    case 2:
                        gm.player3 = 3;
                        break;
                    case 3:
                        gm.player4 = 3;
                        break;
                }
                break;
            case 4:
                //SelectBack.sprite = SprSelectBack[4];
                switch (playerID)
                {
                    case 0:
                        gm.player1 = 4;
                        break;
                    case 1:
                        gm.player2 = 4;
                        break;
                    case 2:
                        gm.player3 = 4;
                        break;
                    case 3:
                        gm.player4 = 4;
                        break;
                }
                break;
            case 5:
                //SelectBack.sprite = SprSelectBack[6];
                switch (playerID)
                {
                    case 0:
                        gm.player1 = 5;
                        break;
                    case 1:
                        gm.player2 = 5;
                        break;
                    case 2:
                        gm.player3 = 5;
                        break;
                    case 3:
                        gm.player4 = 5;
                        break;
                }
                break;
            case 6:
                //SelectBack.sprite = SprSelectBack[2];
                switch (playerID)
                {
                    case 0:
                        gm.player1 = 6;
                        break;
                    case 1:
                        gm.player2 = 6;
                        break;
                    case 2:
                        gm.player3 = 6;
                        break;
                    case 3:
                        gm.player4 = 6;
                        break;
                }
                break;
        }
    }
    public void MoveLeft()
    {
        //CloseUI(currentNum);
        currentNum--;
        if (currentNum < 1)
        {
            currentNum = 6;
        }
        //ChangeUI();
    }
    public void MoveRight()
    {
        //CloseUI(currentNum);
        currentNum++;
        if (currentNum > 6)
        {
            currentNum = 1;
        }
        //ChangeUI();
    }
    public void MoveLeft2()
    {
        //CloseUI(currentNum);
        currentNum--;
        if (currentNum < 1)
        {
            currentNum = 6;
        }
        currentNum--;
        if (currentNum < 1)
        {
            currentNum = 6;
        }
        //ChangeUI();
    }
    public void MoveRight2()
    {
        //CloseUI(currentNum);
        currentNum++;
        if (currentNum > 6)
        {
            currentNum = 1;
        }
        currentNum++;
        if (currentNum > 6)
        {
            currentNum = 1;
        }
        //ChangeUI();
    }
    bool CheckLockable()
    {
        switch (sceneNum)
        {
            case 4:
                if (cm[0].lockedNum == currentNum || cm[1].lockedNum == currentNum || cm[2].lockedNum == currentNum)
                    return false;
                break;
            case 3:
                if (cm[0].lockedNum == currentNum || cm[1].lockedNum == currentNum)
                    return false;
                break;
            case 2:
                if (cm[0].lockedNum == currentNum)
                    return false;
                break;
        }
        return true;
    }
    bool CheckRightMovable()
    {
        var num = currentNum + 1;
        if (num > 6) num = 1;
        switch (sceneNum)
        {
            case 4:
                if (cm[0].lockedNum == num || cm[1].lockedNum == num || cm[2].lockedNum == num)
                    return false;
                break;
            case 3:
                if (cm[0].lockedNum == num || cm[1].lockedNum == num)
                    return false;
                break;
            case 2:
                if (cm[0].lockedNum == num)
                    return false;
                break;
        }
        return true;
    }
    bool CheckLeftMovable()
    {
        var num = currentNum - 1;
        if (num < 1) num = 6;
        switch (sceneNum)
        {
            case 4:
                if (cm[0].lockedNum == num || cm[1].lockedNum == num || cm[2].lockedNum == num)
                    return false;
                break;
            case 3:
                if (cm[0].lockedNum == num || cm[1].lockedNum == num)
                    return false;
                break;
            case 2:
                if (cm[0].lockedNum == num)
                    return false;
                break;
        }
        return true;
    }

    void MoveOther()//MoveOtherPlayers
    {
        switch (sceneNum)
        {
            case 4:
                if (cm[0].currentNum == currentNum)
                    cm[0].MoveRight();
                if (cm[1].currentNum == currentNum)
                    cm[1].MoveRight();
                if (cm[2].currentNum == currentNum)
                    cm[2].MoveRight();
                break;
            case 3:
                if (cm[0].currentNum == currentNum)
                    cm[0].MoveRight();
                if (cm[1].currentNum == currentNum)
                    cm[1].MoveRight();
                break;
            case 2:
                if (cm[0].currentNum == currentNum)
                    cm[0].MoveRight();
                break;
        }
    }
    void Update()
    {
        ChangeSelectBack();
        paused = pauseMenu.activeInHierarchy;
        if (!paused)
        {
            #region MoveLeftRight
            if (player.GetButtonDown("MoveLeft") && !locked && !paused)
            {
                Click.Play();
                if (CheckLeftMovable())
                    MoveLeft();
                else
                    MoveLeft2();
            }
            if (player.GetButtonDown("MoveRight") && !locked && !paused)
            {
                Click.Play();
                if (CheckRightMovable())
                    MoveRight();
                else
                    MoveRight2();
            }
            if (player.GetButtonLongPress("MoveLeft") && !locked && !paused)
            {
                Click.Play();
                if (CheckLeftMovable())
                    MoveLeft();
                else
                    MoveLeft2();
            }
            if (player.GetButtonLongPress("MoveRight") && !locked && !paused)
            {
                Click.Play();
                if (CheckRightMovable())
                    MoveRight();
                else
                    MoveRight2();
            }
            #endregion
            //KeepOpen();
        }
        if (player.GetButtonDown("Confirm") && !locked && CheckLockable() && !paused)
        {
            Click.Play();
            MoveOther();
            locked = true;
            Lock.enabled = true;
            LockIn();
            lockedNum = currentNum;
        }
        if (player.GetButtonDown("Cancel") && locked && !paused)
        {
            Click.Play();
            locked = false;
            Lock.enabled = false;
            lockedNum = 0;
            //SelectBack.sprite = SprSelectBack[0];
        }
        else if (player.GetButtonDown("Cancel") && !locked && !paused)
        {
            Click.Play();
            pauseMenu.SetActive(true);
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
                SceneManager.LoadScene(0);
            }

        }
        if (player.GetButton("Start") && locked && !paused)
        {
            Click.Play();
            switch (playerID)
            {
                case 0:
                    FindObjectOfType<StartButton>().adder1 = adderNum;
                    break;
                case 1:
                    FindObjectOfType<StartButton>().adder2 = adderNum;
                    break;
                case 2:
                    FindObjectOfType<StartButton>().adder3 = adderNum;
                    break;
                case 3:
                    FindObjectOfType<StartButton>().adder4 = adderNum;
                    break;
            }
        }
        else
        {
            switch (playerID)
            {
                case 0:
                    FindObjectOfType<StartButton>().adder1 = 0;
                    break;
                case 1:
                    FindObjectOfType<StartButton>().adder2 = 0;
                    break;
                case 2:
                    FindObjectOfType<StartButton>().adder3 = 0;
                    break;
                case 3:
                    FindObjectOfType<StartButton>().adder4 = 0;
                    break;
            }

        }
        //if (paused)
        //{
        //    if (player.GetButtonDown("Cancel"))
        //    {
        //        pauseMenu.SetActive(false);
        //    }
        //    else if (player.GetButton("Confirm"))
        //    {
        //        SceneManager.LoadScene(0);
        //    }
        //}
    }
}
