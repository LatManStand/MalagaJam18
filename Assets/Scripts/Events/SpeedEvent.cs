using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpeedEvent : Events
{
    [SerializeField]
    GameObject fallingObject;
    [SerializeField]
    float objectFallDistance;
    [SerializeField]
    float speedMultiplier;
    [SerializeField]
    float freezePlayerTime = 1;


    public override void Play(Transform target)
    {
        StartCoroutine("Speed", target);
    }

    IEnumerator Speed(Transform target)
    {
        target.GetComponent<Player>().animator.SetBool("Coffee", true);
        target.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        GameObject fallingObjectToDestroy = Instantiate(fallingObject, new Vector3(target.position.x, target.position.y + objectFallDistance, target.position.z), fallingObject.transform.rotation);
        yield return new WaitForSeconds(freezePlayerTime);
        target.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        Destroy(fallingObjectToDestroy);
        float initialPlayerSpeed = target.GetComponent<Player>().speed;
        target.GetComponent<Player>().speed *= speedMultiplier;
        yield return new WaitForSeconds(duration);
        target.GetComponent<Player>().speed = initialPlayerSpeed;
        target.GetComponent<Player>().animator.SetBool("Coffee", false);
    }
}
