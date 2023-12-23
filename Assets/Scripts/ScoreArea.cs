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
            GameManager.instance.score += 20 * pointNbai;
            GameManager.instance.PlaySE(yaySESpesial);
        }
        else if (collision.gameObject.CompareTag("snack") && snack)
        {
            GameManager.instance.score += 20 * pointNbai;
            GameManager.instance.PlaySE(yaySESpesial);
        }
        else if (collision.gameObject.CompareTag("money") && money)
        {
            GameManager.instance.score += 20 * pointNbai;
            GameManager.instance.PlaySE(yaySESpesial);
        }
        else if (collision.gameObject.CompareTag("stone") && stone)
        {
            GameManager.instance.score += 20 * pointNbai;
            GameManager.instance.PlaySE(yaySESpesial);
        }
        else if (collision.gameObject.CompareTag("toy") && toy)
        {
            GameManager.instance.score += 20 * pointNbai;
            GameManager.instance.PlaySE(yaySESpesial);
        }
        else if (
            collision.gameObject.CompareTag("switch") ||
            collision.gameObject.CompareTag("snack") ||
            collision.gameObject.CompareTag("money") ||
            collision.gameObject.CompareTag("stone") ||
            collision.gameObject.CompareTag("toy"))
        {
            GameManager.instance.score += 5;
            GameManager.instance.PlaySE(yaySE);
        }
        collision.gameObject.tag = "lost";

    }
}
