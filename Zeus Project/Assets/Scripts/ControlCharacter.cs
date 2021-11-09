using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacter : MonoBehaviour
{
    private Rigidbody2D speed;
    private BoxCollider2D hitbox;
    [SerializeField] private LayerMask ground;

    // Start is called before the first frame update
    private void Start()
    {
        speed = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        speed.velocity = new Vector2(dirX * 7f, speed.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed.velocity.x, 14f);
        }

    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(hitbox.bounds.center, hitbox.bounds.size, 0f, Vector2.down, .1f, ground);
    }
}
