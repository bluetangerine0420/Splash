using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale: Splash
{
  

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Escape)
        {
            EscapeAct();
        }
    }

    void FixedUpdate()
    {
        if (Right_Move)
        {
            
            Vector2 movement = new Vector2(1, -0.01f) * Move_Spd * Time.deltaTime;
            GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + movement);
        
        }
        else if(Left_Move)
        {
           
            Vector2 movement = new Vector2(-1, -0.01f) * Move_Spd * Time.deltaTime;
            GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + movement);

           
        }
    }

    void EscapeAct()
    {
        Starfish starfishObject = GetComponent<Starfish>();
        Shark SharkObject = GetComponent<Shark>();
        Crotch CrotchObject = GetComponent<Crotch>();
        Eel EelObject = GetComponent<Eel>();
        Seal SealObject = GetComponent<Seal>();
        Turtle TurtleObject = GetComponent<Turtle>();
        Lobster LobsterObject = GetComponent<Lobster>();
        Raysplash RayObject = GetComponent<Raysplash>();
        Seacucumber SeacucumberObject = GetComponent<Seacucumber>();

        starfishObject.Escape_Value = (int)(starfishObject.Escape_Value * 1.3f);
        SharkObject.Escape_Value = (int)(SharkObject.Escape_Value * 1.3f);
        CrotchObject.Escape_Value = (int)(CrotchObject.Escape_Value * 1.3f);
        EelObject.Escape_Value = (int)(EelObject.Escape_Value * 1.3f);
        SealObject.Escape_Value = (int)(SealObject.Escape_Value * 1.3f);
        TurtleObject.Escape_Value = (int)(TurtleObject.Escape_Value * 1.3f);
        LobsterObject.Escape_Value = (int)(LobsterObject.Escape_Value * 1.3f);
        RayObject.Escape_Value = (int)(RayObject.Escape_Value * 1.3f);
        SeacucumberObject.Escape_Value = (int)(SeacucumberObject.Escape_Value * 1.3f);


    }
}
