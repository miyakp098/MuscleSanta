using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClearJudge : MonoBehaviour
{
    public GameObject parentObject; // 親オブジェクトをインスペクタから割り当てる
    private PresentInHouse[] gameObjects; // ゲームオブジェクトの配列
    private int childCount;
    private int trueCount; // inHouseがtrueのオブジェクトの数

    public TextMeshProUGUI clearCountText;
    public TextMeshProUGUI plusScoreText;

    void Start()
    {
        childCount = parentObject.transform.childCount;
        gameObjects = new PresentInHouse[childCount];
        for (int i = 0; i < childCount; i++)
        {
            gameObjects[i] = parentObject.transform.GetChild(i).GetComponent<PresentInHouse>();
        }
        clearCountText.text = $"(0/{childCount})届けた!";
    }

    void Update()
    {
        plusScoreText.text = GameManager.instance.plusScore;
        trueCount = 0;
        foreach (var obj in gameObjects)
        {
            if (obj != null && obj.inHouse)
            {
                trueCount++;
            }
        }

        // trueCountを使用した処理、例えばログ表示
        if(trueCount == childCount)
        {
            clearCountText.text = $"クリア!ポイントを稼ごう!";
        }
        else if(trueCount == 0)
        {
            clearCountText.text = $"{childCount - trueCount}人に届けよう!";
        }
        else
        {
            clearCountText.text = $"あと{childCount - trueCount}人に届けよう!";
        }
        
    }
}
