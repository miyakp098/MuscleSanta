using System.Collections.Generic;
using UnityEngine;

public class WindowBreak : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private List<Rigidbody2D> childRigidbodies;
    //SE
    public AudioClip windowBreakSE;

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
        if (collision.gameObject.CompareTag("lost") ||
            collision.gameObject.CompareTag("switch") ||
            collision.gameObject.CompareTag("snack") ||
            collision.gameObject.CompareTag("money") ||
            collision.gameObject.CompareTag("stone") ||
            collision.gameObject.CompareTag("toy"))
        {
            GameManager.instance.PlaySE(windowBreakSE);
            Rigidbody2D collidingRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            if (collidingRigidbody != null)
            {
                float forceMagnitude = collidingRigidbody.velocity.magnitude; // 衝突したオブジェクトの速度の大きさ

                foreach (Rigidbody2D rb in childRigidbodies)
                {
                    float randomAngle = Random.Range(-45f, 45f); // 各 Rigidbody2D ごとにランダムな角度を生成
                    Vector2 forceDirection = Quaternion.Euler(0, 0, randomAngle) * Vector2.right; // 右方向ベクトルをランダムな角度で回転

                    rb.bodyType = RigidbodyType2D.Dynamic;
                    rb.AddForce(forceDirection * forceMagnitude, ForceMode2D.Impulse); // 力を加える

                    float randomTorque = Random.Range(-10f, 10f); // ランダムなトルク値を生成
                    rb.AddTorque(randomTorque, ForceMode2D.Impulse); // トルク（回転力）を加える
                }

                if (spriteRenderer != null)
                {
                    spriteRenderer.enabled = false;
                }
            }
        }
    }


}
