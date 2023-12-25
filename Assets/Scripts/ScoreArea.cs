using TMPro;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    public bool gameSwitch = false;
    public bool snack = false;
    public bool money = false;
    public bool stone = false;
    public bool toy = false;
    public int pointNbai = 1;
    //SE
    public AudioClip yaySESpesial;
    public AudioClip yaySE;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("switch") && gameSwitch)
        {
            SpecialScore();
        }
        else if (collision.gameObject.CompareTag("snack") && snack)
        {
            SpecialScore();
        }
        else if (collision.gameObject.CompareTag("money") && money)
        {
            SpecialScore();
        }
        else if (collision.gameObject.CompareTag("stone") && stone)
        {
            SpecialScore();
        }
        else if (collision.gameObject.CompareTag("toy") && toy)
        {
            SpecialScore();
        }
        else if (
            collision.gameObject.CompareTag("switch") ||
            collision.gameObject.CompareTag("snack") ||
            collision.gameObject.CompareTag("money") ||
            collision.gameObject.CompareTag("stone") ||
            collision.gameObject.CompareTag("toy"))
        {
            NormalScore();
        }
        collision.gameObject.tag = "lost";

    }

    private void SpecialScore()
    {
        GameManager.instance.score += 20 * pointNbai;
        GameManager.instance.PlaySE(yaySESpesial);
        GameManager.instance.plusScore = $"+{20 * pointNbai}Point!!";
    }
    private void NormalScore()
    {
        GameManager.instance.score += 5 * pointNbai;
        GameManager.instance.PlaySE(yaySE);
        GameManager.instance.plusScore = $"+{5 * pointNbai}Point!!";
    }
}
