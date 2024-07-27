using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

[Serializable]
public struct FacingData
{
    public int faceValue;

    public Transform position;
}

public class Dice : MonoBehaviour
{

    public List<Player> playersThatTouched;

    public List<FacingData> facings = new List<FacingData>();

    public Rigidbody rb;
    public GameObject ground;

    public float minStrenght;
    public float maxStrenght;

    public float stopSpeed = 3f;

    public bool wasKicked = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        if (wasKicked)
        {
            if (rb.velocity.magnitude < stopSpeed)
            {
                wasKicked = false;
                Tablero.instance.MoveToken(playersThatTouched[0].token, DetermineFaceValue());
                playersThatTouched.Clear();
            }
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {GameObject go = collision.gameObject;
        if (go == ground)
        {
            AudioPlayer.Instance.PlaySFX(4);
        }
    }
    

    public void PlayerKick(Player player)
    {
        if (player != null)
        {
            if (!playersThatTouched.Contains(player))
            {
                playersThatTouched.Add(player);
                Kick(player.transform.position);
                AudioPlayer.Instance.PlaySFX(3);
            }
        }
    }

    private void Kick(Vector3 from)
    {
        rb.AddForce((transform.position - from).normalized * Random.Range(minStrenght, maxStrenght));
        Invoke(nameof(EnableWasKickedNextFrame), 0.1f);
    }

    private void EnableWasKickedNextFrame()
    {
        wasKicked = true;
    }



    public int DetermineFaceValue()
    {
        AudioPlayer.Instance.PlaySFX(1);
        float max = Mathf.Infinity;
        int match = 0;
        for (int i = 0; i < facings.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, facings[i].position.position);
            if (max > distance)
            {
                max = distance;
                match = facings[i].faceValue;
            }
        }
        return match;
    }
}
