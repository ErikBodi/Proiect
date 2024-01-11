using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_enemy : Enemy
{
    [SerializeField] private float UpCap;
    [SerializeField] private float LovCap;
    [SerializeField] private float speed = 3f;
    private Collider2D coll;

    private bool facingUp = false;

    protected override void Start()
    {
        base.Start();       //partea Enemy.cs
        coll = GetComponent<Collider2D>();
    }
    private void Update()
    {
        /*anim.SetInteger("EnemyState", (int)state);//valoare anim v-a deveni valoarea lui state
        state = EState.moving;*/
        if (facingUp)
        {
        //rb.velocity = new Vector2(rb.velocity.x, speed);
            if (transform.position.y > UpCap)
            {
                rb.velocity = new Vector2(rb.velocity.x, -speed);
            }
            else
            {
                facingUp = false;
            }
        }
        else
        {
            if (transform.position.y < LovCap)
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);
            }
            else
            {
                facingUp = true;
            }
        }
    }
}
