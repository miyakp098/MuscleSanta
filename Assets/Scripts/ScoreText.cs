using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI pointText;
    public TextMeshProUGUI plusScoreText;
    public TextMeshProUGUI totalScoreText;
    public TextMeshProUGUI lodeSceneText;

    public TextMeshProUGUI clearOrGameOverText;

    public GameObject Clear;

    private CameraController cameraController;
    private Shooter shooter;

    //SE
    public AudioClip ClearSE;

    private bool hasRunOnce = false;

    public GameObject parentObject; // 親オブジェクトをインスペクタから割り当てる
    private PresentInHouse[] gameObjects; // ゲームオブジェクトの配列
    private int childCount;
    private int trueCount; // inHouseがtrueのオブジェクトの数

    public TextMeshProUGUI clearCountText;

    void Awake()
    {
        cameraController = FindObjectOfType<CameraController>();
        shooter = FindObjectOfType<Shooter>();
    }
    private void Start()
    {
        hasRunOnce = false;
        Clear.SetActive(false);


        childCount = parentObject.transform.childCount;
        gameObjects = new PresentInHouse[childCount];
        for (int i = 0; i < childCount; i++)
        {
            gameObjects[i] = parentObject.transform.GetChild(i).GetComponent<PresentInHouse>();
        }
        clearCountText.text = $"(0/{childCount})届けた!";
        totalScoreText.text = "";
        clearOrGameOverText.text = "";

        GameManager.instance.stageClear = false;
    }

    void Update()
    {
        pointText.text = $"{GameManager.instance.score}";

        // shooter.count == 0になった時、一度だけ実行
        if (shooter.count == 0 && cameraController.throwObj == null && !hasRunOnce)
        {
            GameManager.instance.plusScore = "";
            if (SceneManager.GetActiveScene().name == "Stage1")
            {
                totalScoreText.text = $"Score :{GameManager.instance.score}";
                if (GameManager.instance.stageClear)
                {
                    clearOrGameOverText.text = "CLEAR!!";
                    lodeSceneText.text = "NextStage";
                }
                else
                {
                    clearOrGameOverText.text = "GAME OVER";
                    lodeSceneText.text = "Title";
                }
            }
            else if(SceneManager.GetActiveScene().name == "Stage2")
            {
                if (GameManager.instance.stageClear)
                {
                    totalScoreText.text = $"Score :{GameManager.instance.score}";
                    clearOrGameOverText.text = "";
                    lodeSceneText.text = "Again!";
                }
                else
                {
                    totalScoreText.text = $"TotalScore :{GameManager.instance.score}";
                    clearOrGameOverText.text = "";
                    lodeSceneText.text = "Title";
                }
            }
            GameManager.instance.PlaySE(ClearSE);
            hasRunOnce = true;
            Clear.SetActive(true);
            

            //スコアの更新
            if (GameManager.instance.highScore < GameManager.instance.score)
            {
                GameManager.instance.highScore = GameManager.instance.score;
                GameManager.instance.ScoreUpdate();
            }

        }
        else
        {
            plusScoreText.text = GameManager.instance.plusScore;
            trueCount = 0;
            foreach (var obj in gameObjects)
            {
                if (obj != null && obj.inHouse)
                {
                    trueCount++;
                }
            }

            // trueCountを使用した処理、例えばログ表示
            if (trueCount == childCount)
            {
                clearCountText.text = $"クリア!ポイントを稼ごう!";
                GameManager.instance.stageClear = true;

            }
            else if (trueCount == 0)
            {
                clearCountText.text = $"{childCount - trueCount}人に届けよう!";
            }
            else
            {
                clearCountText.text = $"あと{childCount - trueCount}人に届けよう!";
            }
        }


        
    }
}
