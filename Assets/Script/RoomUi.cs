using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomUi : MonoBehaviour
{
    [SerializeField] Room[] Rooms;
    [SerializeField] Slider[] EscapeSlider;
    [SerializeField] Slider[] GrowSlider;
    void Start()
    {
        
    }

    void Update()
    {
        for(int i = 0; i < Rooms.Length; i++)
        {
            EscapeSlider[i].value = Rooms[i].Escape_Value/100;
            GrowSlider[i].value = Rooms[i].Grow_Value/100;
        }
    }
    
    
}
