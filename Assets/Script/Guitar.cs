using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Guitar : MonoBehaviour
{
    public GameObject[] Splahes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Keypad0)) { 
        for(int i=0; i<Splahes.Length; i++)
                Splahes[i].SetActive(false);
        Splahes[0].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            for (int i = 0; i < Splahes.Length; i++)
                Splahes[i].SetActive(false);
            Splahes[1].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            for (int i = 0; i < Splahes.Length; i++)
                Splahes[i].SetActive(false);
            Splahes[2].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            for (int i = 0; i < Splahes.Length; i++)
                Splahes[i].SetActive(false);
            Splahes[3].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            for (int i = 0; i < Splahes.Length; i++)
                Splahes[i].SetActive(false);
            Splahes[4].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            for (int i = 0; i < Splahes.Length; i++)
                Splahes[i].SetActive(false);
            Splahes[5].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            for (int i = 0; i < Splahes.Length; i++)
                Splahes[i].SetActive(false);
            Splahes[6].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            for (int i = 0; i < Splahes.Length; i++)
                Splahes[i].SetActive(false);
            Splahes[7].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            for (int i = 0; i < Splahes.Length; i++)
                Splahes[i].SetActive(false);
            Splahes[8].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            for (int i = 0; i < Splahes.Length; i++)
                Splahes[i].SetActive(false);
            Splahes[9].SetActive(true);
        }
    }
}
