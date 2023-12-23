using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TouchObj : MonoBehaviour
{
    //カメラ
    private CameraController cameraController;
    private Shooter shooter;
    public TextMeshProUGUI plusScoreText;
    void Awake()
    {
        cameraController = FindObjectOfType<CameraController>();
        shooter = FindObjectOfType<Shooter>();
        plusScoreText = FindObjectOfType<TextMeshProUGUI>();
        if (plusScoreText == null)
        {
            Debug.LogError("TextMeshProUGUI object not found in the scene.");
        }
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
            StartCoroutine(WaitAndProcess(2f));
        }
            
    }

    IEnumerator WaitAndProcess(float waitTime)
    {
        yield return new WaitForSeconds(waitTime); // 指定された秒数待機

        cameraController.throwObj = null; // n秒後に処理を実行
        shooter.canClick = true;
        if(shooter.count != 0)
        {
            plusScoreText.text = "";
        }
        
        Debug.Log("OK");
    }
}
