using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject throwObj;
    public float startPos = 0;
    public float endPos = 58;
    Vector3 cameraPos;

    private void Start()
    {
        throwObj = null;
    }

    void Update()
    {
        if (throwObj == null)
        {
            cameraPos = transform.position;
        }
        else if(throwObj != null)
        {
            cameraPos = throwObj.transform.position;
        }
        
        if (cameraPos.x < startPos)
        {
            transform.position = new Vector3(startPos, transform.position.y, transform.position.z);
        }
        else if (cameraPos.x > endPos)
        {
            transform.position = new Vector3(endPos, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(cameraPos.x, transform.position.y, transform.position.z);
        }
    }
}