using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Shooter : MonoBehaviour
{
    private GameObject prefab; // 発射するプレハブ
    public GameObject powerMeter; // 力のメーターを表示する2Dオブジェクト
    public GameObject throwPoint;
    private float power; // 現在の力の値
    private bool isIncreasing = true; // 力が増加しているかどうか
    private float width = 1;
    public bool setObject = false;//投げるものがセットされているか
    public ClickMoveObject2D clickMoveScript;
    private Animator animator;

    //クリックの管理
    public bool contClickRenda = false;
    private bool firstTimeEntered = true;


    public TextMeshPro howToText;
    public TextMeshPro clickText;
    public TextMeshPro presentNumText;

    public int count = 7;

    //ボタン
    public Button readyButton;
    

    public bool canClick = true; // マウスクリックが有効かどうかを追跡する変数

    //矢印
    public GameObject arrowPrefab; // 矢印のプレハブ
    private GameObject currentArrow; // 現在表示されている矢印
    private bool isDragging = false; // ドラッグ中かどうかのフラグ

    //カメラ
    public CameraController cameraController;

    //SE
    public AudioClip throwSE;
    public AudioClip readyButtonSE;

    Vector3 mousePosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        prefab = null;
        setObject = false;
        readyButton.onClick.AddListener(OnButtonClicked);
        readyButton.gameObject.SetActive(false);
        canClick = true;
        howToText.text = "";
        clickText.text = "どれか選ぶ";
        contClickRenda = true;
        count = 7;
    }


    void Update()
    {
        
        
        prefab = clickMoveScript.CurrentSelectedObject;

        if (prefab != null && setObject && canClick)
        {
            if (contClickRenda)
            {
                
                howToText.text = "方向を決めてクリック長押し!";
                clickText.text = "";
                if (Input.GetMouseButtonDown(0)) // マウスを押した瞬間
                {
                    power = 0; // 力をリセット
                    isIncreasing = true;
                    animator.SetBool("throw", true); // Animatorのboolをtrueに設定

                    StartDragging();//矢印


                } 

                if (Input.GetMouseButton(0)) // マウスを押し続けている間
                {
                    UpdatePowerMeter();
                    howToText.text = "方向を決めて離す!";
                }

                //矢印
                if (isDragging)
                {
                    UpdateArrowPositionAndRotation();
                }
                
                if (Input.GetMouseButtonUp(0) && !firstTimeEntered)
                {
                    animator.SetBool("throw", false); // Animatorのboolをfalseに設定

                    EndDragging();
                    
                }
                if (firstTimeEntered)
                {
                    firstTimeEntered = false;
                }
            }

            
            
        }
        else if (!cameraController.kakuninButtonNum)
        {
            readyButton.gameObject.SetActive(false);
            howToText.text = "";
            
        }
        else if(prefab != null)
        {
            readyButton.gameObject.SetActive(true);
            howToText.text = "";
            clickText.text = "他の物にする";
        }
        else
        {
            howToText.text = "";
            clickText.text = "どれか選ぶ";
        }
        
        
    }

    // ボタンがクリックされたときに呼び出されるメソッド
    public void OnButtonClicked()
    {
        GameManager.instance.PlaySE(readyButtonSE);
        setObject = true;
        readyButton.gameObject.SetActive(false);
    }

    private void UpdatePowerMeter()
    {
        if (isIncreasing)
        {
            power += Time.deltaTime; // 力を増加
            if (power > 1.5f)
            {
                power = 1.5f;
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
        powerMeter.transform.localScale = new Vector3(width,  3 - power * 2, 1f);
    }

    private void ResetPowerMeter()
    {
        powerMeter.transform.localScale = new Vector3(width, 3, 1f); // メーターの大きさをリセット
    }

    private void ShootProjectile()
    {
        GameManager.instance.PlaySE(throwSE);
        ResetPowerMeter(); // メーターをリセット
        setObject = false;
        firstTimeEntered = true;
        canClick = false; // マウスクリックを無効にする
        contClickRenda = true;
        // Rigidbody2Dコンポーネントを取得
        Rigidbody2D rb = prefab.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // BodyTypeをDynamicに設定
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
        clickMoveScript.DeleteSelectedObject();



        Vector2 direction = (mousePosition - throwPoint.transform.position).normalized;

        GameObject projectile = Instantiate(prefab, throwPoint.transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * power * 17f; // メーターの値に基づいて力を計算
        projectile.GetComponent<Rigidbody2D>().angularVelocity = power * 1000f; // 回転速度
        Collider2D[] colliders = projectile.GetComponents<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = true;
        }


        // プロジェクタイルをカメラのターゲットとして設定
        if (cameraController != null)
        {
            cameraController.throwObj = projectile;
        }

        //カウントが0になったら終わり
        count--;
    }





    //矢印
    private void StartDragging()
    {
        isDragging = true;
        currentArrow = Instantiate(arrowPrefab, throwPoint.transform.position, Quaternion.identity);
    }

    private void UpdateArrowPositionAndRotation()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Z軸は無視

        Vector3 direction = mousePosition - throwPoint.transform.position;
        currentArrow.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction); // 矢印の方向を設定
        // currentArrow.transform.localScale の設定は削除し、矢印の大きさは変更しないZif（
    }

    private void EndDragging()
    {
        isDragging = false;
        Destroy(currentArrow); // 矢印を削除
        Debug.Log("OK");
        contClickRenda = false;
        howToText.text = "";
    }

    private IEnumerator EndDraggingCoroutine()
    {
        yield return new WaitForSeconds(1f); // 3秒待機

        isDragging = false;
        Destroy(currentArrow); // 矢印を削除
    }
}
