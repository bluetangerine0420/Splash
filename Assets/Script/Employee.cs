using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Employee : MonoBehaviour
{
    string Name;

    int Strange;
    int Intelligent;
    int Luck;
    int Hp;
    int Mental;

    float Atk_Spd;

    int Work_Time;
    float Work_percent;
    float Work_Spd;

    [SerializeField] int Floor;
    public float Speed;
    [SerializeField] bool LeftMoving = false;
    [SerializeField] bool RightMoving = false;
    [SerializeField] bool OnElevator;
    [SerializeField] bool Moving = false;

    int Lv;
    int Exp;


    public GameObject Elevator;
    public Room targetroom;
    [SerializeField] GameObject[] RoomsPos;
    [SerializeField] GameObject[] FloorPos;

    enum Condition
    {

    }
    enum Characteristic
    {

    }

    Item[] Item_list = new Item[3];



    void Start()
    {

    }

    void Update()
    {
        if (Moving)
            MoveRoom();
    }
    void FixedUpdate()
    {
        if (RightMoving)
        {
            Vector2 movement = new Vector2(1, -0.01f) * Speed * Time.deltaTime;
            GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + movement);
        }
        else if (LeftMoving)
        {
            Vector2 movement = new Vector2(-1, -0.01f) * Speed * Time.deltaTime;
            GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + movement);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Elevator")
        {
            OnElevator = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Elevator")
        {
            OnElevator = false;
        }
    }

    void MoveRoom()
    {
        if (targetroom.Floor != this.Floor)
        {
            RightMoving = true;
            if (OnElevator)
            {
                switch (targetroom.Floor)
                {
                    case 1:
                        gameObject.transform.position = new Vector2(40, FloorPos[0].transform.position.y);
                        break;
                    case 2:
                        gameObject.transform.position = new Vector2(40, FloorPos[1].transform.position.y);
                        break;
                    case 3:
                        gameObject.transform.position = new Vector2(40, FloorPos[2].transform.position.y);
                        break;
                }
                this.Floor = targetroom.Floor;
                RightMoving = false;
                LeftMoving = true;
            }
        }
        else if(gameObject.transform.position.x < targetroom.RoomPosition.x)
            RightMoving = true;

        else if (gameObject.transform.position.x > targetroom.RoomPosition.x)
            LeftMoving = true;
        
        if ((targetroom.RoomPosition.x-1<this.transform.position.x && this.transform.position.x<targetroom.RoomPosition.x+1) &&targetroom.Floor==this.Floor)
        {
            RightMoving = false;
            LeftMoving = false;
            Moving = false;
        }

    }

    public void MoveCheck(Room room)
    {
        targetroom = room;
        Moving = true;
    }

    public void SetRandomStats()
    {
        Strange = Random.Range(1, 6);
        Intelligent = Random.Range(1, 6);
        Luck = Random.Range(1, 6);
        Hp = Random.Range(1, 6);
        Mental = Random.Range(1, 6);
    }

}
