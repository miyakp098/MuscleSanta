using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public GameObject throwObj;
    public Button kakuninButton; // ボタンを追加
    public GameObject[] cameraPositions; // カメラの移動位置のためのゲームオブジェクトの配列
    public float leftPos = 0;
    public float rightPos = 33;
    public float returnSpeed = 3.0f;
    Vector3 cameraPos;
    private float startPosY;
    private int currentCameraPositionIndex = 0; // 現在のカメラ位置のインデックス

    private bool isMoving = false; // カメラが移動中かどうかのフラグ

    private void Start()
    {
        throwObj = null;
        cameraPos = new Vector3(leftPos, transform.position.y, transform.position.z);
        startPosY = transform.position.y;

        kakuninButton.onClick.AddListener(MoveCamera); // ボタンにイベントリスナーを追加
    }

    void Update()
    {
        if (throwObj != null)
        {
            // throwObjが存在する場合、その位置を追跡
            cameraPos = throwObj.transform.position;
        }
        else if (isMoving)
        {
            // カメラを新しい位置に移動させる
            Vector3 targetPos = cameraPositions[currentCameraPositionIndex].transform.position;
            cameraPos = Vector3.Lerp(cameraPos, targetPos, returnSpeed * Time.deltaTime);
        }
        else
        {
            // throwObjがnullの場合、カメラをstartPosに戻す
            Vector3 startPosVec = new Vector3(leftPos, startPosY, transform.position.z);
            cameraPos = Vector3.Lerp(cameraPos, startPosVec, returnSpeed * Time.deltaTime);
        }

        // カメラ位置を制限（Y座標の上限を18に設定）
        cameraPos.y = Mathf.Clamp(cameraPos.y, 0, 18);

        // カメラ位置を制限
        if (cameraPos.x < leftPos)
        {
            transform.position = new Vector3(leftPos, cameraPos.y, transform.position.z);
        }
        else if (cameraPos.x > rightPos)
        {
            transform.position = new Vector3(rightPos, cameraPos.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(cameraPos.x, cameraPos.y, transform.position.z);
        }
    }

    private void MoveCamera()
    {
        if (cameraPositions.Length == 0) return;

        isMoving = true; // カメラ移動フラグを true に設定
        currentCameraPositionIndex = (currentCameraPositionIndex + 1) % cameraPositions.Length;
    }
}
