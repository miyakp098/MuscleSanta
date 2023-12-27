using System.Collections.Generic;
using UnityEngine;

public class WindowBreak : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private List<Rigidbody2D> childRigidbodies;
    //SE
    public AudioClip windowBreakSE;
    private bool hasCollided = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        childRigidbodies = new List<Rigidbody2D>();

        foreach (Transform child in transform)
        {
            Rigidbody2D rb = child.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                childRigidbodies.Add(rb);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 衝突がまだ起きていない場合のみ処理を実行
        if (!hasCollided && (collision.gameObject.CompareTag("lost") ||
                             collision.gameObject.CompareTag("switch") ||
                             collision.gameObject.CompareTag("snack") ||
                             collision.gameObject.CompareTag("money") ||
                             collision.gameObject.CompareTag("stone") ||
                             collision.gameObject.CompareTag("toy")))
        {
            GameManager.instance.PlaySE(windowBreakSE);
            Rigidbody2D collidingRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            if (collidingRigidbody != null)
            {
                float forceMagnitude = collidingRigidbody.velocity.magnitude;

                foreach (Rigidbody2D rb in childRigidbodies)
                {
                    float randomAngle = Random.Range(-45f, 45f);
                    Vector2 forceDirection = Quaternion.Euler(0, 0, randomAngle) * Vector2.right;

                    rb.bodyType = RigidbodyType2D.Dynamic;
                    rb.AddForce(forceDirection * forceMagnitude, ForceMode2D.Impulse);

                    float randomTorque = Random.Range(-10f, 10f);
                    rb.AddTorque(randomTorque, ForceMode2D.Impulse);
                }

                if (spriteRenderer != null)
                {
                    spriteRenderer.enabled = false;
                }

                hasCollided = true; // 衝突が発生したことを記録
            }
        }
    }
}
