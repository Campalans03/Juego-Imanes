using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   private Rigidbody2D rb;
    public float speed;
    private float moveInput;

    private Animator animator;

    private bool repel=false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(moveInput));
    }

    void Update()
    {
         if(moveInput > 0){
            transform.eulerAngles = new Vector3(0,0,0);
        }if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }

        Physics2D.Raycast(transform.position,Vector3.up,0.1f);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Repel();
            
        }
    }

    void Repel()
    {
        repel=!repel;
        animator.SetBool("repeler", repel);
        //GameObject blueMagnet = Instantiate(BulletPrefab, transform.position + direction * 0.1f,Quaternion.identity);
        Debug.Log("repel");
    }
}
