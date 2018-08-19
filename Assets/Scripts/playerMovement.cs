using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public float maxSpeed;
    public float speed;
    public float jumpStartSpeed;
    public float maxDoubleJumps;
    public bool autoRun;
    private float doubleJumps = 0;


    private Animator anim;
    private Rigidbody2D rg2d;
    private SpriteRenderer spriteRend;

    // Use this for initialization
    void Start () {
        Debug.Log("Start");

        anim = GetComponent<Animator>();
        rg2d = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update () {

        float move = Input.GetAxisRaw("Horizontal");
        bool onGround;

        if (autoRun == true)
        {
            move = 1;
        }





        if (rg2d.velocity.y == 0)
        {
            onGround = true;
            doubleJumps = 0;
        } else
        {
            onGround = false;
        }

        if (move < 0)
        {
            spriteRend.flipX = true;
        } else if (move > 0)
        {
            spriteRend.flipX = false;
        }

        if (rg2d.velocity.y < 0)
        {
            anim.SetBool("falling", true);
        } else
        {
            anim.SetBool("falling", false);
        }

        if (move > 0 || move < 0)
        {
            if (Mathf.Abs(rg2d.velocity.x) < maxSpeed)
            {
                anim.SetBool("running", true);
                rg2d.AddForce(new Vector2(move, 0) * speed);
            }
            
        } else
        {
            anim.SetBool("running", false);
        }

        if (Input.GetButtonDown("Jump") && onGround == true)
        {
            //Debug.Log("Jump");
            rg2d.AddForce(new Vector2(0, 1) * jumpStartSpeed);
            anim.SetTrigger("jumping");

        }
        if (onGround == false && doubleJumps < maxDoubleJumps && Input.GetButtonDown("Jump"))
        {
            Vector2 vTemp = rg2d.velocity;
            vTemp.y = 0f;
            rg2d.velocity = vTemp;

            rg2d.AddForce(new Vector2(0, 1) * jumpStartSpeed);
            anim.SetTrigger("doubleJumping");
            doubleJumps++;
        }

    }
}
