using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        if (checkTransCam())
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
    }

    private bool checkTransCam()
    {   if(player.transform.localScale.x < 0 || player.transform.position.x < gameObject.transform.position.x)
        return false;
        return true;
    }

}
