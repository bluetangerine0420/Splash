using UnityEngine;
using UnityEngine.UI;

public class ButtonInBook: MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject objectToDeactivate;

    void Start()
    {
       
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
   
        if (objectToActivate != null && !objectToActivate.activeSelf)
        {
            objectToActivate.SetActive(true);
        }

        if (objectToDeactivate != null && objectToDeactivate.activeSelf)
        {
            objectToDeactivate.SetActive(false); 
        }
    }
}
