using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopupController : MonoBehaviour, IPointerClickHandler
{
    public GameObject popup;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (popup.activeSelf && eventData.pointerCurrentRaycast.gameObject != popup)
        {
            popup.SetActive(false);
            SetPopLast();
        }
       
        
     
    }

    public void SetPopLast()
    {
        popup.transform.SetAsLastSibling();
    }
}
