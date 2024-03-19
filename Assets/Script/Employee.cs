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


    float Cur_Atk_Spd;
    float Max_Atk_Spd;

    int Work_Time;
    float Work_percent;
    float Work_Spd;

    [SerializeField] int Floor;
    public float Speed;
    [SerializeField] bool LeftMoving = false;
    [SerializeField] bool RightMoving = false;
    [SerializeField] bool OnElevator;
    [SerializeField] bool AttackReady;
    [SerializeField] bool Moving = false;
    [SerializeField] bool Caring = false;
    [SerializeField] int Care_Value;

    int Lv;
    int Exp;


    public GameObject Elevator;

    public Room TargetRoom;
    public Splash TargetSplash;

    [SerializeField] GameObject[] RoomsPos;
    [SerializeField] GameObject[] FloorPos;

    Item[] Item_list = new Item[3];



    void Start()
    {
        Mental = 100;
        Hp = 100;
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
        if (collision.gameObject.tag == "AttackRange")
        {
            AttackReady = true;
            TargetSplash = collision.gameObject.GetComponent<Splash>();
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Elevator")
        {
            OnElevator = false;
        }
        if(collision.gameObject.tag == "AttackRange")
        {
            AttackReady = false;
            TargetSplash = null;
        }
    }

    void MoveRoom()
    {
        if (TargetRoom.Floor != this.Floor)
        {
            RightMoving = true;
            if (OnElevator)
            {
                switch (TargetRoom.Floor)
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
                this.Floor = TargetRoom.Floor;
                RightMoving = false;
                LeftMoving = true;
            }
        }
        else if (gameObject.transform.position.x < TargetRoom.RoomPosition.x)
            RightMoving = true;

        else if (gameObject.transform.position.x > TargetRoom.RoomPosition.x)
            LeftMoving = true;

        if ((TargetRoom.RoomPosition.x - 1 < this.transform.position.x && this.transform.position.x < TargetRoom.RoomPosition.x + 1) && TargetRoom.Floor == this.Floor)
        {
            RightMoving = false;
            LeftMoving = false;
            Moving = false;
            if(!TargetRoom.CareSplash)
            Caring = true;
        }
        
    }

    IEnumerator Care()
    {
        Caring = false;
        yield return new WaitForSeconds(2.0f);
        if (TargetRoom.Espace_Value - Care_Value > 0)
            TargetRoom.Espace_Value -= Care_Value;
        else TargetRoom.Espace_Value = 0;
    }

     void Attack()
    {
        if (AttackReady&&TargetSplash!=null)
        {
            if (Max_Atk_Spd <= Cur_Atk_Spd)
            {
                TargetSplash.Hp -= Atk;
            }
            else Cur_Atk_Spd += Time.deltaTime;
        }
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

    public void DecreaseHp(float amount)
    {
        Hp -= (int)amount;
        Debug.Log("Decreased Hp: " + Hp);
    }

}
