using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public GameObject throwObj;
    public float startPos = 0;
    public float endPos = 33;
    Vector3 cameraPos;

    //ボタン
    public Button backButton;

    private void Start()
    {
        throwObj = null;
        backButton.onClick.AddListener(OnButtonClicked);
        backButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (throwObj == null)
        {
            
        }
        else if(throwObj != null)
        {
            cameraPos = throwObj.transform.position;
        }
        
        if (cameraPos.x < startPos)
        {
            transform.position = new Vector3(startPos, transform.position.y, transform.position.z);
        }
        else if (cameraPos.x > endPos)
        {
            transform.position = new Vector3(endPos, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(cameraPos.x, transform.position.y, transform.position.z);
        }
    }

    // ボタンがクリックされたときに呼び出されるメソッド
    public void OnButtonClicked()
    {
        backButton.gameObject.SetActive(false);
    }
}