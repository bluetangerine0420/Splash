using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SpotLightScript : MonoBehaviour
{
    public Light2D spotLight;
   
    public GameObject crotch;
  

    private Color darkColor = Color.black;
    private Color lightColor = Color.white;

    void Start()
    {
        UpdateLightColor();
       
       
    }

    void Update()
    {
        if (crotch == null)
        {
            crotch = GameObject.Find("Crotch(Clone)");

            if (crotch == null)
                spotLight.color = darkColor;
            
            return;
        }

        UpdateLightPosition();
        UpdateLightColor();
    }

    void UpdateLightPosition()
    {
        
        Vector3 crotchPosition = crotch.transform.position;
        transform.position = new Vector3(crotchPosition.x, crotchPosition.y, transform.position.z);
    }

    void UpdateLightColor()
    {
      
        if (crotch != null)
        {
            spotLight.color = lightColor;
        }
        else
        {
           
            spotLight.color = darkColor;
        }
    }
}
