using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingEvent : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

    private void Update()
    {
        Test();
    }

    public void Test()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            Events testEvent = EventManager.instance.EventsList[0];
            EventManager.instance.PlayEvent(testEvent, Player.transform);
            Debug.Log("Testing Event: " + testEvent);
        } else if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            Events testEvent = EventManager.instance.EventsList[1];
            EventManager.instance.PlayEvent(testEvent, Player.transform);
            Debug.Log("Testing Event: " + testEvent);
        }
    }
}
