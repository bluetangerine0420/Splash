using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Employee : MonoBehaviour
{
    string Name;
    public Animator animator;

    public SpriteRenderer EmployeeRenderer;
    public int Atk { get; private set; }
    public int Int { get; private set; }
    public int Luck { get; private set; }
    public float Hp;
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
    [SerializeField] bool Hitting = false;

    [SerializeField] float Cur_Care;
    [SerializeField] float Max_Care;
    [SerializeField] int CarePower;

    public GameObject Elevator;

    public Room TargetRoom;
    public Splash TargetSplash;

    [SerializeField] GameObject[] RoomsPos;
    [SerializeField] GameObject[] FloorPos;

    [SerializeField] GameObject prfhpBar;
    [SerializeField] Image HpFill;
    [SerializeField] GameObject Canvas;

    RectTransform hpBar;

    SpriteRenderer spriteRenderer;
    Item[] Item_list = new Item[3];

    void Start()
    {
        Mental = 100;
        Hp = 100;
        hpBar = Instantiate(prfhpBar, Canvas.transform).GetComponent<RectTransform>();
        HpFill = hpBar.transform.GetChild(0).GetComponent<Image>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Moving)
        {
            animator.SetBool("Walk", true);
            MoveRoom();
        }
        else
        {
            animator.SetBool("Walk", false);
        }
        if (Caring)
        {
            animator.SetBool("Work", true);

        }
        else
        {
            animator.SetBool("Work", false);
        }
        if (Moving) MoveRoom();
        if (Caring) Care();
        if (Hitting)
        {
            StartCoroutine("HitAnimation");
            Hitting = false;
        }
        if (Hp <= 0) gameObject.SetActive(false);
        HpUpdate();
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
        if (collision.gameObject.tag == "AttackRange")
        {
            AttackReady = false;
            TargetSplash = null;
        }
    }

    void MoveRoom()
    {
        if (TargetRoom.Floor != this.Floor)
        {
            EmployeeRenderer.flipX = true;
            RightMoving = true;
            if (OnElevator)
            {
                switch (TargetRoom.Floor)
                {
                    case 1:
                        gameObject.transform.position = new Vector2(40, FloorPos[0].transform.position.y - 2);
                        break;
                    case 2:
                        gameObject.transform.position = new Vector2(40, FloorPos[1].transform.position.y - 2);
                        break;
                    case 3:
                        gameObject.transform.position = new Vector2(40, FloorPos[2].transform.position.y - 2);
                        break;
                }
                this.Floor = TargetRoom.Floor;
                RightMoving = false;
                LeftMoving = true;
            }
        }
        else if (gameObject.transform.position.x < TargetRoom.RoomPosition.x)
        {
            EmployeeRenderer.flipX = true;
            RightMoving = true;
        }
        else if (gameObject.transform.position.x > TargetRoom.RoomPosition.x)
            EmployeeRenderer.flipX = false; LeftMoving = true;

        if ((TargetRoom.RoomPosition.x - 1 < this.transform.position.x && this.transform.position.x < TargetRoom.RoomPosition.x + 1) && TargetRoom.Floor == this.Floor)
        {
            RightMoving = false;
            LeftMoving = false;
            Moving = false;
            if (TargetRoom.CareSplash != null)
                Caring = true;
        }

    }
    public void MoveSetting(Room room)
    {
        TargetRoom = room;
        Moving = true;
    }

    void Care()
    {
        if (Max_Care <= Cur_Care)
        {
            Caring = false;
            Cur_Care = 0;
            TargetRoom.Escape_Value -= CarePower;
        }
        else
            Cur_Care += Time.deltaTime * CarePower;
    }
    void Attack()
    {
        if (AttackReady && TargetSplash != null)
        {
            if (Max_Atk_Spd <= Cur_Atk_Spd)
            {
                TargetSplash.Hp -= Atk;
            }
            else Cur_Atk_Spd += Time.deltaTime;
        }
    }

    void HpUpdate()
    {
        if (Hp < 100) Hp += 0.01f;
        Vector3 _hpBarPos =
            Camera.main.WorldToScreenPoint(new Vector3(transform.position.x - 1.5f, transform.position.y + 1.5f, 0));
        hpBar.position = _hpBarPos;
        HpFill.fillAmount = Hp * 0.01f;
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
            emplSelect.UpdateStatsText(Atk, Int, Luck, (int)Hp, Mental);
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
        Hp -= amount;
        Debug.Log("Decreased Hp: " + Hp);
    }

    IEnumerator HitAnimation()
    {

        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(0.1f);
    }
}
