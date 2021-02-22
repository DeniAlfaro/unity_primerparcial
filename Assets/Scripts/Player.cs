using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]


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

    PlayerControls playerControls;


    //public GameOverScreen gameOverScreen;

    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        playerControls = new PlayerControls();
    }

    void Start()
    {
        playerControls.Gameplay.Jump.performed += ctx => Jump();
    }

    void OnEnable()
    {
        playerControls.Enable();
    }

    void OnDisable()
    {
        playerControls.Disable();
    }

    void Update()
    {
        transform.Translate(Vector2.right * axis.x * moveSpeed * Time.deltaTime); 
    }

    void Jump()
    {
        if(IsGrounding)
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetTrigger("jump");
        }
    }

    void LateUpdate()
    {
        spr.flipX = flipSprite;
        anim.SetFloat("moveX", Mathf.Abs(axis.x));
        anim.SetBool("grounding", IsGrounding);
        
    }

    void FixedUpdate()
    {
        //anim.SetFloat("velocityY", rb2D.valocity.normalized.y);
        //anim.SetBool("grounding", IsGrounding);
    }

    Vector2 axis => playerControls.Gameplay.Movement.ReadValue<Vector2>();
    bool flipSprite => axis.x > 0 ? false : axis.x < 0 ? true : spr.flipX;

    bool IsGrounding => Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer); 

    void OnDrawGizmosSelected()
    {
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }
    ///SHELLSpoints
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("shell"))
        {
            Shells shell = other.GetComponent<Shells>();
            GameManager.instance.Score.AddPoins(shell.Points);
            Destroy(other.gameObject);
            Debug.Log(shell.Points);
        }

        if(other.CompareTag("Enemy"))
        {    
             GameManager.gameOver = true;
            
        }

        if(other.CompareTag("Pearl"))
        {    
             GameManager.youWin = true;
        }
    }
}
