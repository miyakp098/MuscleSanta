using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TouchObj : MonoBehaviour
{
    //ボタン
    public Button backButton;

    private void Start()
    {
        backButton.onClick.AddListener(OnButtonClicked);
        backButton.gameObject.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }


    void OnTriggerEnter2D(Collider2D collider)
    {

    }

    // ボタンがクリックされたときに呼び出されるメソッド
    public void OnButtonClicked()
    {
        backButton.gameObject.SetActive(false);
    }
}
