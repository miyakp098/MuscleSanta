using UnityEngine;

public class ClickMoveObject2D : MonoBehaviour
{
    public GameObject[] gameObjects; // ゲームオブジェクトの配列
    public GameObject targetObject; // 移動先のオブジェクト
    private GameObject currentSelectedObject; // 現在選択されているオブジェクト
    private Vector3 originalPosition; // オブジェクトの元の位置

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // マウス左クリックを検出
        {
            Vector2 rayPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero);

            if (hit.collider != null)
            {
                foreach (var obj in gameObjects)
                {
                    if (hit.transform.gameObject == obj)
                    {
                        MoveObject(obj);
                        break;
                    }
                }
            }
        }
    }

    void MoveObject(GameObject selectedObject)
    {
        if (currentSelectedObject != null)
        {
            // 以前に選択されたオブジェクトを元の位置に戻す
            currentSelectedObject.transform.position = originalPosition;
        }

        originalPosition = selectedObject.transform.position; // 元の位置を保存
        currentSelectedObject = selectedObject; // 現在選択されたオブジェクトを更新
        selectedObject.transform.position = targetObject.transform.position; // 新しい位置に移動
    }
}
