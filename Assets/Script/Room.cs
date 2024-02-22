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

    public Splash CareSplash;

    public Vector3 RoomPosition;


    public float Espace_Value;
    public bool Escpae;

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

    public void Care()
    {
        if (CareSplash != null)
        {
            Espace_Value += Time.deltaTime * 0.1f;
        }
    }

    public void Click()
    {
        OpenUI.SetActive(true);
    }

    void OnMouseOver()
    {
        Click();
    }



}
