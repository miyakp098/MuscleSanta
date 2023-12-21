using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject prefab; // 発射するプレハブ
    public GameObject powerMeter; // 力のメーターを表示する2Dオブジェクト
    public GameObject throwPoint;
    private float power; // 現在の力の値
    private bool isIncreasing = true; // 力が増加しているかどうか
    private float width = 0.5f;
    public bool setObject = false;//投げるものがセットされているか
    public ClickMoveObject2D clickMoveScript;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (setObject)
        {
            if (Input.GetMouseButtonDown(0)) // マウスを押した瞬間
            {
                power = 0; // 力をリセット
                isIncreasing = true;
                animator.SetBool("throw", true); // Animatorのboolをtrueに設定
            }

            if (Input.GetMouseButton(0)) // マウスを押し続けている間
            {
                UpdatePowerMeter();
            }

            if (Input.GetMouseButtonUp(0)) // マウスを離した瞬間
            {
                ResetPowerMeter(); // メーターをリセット
                animator.SetBool("throw", false); // Animatorのboolをfalseに設定
            }
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
        clickMoveScript.DeleteSelectedObject();
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector2 direction = (mousePosition - throwPoint.transform.position).normalized;

        GameObject projectile = Instantiate(prefab, throwPoint.transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * power * 17f; // メーターの値に基づいて力を計算
    }
}
