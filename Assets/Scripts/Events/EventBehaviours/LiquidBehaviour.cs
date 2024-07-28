using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    List<Player> playersList;
    
    void Start()
    {
        Destroy(gameObject, duration);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playersList.Add(other.gameObject.GetComponent<Player>());            
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
        foreach (Player p in playersList)
        {
            p.speed = initialPlayerSpeed;
        }
        playersList.Clear();
    }

}
