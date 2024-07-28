using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsPanel : MonoBehaviour
{
    [SerializeField]
    GameObject panel;

    public void Open()
    {
        panel.SetActive(true);
    }

    public void Close ()
    {
        panel.SetActive (false);
    }
}
