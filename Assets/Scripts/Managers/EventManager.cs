using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    public Events[] EventsList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlayEvent(Events events, Transform player)
    {
        events.Play(player);
    }


}
