using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class PlayerText
{
    public Player player;
    public TMP_Text text;

    public PlayerText(Player player, TMP_Text text)
    {
        this.player = player;
        this.text = text;
    }
}

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public GameObject layout;
    public GameObject textPrefab;
    public GameObject matchEnd;
    public GameObject matchEndLayout;
    public List<PlayerText> playerTexts;
    public TMP_Text timer;
    public float time;


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

    public void AddPlayerToUi(Player player)
    {
        GameObject text = Instantiate(textPrefab, layout.transform);
        PlayerText playerText = new PlayerText(player, text.GetComponent<TMP_Text>());
        playerText.text.color = player.color;
        playerTexts.Add(playerText);
    }

    public void UpdateUI(Player player)
    {
        for (int i = 0; i < playerTexts.Count; i++)
        {
            if (playerTexts[i].player == player)
            {
                playerTexts[i].text.text = player.score.ToString();
            }
        }
    }

    public void StartTimer()
    {
        time = GameManager.instance.matchDuration;
        TimeSpan ts = TimeSpan.FromSeconds(time);
        timer.text = ts.ToString("mm':'ss");
        StartCoroutine(Timer());
    }

    public IEnumerator Timer()
    {
        while (time > 0)
        {
            yield return null;
            time -= Time.deltaTime;
            TimeSpan ts = TimeSpan.FromSeconds(time);
            timer.text = ts.ToString("mm':'ss");
        }
        EndMatch();
    }

    public void EndMatch()
    {
        matchEnd.SetActive(true);
        Time.timeScale = 0f;
        GameManager.instance.playerList.Sort((a, b) => b.score.CompareTo(a.score));
        foreach (Player player in GameManager.instance.playerList)
        {
            TMP_Text text = Instantiate(textPrefab, matchEndLayout.transform).GetComponent<TMP_Text>();
            text.text = player.score.ToString();
            text.color = player.color;
        }
    }


}
