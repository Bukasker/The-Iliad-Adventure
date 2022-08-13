using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScreenConvertor : MonoBehaviour
{
    private RectTransform _rectTransform;
    private GameObject _uiToConvert;
    [SerializeField] private GameObject _canvas;
    public Vector2 TEST;

    private void Start()
    {
        var _canvasRectTranform = _canvas.GetComponent<RectTransform>();
        _rectTransform = GetComponent<RectTransform>();

    }
    private void Update()
    {
        TEST = _rectTransform.sizeDelta;
    }
}
