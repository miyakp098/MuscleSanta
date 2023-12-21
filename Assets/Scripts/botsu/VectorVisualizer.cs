using UnityEngine;

public class VectorVisualizer : MonoBehaviour
{
    public GameObject arrowPrefab; // 矢印のプレハブ
    public GameObject throwPoint;
    private GameObject currentArrow; // 現在表示されている矢印
    private bool isDragging = false; // ドラッグ中かどうかのフラグ

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // マウスを押した瞬間
        {
            StartDragging();
        }

        if (isDragging)
        {
            UpdateArrowPositionAndRotation();
        }

        if (Input.GetMouseButtonUp(0)) // マウスを離した瞬間
        {
            EndDragging();
        }
    }

    private void StartDragging()
    {
        isDragging = true;
        Vector3 startPosition = throwPoint.transform.position;
        currentArrow = Instantiate(arrowPrefab, startPosition, Quaternion.identity);
    }

    private void UpdateArrowPositionAndRotation()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Z軸は無視

        Vector3 direction = mousePosition - throwPoint.transform.position;
        currentArrow.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction); // 矢印の方向を設定
        // currentArrow.transform.localScale の設定は削除し、矢印の大きさは変更しない
    }

    private void EndDragging()
    {
        isDragging = false;
        Destroy(currentArrow); // 矢印を削除
    }
}
