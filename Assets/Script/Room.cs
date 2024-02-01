using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Room : MonoBehaviour
{
    public bool Open;
    bool Now_Click = false;

    public int Floor;
    public int Room_Num;
    public int Room_Lv;

    public Sprite[] Room_Speites;
    SpriteRenderer RoomRenderer;

    public GameObject OpenUI;
    public TextMeshProUGUI Open_text;

    public Vector3 RoomPosition;

    enum Room_Type
    {
        Cage,
        Hospital,
        Library,
        Restroom,
        Factory,
        None
    }
    Room_Type Room_Now = Room_Type.None;


    void Awake()
    {
        RoomRenderer = GetComponent<SpriteRenderer>();

    }
    void Start()
    {
     RoomPosition=this.transform.position;
    }
    void Update()
    {

    }


    void OnMouseOver()
    {
        Click();
        //Room_Setting();
    }


    public void Click()
    {
        if (!Now_Click && Input.GetMouseButtonDown(0))
        {
            Room_Ui_Open();
            Now_Click = true;
        }

        else if (Now_Click && Input.GetMouseButtonUp(0))
        {
            Now_Click = false;
        }

    }

    void Room_Setting()
    {
        if (Open)
        {
            switch (Room_Now)
            {
                case Room_Type.Cage:
                    RoomRenderer.sprite = Room_Speites[0];
                    break;

                case Room_Type.Hospital:
                    RoomRenderer.sprite = Room_Speites[1];
                    break;

                case Room_Type.Library:
                    RoomRenderer.sprite = Room_Speites[2];
                    break;

                case Room_Type.Restroom:
                    RoomRenderer.sprite = Room_Speites[3];
                    break;

                case Room_Type.Factory:
                    RoomRenderer.sprite = Room_Speites[4];
                    break;
                case Room_Type.None:
                    RoomRenderer.sprite = Room_Speites[5];
                    break;
                default: break;
            }
        }
        else if (!Open)
        {
            RoomRenderer.sprite = Room_Speites[6];
        }
    }

    public void Room_Open()
    {
        if (!Open && GameManager.Gameinstance.Ops > 100)
        {
            Open = true;
            GameManager.Gameinstance.Ops -= 100;
        }
    }

    public void Room_Ui_Open()
    {
        if (!Open)
        OpenUI.SetActive(true);
    }

}
