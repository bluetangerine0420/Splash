using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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
    public void Gameoff()
    {
        Application.Quit();
    }
    public void LoadSce(int level)
    {
        SceneManager.LoadScene(level);
    }


}
