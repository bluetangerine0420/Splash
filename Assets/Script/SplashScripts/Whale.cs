using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Whale : Splash
{
    private bool hasEscaped = false;
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

        if (Escape && !hasEscaped) 
        {
            EscapeAct();
            hasEscaped = true; 
        }
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
        else if (Left_Move)
        {

            Vector2 movement = new Vector2(-1, -0.01f) * Move_Spd * Time.deltaTime;
            GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + movement);


        }
    }

    void EscapeAct()
    {
        Starfish starfishObject = GetComponent<Starfish>();
        if (starfishObject != null)
        {
            starfishObject.Escape_Value = (int)(starfishObject.Escape_Value * 1.3f);
        }

        Shark sharkObject = GetComponent<Shark>();
        if (sharkObject != null)
        {
            sharkObject.Escape_Value = (int)(sharkObject.Escape_Value * 1.3f);
        }

        Crotch crotchObject = GetComponent<Crotch>();
        if (crotchObject != null)
        {
            crotchObject.Escape_Value = (int)(crotchObject.Escape_Value * 1.3f);
        }

        Eel eelObject = GetComponent<Eel>();
        if (eelObject != null)
        {
            eelObject.Escape_Value = (int)(eelObject.Escape_Value * 1.3f);
        }

        Raysplash rayObject = GetComponent<Raysplash>();
        if (rayObject != null)
        {
            rayObject.Escape_Value = (int)(rayObject.Escape_Value * 1.3f);
        }
    }
}
