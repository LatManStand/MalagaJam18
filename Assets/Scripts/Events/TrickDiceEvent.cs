using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrickDiceEvent : Events
{
    public override void Play(Transform target)
    {
        StartCoroutine("TrickDice", target);
    }

    IEnumerator TrickDice(Transform target)
    {
        int randomValue = Random.Range(-6, 6);
        Tablero.instance.MoveToken(target.GetComponent<Player>().token, randomValue);
        target.GetComponentInChildren<TMP_Text>().text = randomValue.ToString();
        target.GetComponentInChildren<TMP_Text>().enabled = true;
        yield return new WaitForSeconds(duration);
        target.GetComponentInChildren<TMP_Text>().enabled = false;
    }

}
