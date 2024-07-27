using UnityEngine;
using UnityEngine.InputSystem;

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
        // transform.LookAt(rb.position + movement);
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }

    public void SetColor(Color _color)
    {
        color = _color;
        GetComponent<MeshRenderer>().material.color = _color;
        token.GetComponent<MeshRenderer>().material.color = _color;
        UiManager.instance.AddPlayerToUi(this);
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
        else { playerSprite.flipX = false; }
    }
}
