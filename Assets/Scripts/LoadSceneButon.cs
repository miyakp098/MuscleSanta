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
            GameManager.instance.score = 0;
        }
        else
        {
            SceneManager.LoadScene("Title");

            GameManager.instance.score = 0;
        }
    }
}
