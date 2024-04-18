using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLightScript : MonoBehaviour
{
    public Light2D globalLight; 
    public Crotch crotch;

    private Color darkColor = new Color(1f / 255f, 1f / 255f, 1f / 255f);

    private Color lightColor = Color.white;

    Room room;
    Room room2;
    Room room3;
    Room room4; 
    Room room5;
    Room room6;
    Room room7;
    Room room8;
    Room room9;





    void Start()
    {
        globalLight.color = lightColor;
        room = GameObject.Find("1-1").GetComponent<Room>();
        room2 = GameObject.Find("1-2").GetComponent<Room>();
        room3 = GameObject.Find("1-3").GetComponent<Room>();
        room4 = GameObject.Find("2-1").GetComponent<Room>();
        room5 = GameObject.Find("2-2").GetComponent<Room>();
        room6 = GameObject.Find("2-3").GetComponent<Room>();
        room7 = GameObject.Find("3-1").GetComponent<Room>();
        room8 = GameObject.Find("3-2").GetComponent<Room>();
        room9 = GameObject.Find("3-3").GetComponent<Room>();
    }

    void Update()
    {
     
        
        UpdateLightColor();
        
    }

    public void UpdateLightColor()
    {

       
            if (room.isCrotch==true ||room2.isCrotch == true|| room3.isCrotch == true|| room4.isCrotch == true|| room5.isCrotch == true|| room6.isCrotch == true|| room7.isCrotch == true||room8.isCrotch == true|| room9.isCrotch == true)
            {
                globalLight.color = darkColor;
            }
            else
            {
                globalLight.color = lightColor;
            }
      
            
        
     
       
    }


    
}
