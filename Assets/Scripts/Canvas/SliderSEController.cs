using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderSEController : MonoBehaviour, IPointerUpHandler
{
    public AudioClip seClip;        // 再生するSEクリップ

    private Slider slider;          // スライダーへの参照

    private void Start()
    {
        // Sliderコンポーネントの参照を取得
        slider = GetComponent<Slider>();
        if (slider == null)
        {
            Debug.LogError("Sliderコンポーネントが見つかりません。");
        }

        if (seClip == null)
        {
            Debug.LogError("AudioClipが設定されていません。");
        }
    }

    // IPointerUpHandlerインターフェースを実装
    public void OnPointerUp(PointerEventData eventData)
    {
        // GameManagerのインスタンスを使用してSEを再生
        if (GameManager.instance != null && seClip != null)
        {
            GameManager.instance.PlaySE(seClip);
        }
    }
}
