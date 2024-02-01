using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiManager : MonoBehaviour
{   
    public GameObject Obj;

    public void UiOff()
    {
      Obj.SetActive(false);
    }

    
}
