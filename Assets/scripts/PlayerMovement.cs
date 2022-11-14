using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   private Rigidbody2D rb;
    public float speed;
    private float moveInput;

    private Animator animator;
    
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

        if(Input.GetKeyDown(KeyCode.Z))
        {
            Repel();
        }
    }

    void Repel()
    {
        Debug.Log("repel");
    }
}
