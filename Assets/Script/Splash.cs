using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    public string Name;

    public float Espace_Value;
    public bool Escpae;

    public float Grow_Value;
    public int Grow;

    public int Hp;
    public int Atk;
    public int Def;
    public float Move_Spd;
    public float Cur_Atk_Spd;
    public float Max_Atk_Spd;

    public float Death_Value;

    public float Work_Time;
    public float Work_percent;
    public float Work_Spd;

    public bool AttackReady;
    public Collider2D AttackRange;

    public void Attack()
    {
        if (AttackReady && Max_Atk_Spd < Cur_Atk_Spd)
        {
            //attack code
            Cur_Atk_Spd = 0;
        }
        else Cur_Atk_Spd += Time.deltaTime;
    }
    public void Move()
    {
        if (!AttackReady)
        {
            switch (Random.Range(0, 1))
            {
                case 0:
                    {
                        Vector2 movement = new Vector2(1, -0.01f) * Move_Spd * Time.deltaTime;
                        for (int i = 0; i < 5; i++)
                            GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + movement);
                    }
                    break;
                case 1:
                    {
                        Vector2 movement = new Vector2(-1, -0.01f) * Move_Spd * Time.deltaTime;
                        for (int i = 0; i < 5; i++)
                            GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + movement);
                    }
                    break;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Empolyee")
        {
            AttackReady = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Empolyee")
        {
            AttackReady = false;
        }
    }
}
