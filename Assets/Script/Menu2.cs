using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu2 : MonoBehaviour
{
    public GameObject MenuObject;
    bool isclicked = false;

    void Start()
    {
        MenuObject.SetActive(false); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
        {
        
            isclicked = !isclicked;

            if (isclicked)
            {
                MenuObject.SetActive(true); 
            }
            else
            {
                MenuObject.SetActive(false); 
            }
        }
    }
}
