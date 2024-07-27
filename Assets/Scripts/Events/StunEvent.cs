using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StunEvent : Events
{
    [SerializeField]
    GameObject fallingObject;
    [SerializeField]
    float objectFallDistance;
    [SerializeField]
    float stunPlayerTime;

    public override void Play(Transform target)
    {
        StartCoroutine("Stun", target);
    }

    IEnumerator Stun(Transform target)
    {
        AudioPlayer.Instance.PlaySFX(0, gameObject);
        target.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        GameObject objectToDestroy = Instantiate(fallingObject, new Vector3(target.position.x, target.position.y + objectFallDistance, target.position.z), fallingObject.transform.rotation);
        yield return new WaitForSeconds(stunPlayerTime);
        Destroy(objectToDestroy);
        target.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
    }
}
