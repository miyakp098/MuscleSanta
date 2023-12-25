using UnityEngine;
using UnityEngine.SceneManagement;

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
