using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Splash : MonoBehaviour
{
    public string Name;

    public int Hp;
    public int Atk;
    public float Cur_Atk_Spd;
    public float Max_Atk_Spd;


    public float Move_Spd;
    public bool Left_Move;
    public bool Right_Move;
    public float Move_Max_Time;
    public float Move_Cur_Time;

    public bool Escape = false;
    public float Escape_Value;

    public float Grow_Value;
    public int Grow;
    
    public float Cur_Death_Value;
    public float Max_Death_Value;
    public float Death_Value;
   

    public Employee[] Employees;

    public bool AttackReady;
    public Collider2D AttackRange;

    public SpriteRenderer splashRenderer;

    
    

    private void Start()
    {
     
    }
    private void Update()
    {

        if (Cur_Death_Value > Max_Death_Value)
        {
            Destroy(gameObject);
        }
        else { Cur_Death_Value += Time.deltaTime * Death_Value; }
    }



    public void Move()
    {

        if (Move_Max_Time < Move_Cur_Time)
        {
            switch (Random.Range(0, 2))
            {
                case 0:
                    {
                        splashRenderer.flipX = false;
                        Left_Move = true;
                        Right_Move = false;
                        Move_Cur_Time = 0;
                    }
                    break;
                case 1:
                    {
                        splashRenderer.flipX = true;
                        Left_Move = false;
                        Right_Move = true;
                        Move_Cur_Time = 0;
                    }
                    break;
            }
        }
        else Move_Cur_Time += Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Employee")
        {
            AttackReady = true;
            Employee[] employees = FindObjectsOfType<Employee>();
            for (int i = 0; i < employees.Length; i++)
            {
                if (collider.gameObject == employees[i])
                    employees[i].DecreaseHp(5);
            }
        }
           
        
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Employee")
        {
            AttackReady = false;
        }
    }



}