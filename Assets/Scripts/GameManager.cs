using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject playerPrefab;

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

        player1.GetComponent<MeshRenderer>().material.color = Color.red;
        player2.GetComponent<MeshRenderer>().material.color = Color.blue;
        player1.GetComponent<Player>().token.GetComponent<MeshRenderer>().material.color = Color.red;
        player2.GetComponent<Player>().token.GetComponent<MeshRenderer>().material.color = Color.blue;

    }

    public void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
    }


    public void AddScoreTo(Player player, int score)
    {
        player.score += score;
    }

}
