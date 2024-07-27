using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject tokenPrefab;
    public Token token;
    public Rigidbody rb;
    public float speed;
    public int score;

    public PlayerInput playerInput;
    public Vector3 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        token = Instantiate(tokenPrefab).GetComponent<Token>();
        token.player = this;
        Tablero.instance.InitialiseToken(token);
    }

    public void FixedUpdate()
    {
        transform.LookAt(rb.position + movement);
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Dice dice = other.GetComponent<Dice>();
        if (dice)
        {
            dice.PlayerKick(this);
        }
    }

    public void SetMovement(InputAction.CallbackContext ctx)
    {
        movement.x = ctx.ReadValue<Vector2>().x;
        movement.z = ctx.ReadValue<Vector2>().y;
    }
}
