using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class TrashUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool mouse_over;

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
    }
}