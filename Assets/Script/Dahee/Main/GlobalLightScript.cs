using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering.Universal;

public class GlobalLightScript : MonoBehaviour
{
    public Light2D globalLight; 
   
    public GameObject crotch;

    private Color darkColor = new Color(1f / 255f, 1f / 255f, 1f / 255f);

    private Color lightColor = Color.white;






    void Start()
    {
        globalLight.color = lightColor;
       
    }

    void Update()
    {
     
        
        UpdateLightColor();

        if (crotch == null)
        {
            crotch = GameObject.Find("Crotch(Clone)");

            if (crotch == null)
                globalLight.color = lightColor;

            return;
        }

    }

    public void UpdateLightColor()
    {

       
     
      
            
        
     
       
    }


    
}
