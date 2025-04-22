using TMPro;
using UnityEngine;
using DG.Tweening;

namespace App.Scripts.Game.AmplificationDisplay
{
    class AmplificationAnimation : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI AmpText;

        [SerializeField] private float moveDistance = 100f; // 上に移動する距離
        [SerializeField] private float moveDuration = 0.5f; // 移動にかかる時間
        [SerializeField] private float fadeDuration = 0.5f; // フェードアウトにかかる時間

        public void StartAnimation(int amplificationValue, bool isCorrect)
        {
            if (AmpText == null)
            {
                Debug.LogError("AmpText is not assigned.");
                return;
            }

            if (isCorrect) AmpText.text = $"増加率: +{amplificationValue * 100}%";
            else AmpText.text = $"増加率: -{amplificationValue * 100}%"; // マイナスの値を表示
            AmpText.gameObject.SetActive(true);

            // 上に移動
            Vector3 targetPosition = AmpText.transform.localPosition + new Vector3(0, moveDistance, 0);
            AmpText.transform.DOLocalMove(targetPosition, moveDuration)
                .SetEase(Ease.OutQuad)
                .OnComplete(() => FadeOut(AmpText.gameObject)); // 移動完了後にフェードアウト
        }

        private void FadeOut(GameObject target)
        {
            // フェードアウト
            CanvasGroup canvasGroup = target.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = target.AddComponent<CanvasGroup>();
            }

            canvasGroup.DOFade(0, fadeDuration).OnComplete(() =>
            {
                target.SetActive(false); // フェードアウト完了後に非表示にする
                canvasGroup.alpha = 1; // alphaを元に戻す
            });
        }
    }
}