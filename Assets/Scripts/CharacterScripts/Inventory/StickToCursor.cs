using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class StickToCursor : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image icon;
    [SerializeField] private GameObject IconGameObject;
    private Vector3 position;
    private RectTransform rectTransform;
    public bool buttonPressed;
    public bool iconIsMoved = false;
    private Vector3 lastPos;

    private void Awake()
    {
        icon = GetComponent<Image>();
        rectTransform = IconGameObject.GetComponent<RectTransform>();
        position = rectTransform.localPosition;
        lastPos = position;
    }
    private void Update()
    {
        if (buttonPressed)
        {
            IconGameObject.transform.position = Input.mousePosition;
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
        rectTransform.SetAsLastSibling();
        if (icon.sprite != null)
        {
            lastPos = rectTransform.localPosition;
            buttonPressed = true;
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

