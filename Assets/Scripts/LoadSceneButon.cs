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
        // 指定した名前のシーンをロード
        SceneManager.LoadScene(sceneName);
        GameManager.instance.score = 0;
    }
}
