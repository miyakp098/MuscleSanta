using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TouchObj : MonoBehaviour
{
    //カメラ
    public CameraController cameraController;
    public Shooter Shooter;


    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(WaitAndProcess(2f));
    }

    IEnumerator WaitAndProcess(float waitTime)
    {
        yield return new WaitForSeconds(waitTime); // 指定された秒数待機

        cameraController.throwObj = null; // 3秒後に処理を実行
        Shooter.canClick = true;
    }
}
