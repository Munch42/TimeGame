using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private float moveInput;
    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    private List<Key> keys;

    private void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        keys = new List<Key>();
    }

    private void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal"); // To be more snappy we can do GetAxisRaw
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRight == false && moveInput > 0)
        {
            Flip();
        } else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    private void Update()
    {
        if (isGrounded)
        {
            extraJumps = extraJumpsValue; // Total double jumps
        }

        if(Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
            else
            {
                rb.velocity = Vector2.up * jumpForce;
            }
            extraJumps--;
        } else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
            else
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Key")
        {
            Key key = collision.gameObject.GetComponent<Key>();

            keys.Add(key);

            Destroy(collision.gameObject);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    public List<Key> getKeys()
    {
        return keys;
    }

    public void setKeys(List<Key> _keys)
    {
        keys = _keys;
    }
}
