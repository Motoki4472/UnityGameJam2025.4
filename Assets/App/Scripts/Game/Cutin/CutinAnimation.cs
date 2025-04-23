using UnityEngine;
using DG.Tweening;

namespace App.Scripts.Game.CutIn
{
    public class CutInAnimation : MonoBehaviour
    {
        [SerializeField] private GameObject cutinObject; // カットインのメインオブジェクト
        [SerializeField] private GameObject cutinBuckGround; // カットインの背景オブジェクト
        [SerializeField] private float animationDuration = 0.1f; // アニメーションの時間
        [SerializeField] private float waitDuration = 0.2f; // 中央で待機する時間
        [SerializeField] private Vector3 cutinStartPosition = new Vector3(1000, 0, 0); // カットイン開始位置（画面右）
        [SerializeField] private Vector3 cutinEndPosition = new Vector3(0, 0, 0); // カットイン終了位置（画面中央）
        [SerializeField] private Vector3 cutinExitPosition = new Vector3(-1000, 0, 0); // カットイン終了後の位置（画面左）
        [SerializeField] private float backgroundHeight = 500f; // 背景の縦幅

        public void PlayCutin()
        {
            if (cutinObject == null || cutinBuckGround == null)
            {
                Debug.LogError("CutinObject or CutinBuckGround is not assigned.");
                return;
            }

            // 背景の縦幅をアニメーション
            RectTransform backgroundRect = cutinBuckGround.GetComponent<RectTransform>();
            if (backgroundRect == null)
            {
                Debug.LogError("CutinBuckGround does not have a RectTransform.");
                return;
            }

            backgroundRect.sizeDelta = new Vector2(backgroundRect.sizeDelta.x, 0); // 縦幅を0に設定
            backgroundRect.DOSizeDelta(new Vector2(backgroundRect.sizeDelta.x, backgroundHeight), animationDuration) // 縦幅を広げる
                .SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    // カットインオブジェクトをスライドイン
                    RectTransform cutinRectTransform = cutinObject.GetComponent<RectTransform>();
                    if (cutinRectTransform == null)
                    {
                        Debug.LogError("CutinObject does not have a RectTransform.");
                        return;
                    }

                    cutinRectTransform.localPosition = cutinStartPosition; // 開始位置に設定
                    cutinRectTransform.DOLocalMove(cutinEndPosition, animationDuration)
                        .SetEase(Ease.OutQuad) // 滑らかなアニメーション
                        .OnComplete(() =>
                        {
                            // 中央で待機後、左に流れる
                            DOVirtual.DelayedCall(waitDuration, () =>
                            {
                                cutinRectTransform.DOLocalMove(cutinExitPosition, animationDuration)
                                    .SetEase(Ease.InQuad) // 滑らかに左に流れる
                                    .OnComplete(() =>
                                    {
                                        // 背景を元の縦幅に戻す
                                        backgroundRect.DOSizeDelta(new Vector2(backgroundRect.sizeDelta.x, 0), animationDuration)
                                            .SetEase(Ease.InQuad);
                                    });
                            });
                        });
                });


        }
    }
}