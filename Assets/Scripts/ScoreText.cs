using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI pointText;

    void Update()
    {
        pointText.text = $"{GameManager.instance.score}";
    }
}
