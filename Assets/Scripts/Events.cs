using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Events : MonoBehaviour
{
    public float duration;
    public int score;

    public void Score(Player player)
    {
        GameManager.instance.AddScoreTo(player, score);
        Play(player.transform);
    }

    public virtual void Play(Transform target)
    {
        if (target != null)
        {

        }
    }
}