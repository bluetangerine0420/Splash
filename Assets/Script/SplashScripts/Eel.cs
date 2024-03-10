using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Eel : Splash
{
    private bool wasEscape = false;
    public Animator animator;

    void Start()
    {
        animator.SetBool("Escape", false);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Escape)
        {
            if (Escape != wasEscape)
            {
                EscapeAct();
                wasEscape = Escape;
            }
        }

        if (!Escape)
        {
            wasEscape = false;
         
            CancelInvoke("Decrease");
           

        }

        if (Escape)
        {
            animator.SetBool("Escape", true);
        }
        if (!Escape)
        {
            animator.SetBool("Escape", false);
        }
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

    void EscapeAct()
    {
       
       
        InvokeRepeating("Decrease", 0f, 3f);

    }


    private void Decrease()
    {
        if (!Escape)
        {
            CancelInvoke("Decrease");
            return;
        }

        Employee[] employees = FindObjectsOfType<Employee>();
        foreach (Employee employee in employees)
        {
            employee.DecreaseHp(5);
        }
    }
}
