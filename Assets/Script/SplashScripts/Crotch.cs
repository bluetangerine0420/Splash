
using UnityEngine;

public class Crotch : Splash
{

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
            EscapeAct();
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
        else if (Left_Move)
        {

            Vector2 movement = new Vector2(-1, -0.01f) * Move_Spd * Time.deltaTime;
            GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + movement);


        }
    }

    void EscapeAct()
    {
        

    }
}
