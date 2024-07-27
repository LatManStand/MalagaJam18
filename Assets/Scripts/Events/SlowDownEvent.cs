using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SlowDownEvent : Events
{
    [SerializeField]
    GameObject fallingObject;
    [SerializeField]
    GameObject slowDownObject;
    [SerializeField]
    float objectFallDistance = 5;
    [SerializeField]
    float freezePlayerTime = 1;


    public override void Play(Transform target)
    {        
        StartCoroutine("SlowDown", target);
    }

    IEnumerator SlowDown(Transform target)
    {                      
        target.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        GameObject fallingObjectToDestroy = Instantiate(fallingObject, new Vector3(target.position.x, target.position.y + objectFallDistance, target.position.z), fallingObject.transform.rotation);
        yield return new WaitForSeconds(freezePlayerTime);
        Destroy(fallingObjectToDestroy);
        Instantiate(slowDownObject, new Vector3(target.position.x, slowDownObject.transform.position.y, target.position.z), fallingObject.transform.rotation);
        target.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
