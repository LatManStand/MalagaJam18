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
        target.GetComponent<Player>().animator.SetBool("Drunk", true);
        target.GetComponent<Player>().speed *= -1;
        yield return new WaitForSeconds(duration);
        target.GetComponent<Player>().speed *= -1;
        target.GetComponent<Player>().animator.SetBool("Drunk", false);
    }

}
