using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObj : MonoBehaviour
{
    //カメラ
    public CameraController cameraController;
    public Shooter Shooter;


    void OnTriggerEnter2D(Collider2D collider)
    {
        cameraController.throwObj = null;
        Destroy(collider.gameObject);
        Shooter.canClick = true;
    }
}
