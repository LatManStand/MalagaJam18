using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertMovementAxisEvent : Events
{

    public override void Play(Transform target)
    {
        StartCoroutine("InvertMovement", target);
    }

    IEnumerator InvertMovement(Transform target)
    {
        // TODO: probarlo
        target.GetComponent<Player>().speed *= -1;
        yield return new WaitForSeconds(duration);
        target.GetComponent<Player>().speed *= -1;
    }

}
