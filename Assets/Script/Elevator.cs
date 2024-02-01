using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public bool OnEpolyee = false;
    public int CurFloor = 1;
    public int GoingFloor;
    [SerializeField] bool Up;
    [SerializeField] bool Down;
    [SerializeField] GameObject[] FloorPos;
    Rigidbody2D EleRigid;
    // Start is called before the first frame update
    void Start()
    {
        EleRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpDownMove();
        FloorCheck();
    }
    void FixedUpdate()
    {
        if(Up)
        {
            Vector2 movement = new Vector2(0, 1) * 3 * Time.deltaTime;
            GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + movement);
        }
        else if(Down)
        {
            Vector2 movement = new Vector2(0, -1) * 3 * Time.deltaTime;
            GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + movement);
        }
    }
    void UpDownMove()
    {
        if (OnEpolyee)
        {
            if (CurFloor > GoingFloor)
            {
                Down = true;
            }
            else if (CurFloor < GoingFloor)
            {
                Up = true;
            }
            if(CurFloor == GoingFloor)
            {
                Down = false;
                Up = false;
            }
        }
    }
    void FloorCheck()
    {
        if (FloorPos[0].transform.position.y == gameObject.transform.position.y)
        {
            CurFloor = 1;
        }
        if (FloorPos[1].transform.position.y >= gameObject.transform.position.y)
        {
            CurFloor = 2;
        }
        if (FloorPos[2].transform.position.y == gameObject.transform.position.y)
        {
            CurFloor = 3;
        }
        if (FloorPos[3].transform.position.y == gameObject.transform.position.y)
        {
            CurFloor = 4;
        }
    }
}
