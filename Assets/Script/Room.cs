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
    public float Escape_Value;
    public float Escape_Power;
    public float Grow_Value;
    public float Grow_Power;
    public Sprite[] Room_Speites;
    [SerializeField]bool[] whatSplash;
    [SerializeField] GameObject[] Splashes;
    public Vector3 RoomPosition;

    public float Work_Time;
    public float Work_percent;
    public float Work_Spd;
   

    
    Animator animator;
    void Awake()
    {
        RoomPosition = this.transform.position;
        animator = GetComponent<Animator>();
    }
    void Start()
    {

    }
    void Update()
    {
        RoomUpdate();
        Grow();
        Escape();
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
            if (whatSplash[0]) animator.SetInteger("CageSet",1);
            else if (whatSplash[1]) animator.SetInteger("CageSet", 2);
            else if (whatSplash[2]) animator.SetInteger("CageSet", 3);
            else if (whatSplash[3]) animator.SetInteger("CageSet", 4);
            else if (whatSplash[4]) animator.SetInteger("CageSet", 5);
            else if (whatSplash[5]) animator.SetInteger("CageSet", 6);
        }
    }
    void Grow()
    {
        if (CareSplash != null)
        {
            Grow_Value += Time.deltaTime * Grow_Power;
        }
        else if(CareSplash == null)
        {
            Grow_Value = 0;
        }
        if(Grow_Value > 100 && CareSplash != null)
        {
            CareSplash = null;
            for (int i = 0; i < Splashes.Length; i++)
            {
                whatSplash[i] = false;
            }
            animator.SetInteger("CageSet", 0);
            if(GameManager.Gameinstance!=null) GameManager.Gameinstance.ClearSplash++;
        }
    }

    void Escape()
    {
       
        if (CareSplash != null)
        {
            Escape_Value += Time.deltaTime * Escape_Power;
        }
        else if (CareSplash == null)
        {
            Escape_Value = 0;
        }
        if (Escape_Value > 100 && CareSplash != null)
        {
            switch (CareSplash.Name)
            {
                case "Ray": Instantiate(Splashes[0], transform); break;
                case "StarFish": Instantiate(Splashes[1], transform); break;
                case "Whale": Instantiate(Splashes[2], transform); break;
                case "Eel": Instantiate(Splashes[3], transform); break;
                case "Shark": Instantiate(Splashes[4], transform); break;
                case "Crotch": Instantiate(Splashes[5], transform); break;
            }
            
            CareSplash = null;
            for(int i = 0; i < Splashes.Length; i++)
            {
                whatSplash[i]=false;
            }
            animator.SetInteger("CageSet", 0);
        }
    }


}
