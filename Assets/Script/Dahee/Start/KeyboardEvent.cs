using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyboardEvent : MonoBehaviour
{
    public UnityEvent[] clickEvents;
 

    void Update()
    {

        if (Input.anyKeyDown)
        {
            foreach (UnityEvent clickEvent in clickEvents)
            {
                clickEvent.Invoke();
            }
        }
    }
}
