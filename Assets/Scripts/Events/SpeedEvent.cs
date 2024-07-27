using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpeedEvent : Events
{

    [SerializeField]
    float speedMultiplier;


    public override void Play(Transform target)
    {
        StartCoroutine("Speed", target);
    }

    IEnumerator Speed(Transform target)
    {
        float initialPlaye1rSpeed = target.GetComponent<Player>().speed;
        target.GetComponent<Player>().speed *= speedMultiplier;
        yield return new WaitForSeconds(duration);
        target.GetComponent<Player>().speed = initialPlaye1rSpeed;
    }
}
