using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public AudioSource audioSourceBGM = null;
    public AudioSource audioSourceSE = null;
    public int score = 0;
    public int highScore = 0;



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
