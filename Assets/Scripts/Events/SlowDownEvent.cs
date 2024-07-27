using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SlowDownEvent : Events
{
    [SerializeField]
    GameObject fallingObject;
    [SerializeField]
    float objectFallDistance;
    [SerializeField]
    float slowDownValue;
    [SerializeField]
    float freezePlayerTime;
    [SerializeField]
    float slowDownTime;


    public override void Play(Transform target)
    {        
        StartCoroutine("SlowDown", target);
    }

    IEnumerator SlowDown(Transform target)
    {               
        float initialPlayerSpeed = target.GetComponent<Player>().speed;
        target.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        GameObject objectToDestroy = Instantiate(fallingObject, new Vector3(target.position.x, target.position.y + objectFallDistance, target.position.z), Quaternion.identity);
        yield return new WaitForSeconds(freezePlayerTime);
        Destroy(objectToDestroy);
        target.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        target.GetComponent<Rigidbody>().velocity /= slowDownValue;
        yield return new WaitForSeconds(slowDownTime);
        target.GetComponent<Player>().speed = initialPlayerSpeed;
    }
}
