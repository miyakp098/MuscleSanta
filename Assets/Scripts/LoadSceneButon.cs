using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneButton : MonoBehaviour
{
    public string sceneName;  // ロードしたいシーンの名前



    void Start()
    {
        // このゲームオブジェクトのButtonコンポーネントを取得し、リスナーを追加
        GetComponent<Button>().onClick.AddListener(LoadSpecifiedScene);
    }

    void LoadSpecifiedScene()
    {
        if (GameManager.instance.stageClear)
        {
            SceneManager.LoadScene(sceneName);

            if (SceneManager.GetActiveScene().name == "Stage2" && !GameManager.instance.hasSetStage12Score)
            {
                GameManager.instance.stage12Score = GameManager.instance.score;
                Debug.Log(GameManager.instance.stage12Score);
                GameManager.instance.ScoreUpdate2();
                GameManager.instance.hasSetStage12Score = true;
            }

        }
        else
        {
            SceneManager.LoadScene("Title");

            GameManager.instance.score = 0;
            GameManager.instance.stage12Score = 0;
            GameManager.instance.hasSetStage12Score = false; // リセット
        }
    }
}
