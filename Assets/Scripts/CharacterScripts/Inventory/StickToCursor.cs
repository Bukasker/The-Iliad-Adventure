using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class StickToCursor : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image icon;
    private Vector3 position;
    private RectTransform rectTransform;
    public bool buttonPressed;
    public bool iconIsMoved = false;
    public Vector3 lastPos;

    private void Awake()
    {
        icon = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        position = rectTransform.localPosition;
        lastPos = position;
    }
    private void Update()
    {
        if (buttonPressed)
        {
            gameObject.transform.position = Input.mousePosition;
        }
        else
        {
            rectTransform.localPosition = position;
        }
        if (lastPos != rectTransform.localPosition)
        {
            iconIsMoved = true;
        }
        else
        {
            iconIsMoved = false;
        }
    
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (icon.sprite != null)
        {
            lastPos = rectTransform.localPosition;
            buttonPressed = true;
        }
        if (lastPos != rectTransform.localPosition)
        {
            iconIsMoved = true;
        }
        else
        {
            iconIsMoved = false;
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (lastPos == rectTransform.localPosition)
        {
            iconIsMoved = false;
        }
        buttonPressed = false;
        
    }
}

