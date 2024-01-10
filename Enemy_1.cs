using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{

    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;

    [SerializeField] private float jumpDistance = 5f;
    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private LayerMask ground;
    private Collider2D coll;
    //private Animator anim;
    //private Rigidbody2D rb;

    private bool facingLeft = true;

    protected override void Start()
    {
        base.Start();       //partea Enemy.cs
        coll = GetComponent<Collider2D>();
        //rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }
    private void Stop()
    {
        if(coll.IsTouchingLayers(ground))
        {
        anim.SetBool("Jumping", false);
        }
    }
    private void Move()
    {
        if (facingLeft)
        {

            //verificam daca am depasit leftCap
            if (transform.position.x > leftCap)
            {   // Verifica daca inamicul e in directia buna si daca nu atunci schimba valoarea lui x   
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }
                if (coll.IsTouchingLayers(ground))   //Verifica daca e pe pamant, daca da atunci merge
                {
                    //Jump
                    rb.velocity = new Vector2(-jumpDistance, jumpHeight);
                    anim.SetBool("Jumping",true);
                }
            }
            else
            {
                facingLeft = false;
            }
        }
        else
        {
            //verificam daca am depasit leftCap
            if (transform.position.x < rightCap)
            {   // Verifica daca inamicul e in directia buna si daca nu atunci schimba valoarea lui x   
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }
                if (coll.IsTouchingLayers(ground))   //Verifica daca e pe pamant, daca da atunci merge
                {
                    //Jump
                    rb.velocity = new Vector2(jumpDistance, jumpHeight);
                    anim.SetBool("Jumping", true);
                }
            }
            else
            {
                facingLeft = true;
            }
        }
        //anim.SetBool("Jumping", false);
    }
}
