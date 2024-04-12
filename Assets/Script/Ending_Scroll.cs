using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ending_Scroll : MonoBehaviour
{
    public int Speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 21.5f)
        {
            transform.Translate(0, 1f * Time.deltaTime * Speed, 0);
        }
    }

}
