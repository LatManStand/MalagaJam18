using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidBehaviour : MonoBehaviour
{
    [SerializeField]
    float duration;
    [SerializeField]
    float slowDownValue;
    [SerializeField]
    float initialPlayerSpeed;
    [SerializeField]
    Player player;
    
    void Start()
    {
        Destroy(gameObject, duration);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<Player>();
            other.gameObject.GetComponent<Player>().speed = slowDownValue;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().speed = initialPlayerSpeed;
        }
    }

    private void OnDestroy()
    {
        player.speed = initialPlayerSpeed;
    }

}
