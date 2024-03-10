using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Room : MonoBehaviour
{

    public int Floor;
    public int Room_Num;

    public Sprite[] Room_Speites;
    SpriteRenderer RoomRenderer;

    public GameObject OpenUI;

    public bool CareSplash;
    public GameObject[] Splashes;

    public Vector3 RoomPosition;


    public float Espace_Value;
    public bool Escpae;

    public float Grow_Value;
    public int Grow;

    public float Work_Time;
    public float Work_percent;
    public float Work_Spd;

    void Awake()
    {
        RoomRenderer = GetComponent<SpriteRenderer>();
        RoomPosition = this.transform.position;
    }
    void Start()
    {

    }
    void Update()
    {

    }



    public void Click()
    {
        if(Input.GetMouseButtonDown(0))
        OpenUI.SetActive(true);
    }

    void OnMouseOver()
    {
        Click();
    }
}
