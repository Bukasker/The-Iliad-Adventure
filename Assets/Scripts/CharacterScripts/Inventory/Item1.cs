using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class StickToCursor : MonoBehaviour
{
    public bool test;
    public GameObject icon;
    public void Awake()
    {
        icon = gameObject;
    }
    public void StickIconToCurrsor()
    {
        test = true;
        gameObject.transform.position = Input.mousePosition;
    }
}
