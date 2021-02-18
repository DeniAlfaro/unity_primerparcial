using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Range(0.1f, 10f)]
    float moveSpeed = 1f;
    
    SpriteRenderer spr;
    Animator anim;
    Rigidbody2D rb2D;
    
    [SerializeField, Range(0.1f, 15f)]
    float jumpForce = 7f;
    
    [SerializeField]
    Color rayColor = Color.magenta;
    
    [SerializeField, Range(0.1f, 15f)]
    float rayDistance = 5f;
    
    [SerializeField]
    LayerMask groundLayer;

    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * axis.x * moveSpeed * Time.deltaTime);
        

    }

    void LateUpdate()
    {
        spr.flipX = flipSprite;
        anim.SetFloat("moveX", Mathf.Abs(axis.x));
        anim.SetFloat("velocityY", Mathf.Abs(axis.y));
        
    }

    void FixedUpdate()
    {
        if(jumpButton && IsGrounding)
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        //anim.SetFloat("velocityY", rb2D.valocity.normalized.y);
        //anim.SetBool("grounding", IsGrounding);
    }

    Vector2 axis => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    bool flipSprite => axis.x > 0 ? false : axis.x < 0 ? true : spr.flipX;

    bool jumpButton  => Input.GetButtonDown("Jump");

    bool IsGrounding => Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer); 

    void OnDrawGizmosSelected()
    {
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }
}
