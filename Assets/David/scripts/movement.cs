using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{

    public bool isattached;

    public bool isDetached;

    public float horizontal;

    // Movement 
    public float speed;

    public float JumpHeight;

    private Rigidbody2D Rb;

    private float _movement;

    // Ground detection 
    public Vector2 boxsize;

    public float castDistance;

    public LayerMask groundLayer;

    public GameObject playerObj;

    public Vector2 leftBox;

    public Vector2 rightBox;

    //animation variables
    private Animator _animator;

    private SpriteRenderer _sprt;

    public bool isfalling;

    private MagnetParent attached;

    public bool at;




    // Wall detection variables
    public Vector2 boxsize2;

    public float castDistance2;

    public LayerMask wallLayer;

    //Rigidbody2D component



    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprt = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        
        
        at = MagnetParent.isattached;

        if (at)
        {
            isattached = true;
            isDetached = false;

        }
        else
        {
            isattached = false;
            isDetached = true;
        }

        if (Rb.linearVelocity.y < 0)
        {
            isfalling = true;
        }
        else
        {
            isfalling = false;
        }
        if (_animator != null)
            _animator.SetBool("isfalling", isfalling);

        _animator.SetBool("isGrounded", IsGrounded());

        Rb.linearVelocityX = _movement;

        if(Rb.linearVelocityX < 0 && IsWallLeft())
        {
            Rb.linearVelocityX = 0;
        }
        if(Rb.linearVelocityX > 0 && IsWallRight())
        {
            Rb.linearVelocityX = 0;
        }
    }



    // Controls the players horizontal movment
    public void Move(InputAction.CallbackContext ctx)
    {


        _movement = ctx.ReadValue<Vector2>().x * speed;

        if (_movement != 0)
        {
            if (_animator != null)
                _animator.SetFloat("movement", _movement);
            if (_animator != null)
                _animator.SetBool("ismoving", true);

            if (_movement < 0)
            {
                _sprt.flipX = false;
            }
            else
            {
                _sprt.flipX = true;
            }
        }
        else
        {
            if (_animator != null)
                _animator.SetBool("ismoving", false);
        }




    }

    // Controlls the players jump and makes sure the player is grounded
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1)
        {
            if (IsGrounded())
            {
                Rb.linearVelocityY = JumpHeight;
                if (_animator != null)
                    _animator.SetTrigger("jump");
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

    public bool IsWallLeft()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position + (Vector3)leftBox, boxsize2, 0, Vector2.zero, 0, wallLayer);
        return hit.collider;
    }
    public bool IsWallRight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position + (Vector3)rightBox, boxsize2, 0, Vector2.zero, 0, wallLayer);
        return hit.collider;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position + (Vector3)leftBox, boxsize2);
        Gizmos.DrawWireCube(transform.position + (Vector3)rightBox, boxsize2);
    }

}