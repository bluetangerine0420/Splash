using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : Splash
{
    public Animator animator;


    void Start()
    {
        animator.SetBool("Escape", false);
        Cur_Death_Value = 0;
        Max_Death_Value = 100;
        Death_Value = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Escape)
        {
            animator.SetBool("Escape", true);
        }
        if (!Escape)
        {
            animator.SetBool("Escape", false);
        }

        if (AttackReady)
        {
            animator.SetBool("isAttack", true);

        }

        if (!AttackReady)
        {
            animator.SetBool("isAttack", false);
        }

        if (Cur_Death_Value > Max_Death_Value)
        {
            Destroy(gameObject);
        }
        else { Cur_Death_Value += Time.deltaTime * Death_Value; }
    }

    void FixedUpdate()
    {
        if (Right_Move)
        {
            
            Vector2 movement = new Vector2(1, -0.01f) * Move_Spd * Time.deltaTime;
            GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + movement);
        
        }
        else if(Left_Move)
        {
           
            Vector2 movement = new Vector2(-1, -0.01f) * Move_Spd * Time.deltaTime;
            GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + movement);

           
        }
    }
}
