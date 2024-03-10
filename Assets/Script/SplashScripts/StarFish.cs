using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfish : Splash
{
    private Dictionary<Employee, float> slowedEmployee = new Dictionary<Employee, float>();
  

    public Collider2D rangeCollider;
    private Employee collidedEmployee;
    public bool isEscaped = false;

    void Start()
    {

    }

    void Update()
    {
        Move();
        if (!Escape)
        {
            if(isEscaped)
            {
                collidedEmployee.Speed *= 2;
                isEscaped = false;
                 
            }
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Escape && other.CompareTag("Employee"))
        {
            Employee employeeScript = other.GetComponent<Employee>();
            if (employeeScript != null && !slowedEmployee.ContainsKey(employeeScript))
            {
                slowedEmployee.Add(employeeScript, employeeScript.Speed);
                collidedEmployee = employeeScript;
                employeeScript.Speed /= 2;
                isEscaped = true;
}
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (Escape && other.CompareTag("Employee"))
        {
            Employee employeeScript = other.GetComponent<Employee>();
            if (employeeScript != null && slowedEmployee.ContainsKey(employeeScript))
            {
                employeeScript.Speed = slowedEmployee[employeeScript];
                slowedEmployee.Remove(employeeScript);
                collidedEmployee = null; 
            }
        }
    }



}
