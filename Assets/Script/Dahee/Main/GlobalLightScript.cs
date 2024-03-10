using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLightScript : MonoBehaviour
{
    public Light2D globalLight; 
    public Crotch crotch;

    private Color darkColor = new Color(1f / 255f, 1f / 255f, 1f / 255f);

    private Color lightColor = Color.white; 

    void Start()
    {
        UpdateLightColor();
    }

    void Update()
    {
        UpdateLightColor();
    }

    void UpdateLightColor()
    {
     
        if (crotch.Escape)
        {
            globalLight.color = darkColor;
        }
        else
        {
            globalLight.color = lightColor;
        }
    }
}
