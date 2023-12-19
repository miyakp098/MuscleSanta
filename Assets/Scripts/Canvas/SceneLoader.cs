using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理用の名前空間

public class SceneLoader : MonoBehaviour
{
    // 次のシーンの名前
    public string nextSceneName;

    // ボタンがクリックされたときに呼び出されるメソッド
    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
