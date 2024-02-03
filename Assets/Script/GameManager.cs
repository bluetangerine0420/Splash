using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Ops;
    public int Employee_Num;
    public int Splash_Num;
    public static GameManager Gameinstance = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if (Gameinstance == null)
        {
            Gameinstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (Gameinstance != this)
                Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    { 

    }
}
