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
        TimeSpan ts = TimeSpan.FromSeconds((int)time);
        timer.text = ts.ToString("mm':'ss'.'fff");
        StartCoroutine(Timer());
    }

    public IEnumerator Timer()
    {
        while (time > 0)
        {
            yield return null;
            time -= Time.deltaTime;
            TimeSpan ts = TimeSpan.FromSeconds((int)time);
            timer.text = ts.ToString("mm':'ss'.'fff");
        }
    }

    public void EndMatch()
    {
    }


}
