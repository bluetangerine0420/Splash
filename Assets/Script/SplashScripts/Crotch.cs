
using UnityEngine;

public class Crotch : Splash
{


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Escape)
        {
            EscapeAct();
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
