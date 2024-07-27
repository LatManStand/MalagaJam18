using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[Serializable]
public struct CharacterData
{
    public Character character;
    public AnimatorController animator;
    public Sprite icon;
    public Sprite token;
}


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject playerPrefab;
    public List<Player> playerList;
    public List<Transform> spawns;
    public List<CharacterData> characterAnimators;
    public int spawnId = 0;

    public float matchDuration = 60f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

        PlayerInput player1 = PlayerInput.Instantiate(playerPrefab, controlScheme: "KeyboardLeft", pairWithDevice: Keyboard.current);
        PlayerInput player2 = PlayerInput.Instantiate(playerPrefab, controlScheme: "KeyboardRight", pairWithDevice: Keyboard.current);


        player1.GetComponent<Player>().SetColor(Color.red);
        player1.transform.DOMove(spawns[spawnId].position, 0.001f).Play();
        player1.GetComponent<Player>().character = Character.a;
        spawnId++;
        player2.GetComponent<Player>().SetColor(Color.blue);
        player2.transform.DOMove(spawns[spawnId].position, 0.001f).Play();
        player1.GetComponent<Player>().character = Character.b;
        spawnId++;

        /*/
        PlayerInput player3 = PlayerInput.Instantiate(playerPrefab, controlScheme: "Gamepad", pairWithDevice: Keyboard.current);
        PlayerInput player4 = PlayerInput.Instantiate(playerPrefab, controlScheme: "Gamepad", pairWithDevice: Keyboard.current);

        player3.GetComponent<Player>().SetColor(Color.green);
        player3.transform.DOMove(spawns[spawnId].position, 0.001f).Play();
        spawnId++;
        player4.GetComponent<Player>().SetColor(Color.yellow);
        player4.transform.DOMove(spawns[spawnId].position, 0.001f).Play();
        spawnId++;
        /**/
        StartGame();

    }

    public void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
    }

    public AnimatorController GetAnimatorFor(Character character)
    {
        foreach (CharacterData animator in characterAnimators)
        {
            if (character == animator.character)
            {
                return animator.animator;
            }
        }
        return null;
    }

    public Sprite GetIconFor(Character character)
    {
        foreach (CharacterData animator in characterAnimators)
        {
            if (character == animator.character)
            {
                return animator.icon;
            }
        }
        return null;
    }

    public Sprite GetTokenFor(Character character)
    {
        foreach (CharacterData animator in characterAnimators)
        {
            if (character == animator.character)
            {
                return animator.token;
            }
        }
        return null;
    }

    public void InitialisePlayer(Player player)
    {
        playerList.Add(player);
    }

    public void AddScoreTo(Player player, int score)
    {
        player.score += score;
        UiManager.instance.UpdateUI(player);
    }

    public void StartGame()
    {
        UiManager.instance.StartTimer();
    }

    public void EndMatch()
    {

    }

}
