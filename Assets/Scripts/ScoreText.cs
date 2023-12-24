using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI pointText;
    public TextMeshProUGUI totalScoreText;
    public GameObject Clear;

    private CameraController cameraController;
    private Shooter shooter;

    //SE
    public AudioClip ClearSE;

    private bool hasRunOnce = false;

    void Awake()
    {
        cameraController = FindObjectOfType<CameraController>();
        shooter = FindObjectOfType<Shooter>();
    }
    private void Start()
    {
        hasRunOnce = false;
        Clear.SetActive(false);
    }

    void Update()
    {
        pointText.text = $"{GameManager.instance.score}";

        // shooter.count == 0になった時、一度だけ実行
        if (shooter.count == 0 && cameraController.throwObj == null && !hasRunOnce)
        {
            if (SceneManager.GetActiveScene().name == "Stage1")
            {
                totalScoreText.text = $"Score :{GameManager.instance.score}";
            }else if(SceneManager.GetActiveScene().name == "Stage2")
            {
                totalScoreText.text = $"TotalScore :{GameManager.instance.score}";
            }
            GameManager.instance.PlaySE(ClearSE);
            hasRunOnce = true;
            Clear.SetActive(true);
            if(GameManager.instance.highScore < GameManager.instance.score)
            {
                GameManager.instance.highScore = GameManager.instance.score;
            }
            
        }
    }
}
