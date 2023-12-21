using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    private GameObject prefab; // 発射するプレハブ
    public GameObject powerMeter; // 力のメーターを表示する2Dオブジェクト
    public GameObject throwPoint;
    private float power; // 現在の力の値
    private bool isIncreasing = true; // 力が増加しているかどうか
    private float width = 0.5f;
    public bool setObject = false;//投げるものがセットされているか
    public ClickMoveObject2D clickMoveScript;
    private Animator animator;
    public Button readyButton;

    void Start()
    {
        animator = GetComponent<Animator>();
        prefab = null;
        setObject = false;
        readyButton.onClick.AddListener(OnButtonClicked);
        readyButton.gameObject.SetActive(false);
    }


    void Update()
    {
        prefab = clickMoveScript.CurrentSelectedObject;

        if (prefab != null && setObject)
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
        else if(prefab != null)
        {
            readyButton.gameObject.SetActive(true);
        }
        
        
    }

    // ボタンがクリックされたときに呼び出されるメソッド
    public void OnButtonClicked()
    {
        setObject = true;
        readyButton.gameObject.SetActive(false);
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
        setObject = false;
        // Rigidbody2Dコンポーネントを取得
        Rigidbody2D rb = prefab.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // BodyTypeをDynamicに設定
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
        clickMoveScript.DeleteSelectedObject();
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector2 direction = (mousePosition - throwPoint.transform.position).normalized;

        GameObject projectile = Instantiate(prefab, throwPoint.transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * power * 17f; // メーターの値に基づいて力を計算
        projectile.GetComponent<Rigidbody2D>().angularVelocity = power * 1000f; // 回転速度
    }
}
