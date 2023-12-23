using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // UIシステムを使用するために必要

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private AudioSource audioSourceBGM = null;
    private AudioSource audioSourceSE = null;
    public int score = 0;

    public Slider sliderBGM;  // BGMのスライダー
    public Slider sliderSE;   // SEのスライダー

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            // AudioSourceコンポーネントを追加
            audioSourceBGM = GetComponent<AudioSource>();
            audioSourceSE = gameObject.AddComponent<AudioSource>();
            audioSourceSE.volume = 0.5f;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        // スライダーの初期値を設定し、イベントリスナーを追加
        if (sliderBGM != null)
        {
            sliderBGM.value = audioSourceBGM.volume;
            sliderBGM.onValueChanged.AddListener(delegate { SetVolumeBGM(sliderBGM.value); });
        }

        if (sliderSE != null)
        {
            sliderSE.value = audioSourceSE.volume;
            sliderSE.onValueChanged.AddListener(delegate { SetVolumeSE(sliderSE.value); });
        }
    }

    // BGMボリュームを設定するメソッド
    public void SetVolumeBGM(float volume)
    {
        if (audioSourceBGM != null)
            audioSourceBGM.volume = volume;
    }

    // SEボリュームを設定するメソッド
    public void SetVolumeSE(float volume)
    {
        if (audioSourceSE != null)
            audioSourceSE.volume = volume;
    }

    public void PlaySE(AudioClip clip)
    {
        if (audioSourceSE != null)
        {
            audioSourceSE.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("SE用のオーディオソースが設定されていません");
        }
    }

}
