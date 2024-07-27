using UnityEngine;
using UnityEngine.InputSystem;

public enum Character
{
    a,
    b,
    c,
    d
}


public class Player : MonoBehaviour
{
    public GameObject tokenPrefab;
    public Token token;
    public Rigidbody rb;
    public float speed;
    public int score;
    public Color color;

    public PlayerInput playerInput;
    public Vector3 movement;

    private SpriteRenderer playerSprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        token = Instantiate(tokenPrefab).GetComponent<Token>();
        token.player = this;
        Tablero.instance.InitialiseToken(token);

        playerSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        GameManager.instance.InitialisePlayer(this);
    }

    public void FixedUpdate()
    {
        if (movement != Vector3.zero)
        {
            // transform.LookAt(rb.position + movement);
            Vector3 endpoint = rb.position + movement * speed * Time.deltaTime;
            endpoint.x = Mathf.Clamp(endpoint.x, Tablero.instance.minXLimit, Tablero.instance.maxXLimit);
            endpoint.z = Mathf.Clamp(endpoint.z, Tablero.instance.minZLimit, Tablero.instance.maxZLimit);
            rb.MovePosition(endpoint);
        }
    }

    public void SetColor(Color _color)
    {
        color = _color;
        GetComponent<MeshRenderer>().material.color = _color;
        token.GetComponent<MeshRenderer>().material.color = _color;
        UiManager.instance.AddPlayerToUi(this);
        token.transform.GetChild(0).GetChild(2).GetComponent<MeshRenderer>().material.color = _color;
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
        FlipPlayer(movement.x);
    }

    private void FlipPlayer(float x)
    {
        if (x < 0) { playerSprite.flipX = true; }
        else if (x > 0) { playerSprite.flipX = false; }
    }
}
