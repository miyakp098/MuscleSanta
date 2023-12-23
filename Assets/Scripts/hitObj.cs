using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitObj : MonoBehaviour
{
    //SE
    public AudioClip hitSE;

    //カメラ
    public CameraController cameraController;
    public Shooter shooter;

    void Awake()
    {
        cameraController = FindObjectOfType<CameraController>();
        shooter = FindObjectOfType<Shooter>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.PlaySE(hitSE);
        if (collision.gameObject.CompareTag("lost"))
        {
            StartCoroutine(WaitAndProcess(2f));
        }
    }

    IEnumerator WaitAndProcess(float waitTime)
    {
        yield return new WaitForSeconds(waitTime); // 指定された秒数待機

        cameraController.throwObj = null; // 3秒後に処理を実行
        shooter.canClick = true;
    }
}
