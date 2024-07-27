using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class JoinMorePlayers : MonoBehaviour
{
    public Sprite[] character;
    public void OnPlayerJoined(PlayerInput player)
    {

        //player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = character[GameManager.instance.playerList.Count];
        player.GetComponent<Player>().character = (Character)GameManager.instance.spawnId;
        player.GetComponent<Player>().SetColor(GameManager.instance.GetColorFor(player.GetComponent<Player>().character));
        player.transform.DOMove(GameManager.instance.spawns[GameManager.instance.spawnId].position, 0.001f).Play();
        GameManager.instance.spawnId++;
    }
}
