using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
public class CursorController : MonoBehaviour
{
    public int playerID = 0;
    [SerializeField] private Player player;
    Vector3 movement;
    public int CursorSpeed = 600;
    private void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
    }
    private void Update()
    {
        movement.x = player.GetAxisRaw("CursorHorizontal");
        movement.y = player.GetAxisRaw("CursorVertical");
    }
    void FixedUpdate()
    {
        transform.position = transform.position + movement * CursorSpeed * Time.fixedDeltaTime;
    }
}
