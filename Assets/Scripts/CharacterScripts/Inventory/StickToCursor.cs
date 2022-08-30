using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class StickToCursor : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _icon;
    [SerializeField] private GameObject _iconGameObjcet;

    public bool buttonPressed;
    public bool iconIsMoved = false;

    private Vector3 lastPos;
    private Vector3 _positon;
    private RectTransform _rectTransform;

    private void Awake()
    {
        _icon = GetComponent<Image>();
        _rectTransform = _iconGameObjcet.GetComponent<RectTransform>();
        _positon = _rectTransform.localPosition;
        lastPos = _positon;
    }
    private void Update()
    {
        if (buttonPressed)
        {
            _iconGameObjcet.transform.position = Input.mousePosition;
        }
        else
        {
            _rectTransform.localPosition = _positon;
        }
        if (lastPos != _rectTransform.localPosition)
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
        lastPos = _rectTransform.localPosition;
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (lastPos == _rectTransform.localPosition)
        {
            iconIsMoved = false;
        }
        buttonPressed = false;
    }
}

