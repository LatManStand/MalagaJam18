using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrickDiceEvent : Events
{
    [SerializeField]
    GameObject fallingObject;
    [SerializeField]
    float objectFallDistance = 5;
    [SerializeField]
    float freezePlayerTime = 1;

    public override void Play(Transform target)
    {
        StartCoroutine("TrickDice", target);
    }

    IEnumerator TrickDice(Transform target)
    {
        target.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        GameObject fallingObjectToDestroy = Instantiate(fallingObject, new Vector3(target.position.x, target.position.y + objectFallDistance, target.position.z), fallingObject.transform.rotation);
        yield return new WaitForSeconds(freezePlayerTime);
        target.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        int randomValue = Random.Range(-6, 6);
        Tablero.instance.MoveToken(target.GetComponent<Player>().token, randomValue);
        if (randomValue > 0)
        {
            target.GetComponentInChildren<TMP_Text>().text = "+ " + randomValue.ToString();
        }
        else
        {
            target.GetComponentInChildren<TMP_Text>().text = randomValue.ToString();
        }
        target.GetComponentInChildren<TMP_Text>().enabled = true;
        yield return new WaitForSeconds(duration);
        target.GetComponentInChildren<TMP_Text>().enabled = false;
    }

}
