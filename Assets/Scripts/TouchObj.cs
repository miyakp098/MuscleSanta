using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TouchObj : MonoBehaviour
{
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
        if (collision.gameObject.CompareTag("lost") ||
            collision.gameObject.CompareTag("switch") ||
            collision.gameObject.CompareTag("snack") ||
            collision.gameObject.CompareTag("money") ||
            collision.gameObject.CompareTag("stone") ||
            collision.gameObject.CompareTag("toy"))
        {
            collision.gameObject.tag = "lost"; // タグを変更
            StartCoroutine(WaitAndProcess(2f));
        }
            
    }

    IEnumerator WaitAndProcess(float waitTime)
    {
        yield return new WaitForSeconds(waitTime); // 指定された秒数待機

        cameraController.throwObj = null; // n秒後に処理を実行
        shooter.canClick = true;
    }
}
