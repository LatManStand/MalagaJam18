using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoinMorePlayers : MonoBehaviour
{
    public Sprite[] character;
    public PlayerInput player;
    public void OnPlayerJoined(PlayerInput player)
    {
        this.player = player;

        if (GameManager.instance.playerList.Contains(player.GetComponent<Player>())) { return; }
        //player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = character[GameManager.instance.playerList.Count];
        player.GetComponent<Player>().character = (Character)GameManager.instance.spawnId - 1;
        StartCoroutine(KeepDoingStuff());
    }

    public IEnumerator KeepDoingStuff()
    {
        yield return null;
        player.GetComponent<Player>().SetColor(GameManager.instance.GetColorFor(player.GetComponent<Player>().character));
        player.transform.DOMove(GameManager.instance.spawns[(int)player.GetComponent<Player>().character].position, 0.001f).SetUpdate(true).Play();
        GameManager.instance.spawnId++;
    }
}
