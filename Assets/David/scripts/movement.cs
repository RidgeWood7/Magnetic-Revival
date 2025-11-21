using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{

    public float speed;

    public float JumpHeight;

    private Rigidbody2D Rb;

    private float _movement;

    public Vector2 boxsize;

    public float castDistance;

    public LayerMask groundLayer;

    public GameObject playerObj;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rb.linearVelocityX = _movement;
    }



    // Crontrolls the players horizontal movment
    public void Move(InputAction.CallbackContext ctx)
    {

        _movement = ctx.ReadValue<Vector2>().x * speed;

    }
    // Controlls the players jump and makes sure the player is grounded
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1)
        {
            if (IsGrounded())
            {
                Rb.linearVelocityY = JumpHeight;
            }
        }
    }


    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxsize, 0, -transform.up, castDistance, groundLayer);
        return hit.collider;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + Vector3.down * castDistance, boxsize);
    }



    public void SavePlayer()
    {
        saveSystem.SavePlayer(this);
    }

    public void loadPlayer(Vector3 position)
    {
        playerData data = saveSystem.loadPlayer();

        
        position.x = data.position[0];
        position.y = data.position[1];
        transform.position = position;
    }
}
