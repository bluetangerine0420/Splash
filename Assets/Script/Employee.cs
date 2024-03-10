using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Employee : MonoBehaviour
{
    string Name;


    public int Atk { get; private set; }
    public int Int { get; private set; }
    public int Luck { get; private set; }
    public int Hp { get; private set; }
    public int Mental { get; private set; }


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
    [SerializeField] bool Caring = false;
    [SerializeField] int Care_Value;

    int Lv;
    int Exp;


    public GameObject Elevator;

    public Room targetroom;

    [SerializeField] GameObject[] RoomsPos;
    [SerializeField] GameObject[] FloorPos;

    Item[] Item_list = new Item[3];



    void Start()
    {
        Mental = 100;
    }

    void Update()
    {
        if (Moving)
            MoveRoom();
        if (Caring)
            StartCoroutine(Care());
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
        else if (gameObject.transform.position.x < targetroom.RoomPosition.x)
            RightMoving = true;

        else if (gameObject.transform.position.x > targetroom.RoomPosition.x)
            LeftMoving = true;

        if ((targetroom.RoomPosition.x - 1 < this.transform.position.x && this.transform.position.x < targetroom.RoomPosition.x + 1) && targetroom.Floor == this.Floor)
        {
            RightMoving = false;
            LeftMoving = false;
            Moving = false;
            if(!targetroom.CareSplash)
            Caring = true;
        }
        
    }

    IEnumerator Care()
    {
        Caring = false;
        yield return new WaitForSeconds(2.0f);
        if (targetroom.Espace_Value - Care_Value > 0)
            targetroom.Espace_Value -= Care_Value;
        else targetroom.Espace_Value = 0;
    }

    public void SetRandomStats()
    {
        Atk = Random.Range(1, 6);
        Luck = Random.Range(1, 6);
        Hp = Random.Range(1, 6);
        Mental = Random.Range(1, 6);
        Int = Random.Range(1, 6);

        UpdateEmployeeStats();
    }


    void UpdateEmployeeStats()
    {
        EmplSelect emplSelect = FindObjectOfType<EmplSelect>();
        if (emplSelect != null)
        {
            emplSelect.UpdateStatsText(Atk, Int, Luck, Hp, Mental);
        }
    }


    public void RecoverMental(int amount)
    {
        Mental += amount;
        Debug.Log("Recovered Mental: " + Mental);
    }

    public void DecreaseMental(float amount)
    {
        Mental -= (int)amount;
        Debug.Log("Decreased Mental: " + Mental);
    }




}
