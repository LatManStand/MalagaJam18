using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoinMorePlayers : MonoBehaviour
{
    public Sprite[] character;
    private int playerCount =  1;
    public void OnPlayerJoined(PlayerInput player)
    {
        player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = character[playerCount];
        playerCount++;
    }
}
