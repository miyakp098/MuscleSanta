using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TouchObj : MonoBehaviour
{
    //カメラ
    private CameraController cameraController;
    private Shooter shooter;

    public float waittime = 2;

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
            StartCoroutine(WaitAndProcess(waittime));
        }
            
    }

    IEnumerator WaitAndProcess(float waitTime)
    {
        yield return new WaitForSeconds(waitTime); // 指定された秒数待機

        cameraController.throwObj = null; // n秒後に処理を実行
        shooter.canClick = true;
        if(shooter.count != 0)
        {
            GameManager.instance.plusScore = "";
        }
        
    }
}
