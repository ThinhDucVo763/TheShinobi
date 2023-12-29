using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    public float dirX = 0f;
  
    private bool dangChay = false;

    [SerializeField] private LayerMask layerGround;
    [SerializeField] private float speedWalk;
    [SerializeField] private float speedRun;
    [SerializeField] private float jumpForce;
    private bool runInput ;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }
    private void Update() {
       Movement();
    }
    
    private void Movement(){
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speedWalk + Time.deltaTime, rb.velocity.y);
        SetAnimation();
        runInput = Input.GetKey(KeyCode.LeftShift);
        
        if(runInput){
            rb.velocity = new Vector2(dirX * speedRun + Time.deltaTime, rb.velocity.y);
        }
        if(Input.GetKeyDown(KeyCode.W) && IsGrounded()){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetTrigger("jumping");
        }
        
    }
    
    private void SetAnimation(){
        if(dirX == 0f){
            anim.SetBool("running", false);
            anim.SetBool("walking", false);
        }

        if(dirX > 0f){
            transform.localScale = Vector3.one;
            anim.SetBool("walking", true);
        }
        else if(dirX < 0f){
            transform.localScale = new Vector3(-1,1,1);
            anim.SetBool("walking", true);
        }

        if(dirX < 0f && runInput){
            transform.localScale = new Vector3(-1,1,1);
            anim.SetBool("running", true);
        }
        else if(dirX > 0f && runInput){
            transform.localScale = Vector3.one;
            anim.SetBool("running", true);
        }else{
            anim.SetBool("running", false);
        }
    }

    private bool IsGrounded(){
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, layerGround);
    }
}
