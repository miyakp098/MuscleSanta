using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject prefab; // 発射するプレハブ

    void Update()
    {
        if (Input.GetMouseButtonUp(0)) // マウスを離した瞬間
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Z軸は無視

            Vector2 direction = (mousePosition - transform.position).normalized; // 発射方向を計算
            float distance = Vector3.Distance(transform.position, mousePosition); // オブジェクトとマウス位置の間の距離に基づいて力を計算

            GameObject projectile = Instantiate(prefab, transform.position, Quaternion.identity); // プレハブをインスタンス化
            projectile.GetComponent<Rigidbody2D>().velocity = direction * distance * 2f; // プレハブを発射
        }
    }
}
