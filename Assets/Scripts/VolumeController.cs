using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{


    public Slider sliderBGM;  // BGMのスライダー
    public Slider sliderSE;   // SEのスライダー


    private void Start()
    {
        // スライダーの初期値を設定し、イベントリスナーを追加
        if (sliderBGM != null)
        {
            sliderBGM.value = GameManager.instance.audioSourceBGM.volume;
            sliderBGM.onValueChanged.AddListener(delegate { SetVolumeBGM(sliderBGM.value); });
        }

        if (sliderSE != null)
        {
            sliderSE.value = GameManager.instance.audioSourceSE.volume;
            sliderSE.onValueChanged.AddListener(delegate { SetVolumeSE(sliderSE.value); });
        }
    }

    // BGMボリュームを設定するメソッド
    public void SetVolumeBGM(float volume)
    {
        if (GameManager.instance.audioSourceBGM != null)
            GameManager.instance.audioSourceBGM.volume = volume;
    }

    // SEボリュームを設定するメソッド
    public void SetVolumeSE(float volume)
    {
        if (GameManager.instance.audioSourceSE != null)
            GameManager.instance.audioSourceSE.volume = volume;
    }

    public void PlaySE(AudioClip clip)
    {
        if (GameManager.instance.audioSourceSE != null)
        {
            GameManager.instance.audioSourceSE.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("SE用のオーディオソースが設定されていません");
        }
    }
}
