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

    }

    void RoomCheck()
    {
        int check = 0;
        for (int i = 0; i < 9; i++)
        {
            if (Rooms[i].CareSplash) check++;
        }
        Room_Num = check;
        // Update is called once per frame
    }
}
