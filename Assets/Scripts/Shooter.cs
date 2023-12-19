using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject prefab; // 発射するプレハブ
    public GameObject powerMeter; // 力のメーターを表示する2Dオブジェクト
    private float power; // 現在の力の値
    private bool isIncreasing = true; // 力が増加しているかどうか
    private float width = 0.5f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // マウスを押した瞬間
        {
            power = 0; // 力をリセット
            isIncreasing = true;
        }

        if (Input.GetMouseButton(0)) // マウスを押し続けている間
        {
            UpdatePowerMeter();
        }

        if (Input.GetMouseButtonUp(0)) // マウスを離した瞬間
        {
            ShootProjectile();
            ResetPowerMeter(); // メーターをリセット
        }
    }

    private void UpdatePowerMeter()
    {
        if (isIncreasing)
        {
            power += Time.deltaTime; // 力を増加
            if (power > 1)
            {
                power = 1;
                isIncreasing = false; // 力の増加を停止
            }
        }
        else
        {
            power -= Time.deltaTime; // 力を減少
            if (power < 0)
            {
                power = 0;
                isIncreasing = true; // 力の減少を停止
            }
        }

        // 2Dオブジェクトの大きさを更新
        powerMeter.transform.localScale = new Vector3(power, width, 1f);
    }

    private void ResetPowerMeter()
    {
        powerMeter.transform.localScale = new Vector3(0, width, 1f); // メーターの大きさをリセット
    }

    private void ShootProjectile()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector2 direction = (mousePosition - transform.position).normalized;

        GameObject projectile = Instantiate(prefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * power * 17f; // メーターの値に基づいて力を計算
    }
}
