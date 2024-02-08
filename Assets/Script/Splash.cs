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
    public float Cur_Atk_Spd;
    public float Max_Atk_Spd;

    public float Move_Spd;
    public bool Left_Move;
    public bool Right_Move;

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
    public void Move1()
    {
        
    }

    void OnTriggerEnter2D()
    {
        if (AttackRange.gameObject.tag == "Employee")
        {
            AttackReady = true;
        }
    }
    void OnTriggerExit2D()
    {
        if (AttackRange.gameObject.tag == "Employee")
        {
            AttackReady = false;
        }
    }

}
