using TMPro;
using UnityEngine;
using DG.Tweening;
using System.Collections;
using App.Scripts.Game.Review;

namespace App.Scripts.Game.AmplificationDisplay
{
    class AmplificationAnimation : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI AmpText;

        [SerializeField] private float moveDistance = 100f; // 上に移動する距離
        [SerializeField] private float moveDuration = 0.5f; // 移動にかかる時間
        [SerializeField] private float fadeDuration = 0.5f; // フェードアウトにかかる時間
        private Vector3 currentLocalPosition; // 現在のTransformを保持する変数

        void Awake()
        {
            // 初期位置を保存
            currentLocalPosition = AmpText.transform.localPosition;
        }

        public void StartAnimation(int amplificationValue, bool isCorrect, int Star)
        {
            // アニメーションを開始するコルーチンを呼び出す
            StartCoroutine(StartCoroutine(amplificationValue, isCorrect, Star));
        }

        IEnumerator StartCoroutine(int amplificationValue, bool isCorrect, int Star)
        {
            // アニメーションの初期化
            AmpText.gameObject.SetActive(true);
            AmpText.transform.localPosition = currentLocalPosition; // 初期位置に戻す
            CanvasGroup canvasGroup = AmpText.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 1; // フェードイン
            }

            // テキストの内容を設定
            {
                if (isCorrect)
                {
                    if (Star == 5)
                    {
                        AmpText.text = $"増加率: +{amplificationValue * 100 * 3}%";
                        AmpText.color = new Color(0, 1, 0); // 緑色に変更
                    }
                    else if (Star == 4)
                    {
                        AmpText.text = $"増加率: +{amplificationValue * 100 * 2}%";
                        AmpText.color = new Color(0, 1, 0); // 緑色に変更
                    }
                    else if (Star == 3)
                    {
                        AmpText.text = $"増加率: +{amplificationValue * 100 * 1}%";
                        AmpText.color = new Color(0, 1, 0); // 緑色に変更
                    }
                }

                else
                {
                    if (Star == 2)
                    {
                        AmpText.text = $"増加率: -{amplificationValue * 100 * 1}%";
                        AmpText.color = new Color(1, 0, 0); // 赤色に変更
                    }
                    else if (Star == 1)
                    {
                        AmpText.text = $"増加率: -{amplificationValue * 100 * 2}%";
                        AmpText.color = new Color(1, 0, 0); // 赤色に変更
                    }
                    else if (Star == 0)
                    {
                        AmpText.text = $"増加率: -{amplificationValue * 100 * 3}%";
                        AmpText.color = new Color(1, 0, 0); // 赤色に変更
                    }
                }

                ResetPosition(); // 初期位置に戻す

                // 上に移動
                Vector3 targetPosition = AmpText.transform.localPosition + new Vector3(0, moveDistance, 0);
                AmpText.transform.DOLocalMove(targetPosition, moveDuration)
                    .SetEase(Ease.OutQuad)
                    .OnComplete(() =>
                    {
                        // 移動完了後にフェードアウト
                        FadeOut(AmpText.gameObject);
                    });

                yield break; // コルーチンを終了
            }
        }

        private void FadeOut(GameObject target)
        {
            // フェードアウト
            CanvasGroup canvasGroup = target.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = target.AddComponent<CanvasGroup>();
            }

            canvasGroup.DOFade(0, fadeDuration);
        }

        public void ResetPosition()
        {
            // 初期位置に戻す
            AmpText.transform.localPosition = currentLocalPosition;
            CanvasGroup canvasGroup = AmpText.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 1; // フェードイン
            }
        }
    }
}