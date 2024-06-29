using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
[AddComponentMenu("DangSon/PlayerController")]
public class PlayerController : MonoBehaviour
{
    #region Public
    public LayerMask groundLayer;
    #endregion
    #region Private
    [SerializeField] Transform groundCheck;
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float jumForce = 5.0f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteCharacter;
    // Start is called before the first frame update
    private bool isGround = false;
    private bool facingRight = true;
    private int isWalkAnimationid = Animator.StringToHash("isWalk");
    private int isJumid = Animator.StringToHash("isJum");
    private Animator anim;
    #endregion
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteCharacter = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        Move();
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            Jum();
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            NotJum();
        }
    }

    private void NotJum()
    {
        anim.SetBool(isJumid, false);
    }
    private void Jum()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumForce);
        anim.SetBool(isJumid, true);

    }
    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        if((horizontal>0&&!facingRight)||(horizontal<0&&facingRight))
        {
            Flip();
        }
        if (math.abs(horizontal) > 0)
        {
            anim.SetBool(isWalkAnimationid, true);
        }
        else
        {
            anim.SetBool(isWalkAnimationid, false);
        }
   }
    void Flip()
    {
        facingRight = !facingRight;
        //spriteCharacter.flipX = !facingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
