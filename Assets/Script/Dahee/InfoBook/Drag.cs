using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    private Vector2 pointerOffset;
    private bool isDragging = false;
    private RectTransform parentRectTransform;
    private Vector2 minPosition;
    private Vector2 maxPosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        parentRectTransform = rectTransform.parent.GetComponent<RectTransform>();
        CalculateBoundaries();
    }

    private void CalculateBoundaries()
    {
        Vector3[] corners = new Vector3[4];
        parentRectTransform.GetWorldCorners(corners);
        Vector3 minWorldPos = corners[0];
        Vector3 maxWorldPos = corners[2];

        minPosition = parentRectTransform.InverseTransformPoint(minWorldPos);
        maxPosition = parentRectTransform.InverseTransformPoint(maxWorldPos);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.SetAsLastSibling();

        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out pointerOffset);

        if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, eventData.position, eventData.pressEventCamera))
        {
            isDragging = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging)
            return;

        Vector2 mousePosition = eventData.position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, mousePosition, eventData.pressEventCamera, out Vector2 localPoint);

        Vector2 newPosition = localPoint - pointerOffset;

      
        newPosition.x = Mathf.Clamp(newPosition.x, minPosition.x, maxPosition.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minPosition.y, maxPosition.y);

        rectTransform.localPosition = newPosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }
}
