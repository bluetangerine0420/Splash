using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SpotLightScript : MonoBehaviour
{
    public Light2D spotLight;
    public Crotch crotch;

    private Color darkColor =Color.black;
    private Color lightColor = Color.white;

    void Start()
    {
        UpdateLightColor();
    }

    void Update()
    {
        crotch = FindObjectOfType<Crotch>();
        UpdateLightColor();
    }

    void UpdateLightColor()
    {
      
        if(crotch != null)
        {
            if (crotch.Escape)
            {
                spotLight.color = lightColor;
                Vector3 crotchPosition = crotch.transform.position;
                transform.position = new Vector3(crotchPosition.x, crotchPosition.y, transform.position.z);
            }
            else
            {
                spotLight.color = darkColor;
            }
        }
        
    }
}
