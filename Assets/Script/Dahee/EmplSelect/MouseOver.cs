using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public float scaleFactor = 1.1f;

    private UnityEngine.UI.Image image;

    private Vector3 originalScale;
    private bool isClicked = false;

    private void Start()
    {
        image = GetComponent<Image>();
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isClicked)
        {
            transform.localScale = originalScale * scaleFactor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isClicked)
        {
            transform.localScale = originalScale;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isClicked = true;
    }
}
