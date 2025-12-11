using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    public bool isattached = false;
    public float speed;

    public float JumpHeight;

    private Rigidbody2D Rb;

    private float _movement;

    public Vector2 boxsize;

    public float castDistance;

    public LayerMask groundLayer;

    public GameObject playerObj;

    private Animator _animator;
    private SpriteRenderer _sprt;
    public bool isfalling;
    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprt = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
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
        if (_animator != null)
            _animator.SetBool("isGrounded", IsGrounded());

        Rb.linearVelocityX = _movement;
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
    void OnCollisionEnter(Collision collision)
    {
        // Optional: Check the tag of the object collided with
        if (collision.gameObject.CompareTag("AttachableObject"))
        {
            isattached = true;
            Debug.Log("Player attached to " + collision.gameObject.name);
        }
    }

    // Called every frame while the player is touching a collider
    void OnCollisionStay(Collision collisionInfo)
    {
        // Keep the flag true while touching
        if (collisionInfo.gameObject.CompareTag("AttachableObject"))
        {
            isattached = true;
        }
    }

    // Called when the player stops touching a collider
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("AttachableObject"))
        {
            isattached = false;
            Debug.Log("Player detached from " + collision.gameObject.name);
        }
    }




}



