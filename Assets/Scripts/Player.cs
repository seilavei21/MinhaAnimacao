using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;

    public float JumpForce;

    private float timeAttack;

    public float starTimeAttack;
                            
    private bool isGrounded;
    private Rigidbody2D ribidbody;

    private Animator animator;

    private SpriteRenderer sprite;
 
 void Start()
    {
        ribidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
void FixedUpdate() 
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            ribidbody.velocity = new Vector2(-Speed, ribidbody.velocity.y);

            animator.SetBool("isWalking", true);

            sprite.flipX = true;
        }
        else{
            ribidbody.velocity = new Vector2(0, ribidbody.velocity.y);

            animator.SetBool("isWalking", false);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
             ribidbody.velocity = new Vector2(Speed, ribidbody.velocity.y);

             animator.SetBool("isWalking", true);

            sprite.flipX = false;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            ribidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }

        if(timeAttack <= 0)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                animator.SetTrigger("isAttacking");
                timeAttack = starTimeAttack;
            }
        }
            else
            {   
                timeAttack -= Time.deltaTime;
                animator.SetTrigger("isAttacking");
            }
    
    }

 void OnCollisionEnter2D(Collision2D coll) {

     if(coll.gameObject.layer == 8)
     {
         isGrounded = true;
         animator.SetBool("isJumping", false);
     }
        
    }

}