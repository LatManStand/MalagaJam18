using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PlayerText
{
    public Player player;
    public ScoreText scoreText;

    public PlayerText(Player player, ScoreText scoreText)
    {
        this.player = player;
        this.scoreText = scoreText;
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
        foreach (PlayerText playerText1 in playerTexts)
        {
            if (playerText1.player == player)
            {
                return;
            }
        }
        GameObject text = Instantiate(textPrefab, layout.transform);
        PlayerText playerText = new PlayerText(player, text.GetComponent<ScoreText>());
        playerText.scoreText.text.color = player.color;
        playerText.scoreText.icon.sprite = GameManager.instance.GetIconFor(player.character);
        playerTexts.Add(playerText);
        LayoutRebuilder.ForceRebuildLayoutImmediate(matchEndLayout.GetComponent<RectTransform>());
    }

    public void UpdateUI(Player player)
    {
        for (int i = 0; i < playerTexts.Count; i++)
        {
            if (playerTexts[i].player == player)
            {
                playerTexts[i].scoreText.text.text = player.score.ToString();
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
        AudioPlayer.Instance.PlayMusic(0);
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
            ScoreText scoreText = Instantiate(textPrefab, matchEndLayout.transform).GetComponent<ScoreText>();
            scoreText.icon.sprite = GameManager.instance.GetIconFor(player.character);
            scoreText.text.text = player.score.ToString();
            scoreText.text.color = player.color;
            LayoutRebuilder.ForceRebuildLayoutImmediate(matchEndLayout.GetComponent<RectTransform>());
        }
    }


}
