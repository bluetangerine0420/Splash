using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomUi : MonoBehaviour
{
    public Room[] Rooms;
    [SerializeField] Slider[] EscapeSlider;
    [SerializeField] Slider[] GrowSlider;
    [SerializeField] Sprite[] SplashImages;
    [SerializeField] Image[] RoomsSplash;
    void Start()
    {
        
    }

    void Update()
    {
        for(int i = 0; i < Rooms.Length; i++)
        {
            EscapeSlider[i].value = Rooms[i].Escape_Value/100;
            GrowSlider[i].value = Rooms[i].Grow_Value/100;
            if (Rooms[i].CareSplash!=null)
            {
                switch (Rooms[i].CareSplash.Name) {
                    case "Ray": RoomsSplash[i].sprite = SplashImages[0]; Rooms[i].CareSplash.Escape = true; /*StartCoroutine(EscapeTrue(i));*/ break;
                    case "StarFish": RoomsSplash[i].sprite = SplashImages[1]; Rooms[i].CareSplash.Escape = true; /*StartCoroutine(EscapeTrue(i));*/ break;
                    case "Whale": RoomsSplash[i].sprite = SplashImages[2]; Rooms[i].CareSplash.Escape = true; /*StartCoroutine(EscapeTrue(i));*/break;
                    case "Eel": RoomsSplash[i].sprite = SplashImages[3]; Rooms[i].CareSplash.Escape = true; /*StartCoroutine(EscapeTrue(i));*/ break;
                    case "Shark": RoomsSplash[i].sprite = SplashImages[4]; Rooms[i].CareSplash.Escape = true; /*StartCoroutine(EscapeTrue(i));*/break;
                    case "Crotch": RoomsSplash[i].sprite = SplashImages[5]; Rooms[i].CareSplash.Escape = true; /*StartCoroutine(EscapeTrue(i));*/ break;
                    default: RoomsSplash[i].sprite = SplashImages[6]; Rooms[i].CareSplash.Escape = true; /*StartCoroutine(EscapeTrue(i));*/break;
                }
            }
        }

    }


    //IEnumerator EscapeTrue(int i)
    //{
    //    yield return new WaitForSeconds(2.0f);
    //    Rooms[i].CareSplash.Escape = true;
    //}

    
    
}
