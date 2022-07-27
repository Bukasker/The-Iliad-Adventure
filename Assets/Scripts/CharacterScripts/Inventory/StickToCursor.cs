using UnityEngine;
using UnityEngine.EventSystems;

public class StickToCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject Panel;
    public bool mouse_over;
    public TrashUI trashUI;
    public bool test;
    private void Awake()
    {
        Panel = GameObject.FindGameObjectWithTag("TrashPanel");
        trashUI = Panel.GetComponent<TrashUI>();
    }
    /*
    public Image icon;
    private Vector3 position;
    private RectTransform rectTransform;
    public bool buttonPressed;

    private void Awake()
    {
        icon = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        position = rectTransform.localPosition;
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
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (icon.sprite != null)
        {
            buttonPressed = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (icon.sprite != null)
        {
            buttonPressed = false;
        }
    }
    */

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            var mousePostion = Input.mousePosition;
            Panel.transform.position = mousePostion;
            Panel.SetActive(true);
            test = true;
        }

    }
    private void Update()
    {
        if (mouse_over || trashUI.mouse_over)
        {
            Panel.SetActive(true);
        }

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        Panel.SetActive(false);
        test = false;
    }
}

