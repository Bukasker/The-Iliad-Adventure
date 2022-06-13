using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMovment : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x + 0.49f, player.transform.position.y + 1.5f, player.transform.position.z - 7.97f); ;
    }
}
