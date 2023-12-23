using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObj : MonoBehaviour
{
    //カメラ
    public CameraController cameraController;
    public Shooter shooter;

    void Awake()
    {
        cameraController = FindObjectOfType<CameraController>();
        shooter = FindObjectOfType<Shooter>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        cameraController.throwObj = null;
        Destroy(collider.gameObject);
        shooter.canClick = true;
    }
}
