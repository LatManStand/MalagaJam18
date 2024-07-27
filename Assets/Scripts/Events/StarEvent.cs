using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StarEvent : Events
{
    Color originalPlayerColor;

    public override void Play(Transform target)
    {
        originalPlayerColor = target.GetComponentInChildren<SpriteRenderer>().color;
        StartCoroutine("Star", target);       
    }

    IEnumerator Star(Transform target)
    {        
        float endtime = Time.time + duration;
        while (Time.time < endtime)
        {
            target.GetComponentInChildren<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value, 255);
            target.GetComponent<CapsuleCollider>().enabled = false;
            target.GetComponent<Player>().isStarOn = true;
            yield return null;
        }

        target.GetComponentInChildren<SpriteRenderer>().color = originalPlayerColor;
        target.GetComponent<CapsuleCollider>().enabled = true;
        target.GetComponent<Player>().isStarOn = false;
    }
}
