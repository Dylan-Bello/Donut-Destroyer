using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class My_Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    private Image Threshold;
    private Image Touch;

    [HideInInspector]
    public Vector3 InputDir;
    [HideInInspector]
    public bool shoot;

   

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = Vector2.zero;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(Threshold.rectTransform, eventData.position, eventData.pressEventCamera, out position))
        {
            position.x = (position.x / Threshold.rectTransform.sizeDelta.x);
            position.y = (position.y / Threshold.rectTransform.sizeDelta.y);

            float x = (Threshold.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2 - 1;
            float y = (Threshold.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 - 1;

            InputDir = new Vector3(x, y, 0);
            InputDir = (InputDir.magnitude > 1) ? InputDir.normalized : InputDir;

            Touch.rectTransform.anchoredPosition = new Vector3(InputDir.x * (Threshold.rectTransform.sizeDelta.x / 2.5f), InputDir.y * (Threshold.rectTransform.sizeDelta.y / 2.5f));

        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        InputDir = Vector3.zero;
        Touch.rectTransform.anchoredPosition = Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        Threshold = GetComponent<Image>();
        Touch = transform.GetChild(0).GetComponent<Image>();
        InputDir = Vector3.zero;
    }

    
}
