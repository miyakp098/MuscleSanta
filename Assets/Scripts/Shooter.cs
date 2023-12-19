using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject prefab; // 発射するプレハブ
    private float clickTime; // クリックした時間を記録

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // マウスを押した瞬間
        {
            clickTime = Time.time; // 現在の時間を記録
        }

        if (Input.GetMouseButtonUp(0)) // マウスを離した瞬間
        {
            float clickDuration = Time.time - clickTime; // クリックの持続時間を計算
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Z軸は無視

            Vector2 direction = (mousePosition - transform.position).normalized; // 発射方向を計算

            GameObject projectile = Instantiate(prefab, transform.position, Quaternion.identity); // プレハブをインスタンス化
            projectile.GetComponent<Rigidbody2D>().velocity = direction * clickDuration * 10f; // 時間に基づいて力を計算し、プレハブを発射
        }
    }
}
