using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raysplash : Splash
{
    private bool isAngel = false;
    private bool wasEscape = false;
    public Animator animator;

    void Start()
    {
        animator.SetBool("Escape", false);

    }

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
        if (Escape)
        {
            animator.SetBool("Escape", true);
        }
        if (!Escape)
        {
            animator.SetBool("Escape", false);
        }

        if (!Escape)
        {
            wasEscape = false;
            CancelInvoke("AngelRecovery");
            CancelInvoke("DevilDecrease");
            CancelInvoke("BecomeDevil");

        }
    }

    void FixedUpdate()
    {
        if (Right_Move)
        {
            Vector2 movement = new Vector2(1, -0.01f) * Move_Spd * Time.deltaTime;
            GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + movement);
        }
        else if (Left_Move)
        {
            Vector2 movement = new Vector2(-1, -0.01f) * Move_Spd * Time.deltaTime;
            GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + movement);
        }
    }

    void EscapeAct()
    {
        wasEscape = Escape;

      

        isAngel = Random.value > 0.5f;
        if (isAngel)
        {
            animator.SetBool("Angel", true);
            InvokeRepeating("AngelRecovery", 0f, 5f);
            Invoke("BecomeDevil", 300f);
        }
        else
        {
            animator.SetBool("Angel", false);
            InvokeRepeating("DevilDecrease", 0f, 10f);
        }
    }

    private void AngelRecovery()
    {
        if (!Escape)
        {
            CancelInvoke("AngelRecovery");
            CancelInvoke("DevilDecrease");
            CancelInvoke("BecomeDevil");

            return;
        }

        Employee[] employees = FindObjectsOfType<Employee>();
        foreach (Employee employee in employees)
        {
            employee.RecoverMental(1);
        }
    }

    private void DevilDecrease()
    {
        if (!Escape)
        {

            CancelInvoke("DevilDecrease");
            return;
        }

        Employee[] employees = FindObjectsOfType<Employee>();
        foreach (Employee employee in employees)
        {
            employee.DecreaseMental(100 * 0.05f);
        }
    }

    private void BecomeDevil()
    {
        if (!Escape)
        {
            CancelInvoke("DevilDecrease");
            return;
        }

        CancelInvoke("AngelRecovery");
        CancelInvoke("DevilDecrease");
        animator.SetBool("Angel",false);
        InvokeRepeating("DevilDecrease", 0f, 10f);
    }
}
