using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Ops;

    public int Splash_Num;
    public int Room_Num;
    public Room[] Rooms;
    public static GameManager Gameinstance = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        if (Gameinstance == null)
        {
            Gameinstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (Gameinstance != this)
                Destroy(this.gameObject);
        }
    }

    void Update()
    {
        RoomCheck();
    }

    void RoomCheck()
    {
        if (Rooms[0].CareSplash == null) Room_Num = 0;
        else if (Rooms[1].CareSplash == null) Room_Num = 1;
        else if (Rooms[2].CareSplash == null) Room_Num = 2;
        else if (Rooms[3].CareSplash == null) Room_Num = 3;
        else if (Rooms[4].CareSplash == null) Room_Num = 4;
        else if (Rooms[5].CareSplash == null) Room_Num = 5;
        else if (Rooms[6].CareSplash == null) Room_Num = 6;
        else if (Rooms[7].CareSplash == null) Room_Num = 7;
        else if (Rooms[8].CareSplash == null) Room_Num = 8;
        // Update is called once per frame
    }
}
