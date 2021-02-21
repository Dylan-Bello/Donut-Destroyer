using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveAndShoot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    private Image threshold;
    private Image touch;

    [HideInInspector]
    public Vector3 InputDir;
    [HideInInspector]
    public bool shoot;

    // Start is called before the first frame update
    void Start()
    {
        threshold = GetComponent<Image>();
        touch = transform.GetChild(0).GetComponent<Image>();
        InputDir = Vector3.zero
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

   

   
}
