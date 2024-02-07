using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomUi : MonoBehaviour
{
    [SerializeField] GameObject[] Button;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ButtonSetting()
    {
        switch (GameManager.Gameinstance.Employee_Num)
        {
            case 0: 
                break; 
            case 1: 
                break;
        }
    } 
}
