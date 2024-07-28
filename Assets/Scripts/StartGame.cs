using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject tittle;
    public GameObject creditsButton;

    private void Start()
    {
        Time.timeScale = 0.0f;
    }
    public void BeginGame()
    {
        Time.timeScale = 1.0f;
        tittle.SetActive(false);
        creditsButton.SetActive(false);
        this.gameObject.SetActive(false);
        GameManager.instance.StartGame();
    }
}
