using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseMenu : MonoBehaviour
{
    public Image[] CharacterBack;
    public Image[] CharacterIcon;
    public Image[] SelectBack;
    public Image[] Players;
    public Image[] PlayersBack;
    public Sprite[] SprCharacterBack;
    public Sprite[] SprCharacterIcon;
    public Sprite[] SprSelectBack;
    public Sprite[] SprPlayers;
    public Sprite[] SprPlayersBack;
    public GameObject[] P1;
    public GameObject[] P2;
    public GameObject[] P3;
    public GameObject[] P4;
    public GameManager gm;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    public void Char1()
    {
    }
    public void Char2()
    {

    }
    public void Char3()
    {

    }
    public void Char4()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
