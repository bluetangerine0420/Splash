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

    public GameObject Ui;

    public Splash CareSplash;
    public Sprite[] Room_Speites;
    [SerializeField]bool[] whatSplash;
    public Vector3 RoomPosition;

    public float Work_Time;
    public float Work_percent;
    public float Work_Spd;

    SpriteRenderer SpriteRenderer;
    void Awake()
    {
        RoomPosition = this.transform.position;
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {

    }
    void Update()
    {
        RoomUpdate();
    }

    void RoomUpdate()
    {
        if (CareSplash != null)
        {
            switch (CareSplash.Name)
            {
                case "Ray":whatSplash[0]=true; break;
                case "StarFish": whatSplash[1] = true; break;
                case "Whale": whatSplash[2] = true; break;
                case "Eel": whatSplash[3] = true; break;
                case "Shark": whatSplash[4] = true; break;
                case "Crotch": whatSplash[5] = true; break;
            }
            if (whatSplash[0]) SpriteRenderer.sprite = Room_Speites[0];
            else if (whatSplash[1]) SpriteRenderer.sprite = Room_Speites[1];
            else if (whatSplash[2]) SpriteRenderer.sprite = Room_Speites[2];
            else if (whatSplash[3]) SpriteRenderer.sprite = Room_Speites[3];
            else if (whatSplash[4]) SpriteRenderer.sprite = Room_Speites[4];
            else if (whatSplash[5]) SpriteRenderer.sprite = Room_Speites[5];
        }
    }

    public void Click()
    {
        if (Input.GetMouseButtonDown(0))
            Ui.SetActive(true);
    }

    void OnMouseOver()
    {
        Click();
    }
}
