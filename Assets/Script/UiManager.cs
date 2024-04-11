using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiManager : MonoBehaviour
{   
    public void UiOff(GameObject Obj)
    {
      Obj.SetActive(false);
    }
    public void UiOn(GameObject Obj)
    {
      Obj.SetActive(true);
    }

    
}
