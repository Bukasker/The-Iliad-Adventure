using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEventTEST : MonoBehaviour
{
    void OnGUI()
    {
        Event e = Event.current;
        if (e.type == EventType.KeyDown)
        {
            if (Input.GetKeyDown(e.keyCode))
            {
                Debug.Log("Down: " + e.keyCode);
            }
        }
    }

    void Update()
    {

    }
}
