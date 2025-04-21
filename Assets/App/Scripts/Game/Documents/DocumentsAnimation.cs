using UnityEngine;
using DG.Tweening;

namespace App.Scripts.Game.Documents
{
    public class DocumentsAnimation : MonoBehaviour
    {
        [SerializeField] private float moveDistance = 100f; // 下に移動する距離
        [SerializeField] private float moveDuration = 0.5f; // 移動にかかる時間
        private bool isInCamera = false; // 画面内にいるかどうかのフラグ
        private bool isAnimating = false; // アニメーション中かどうかのフラグ

        private RectTransform rectTransform;

        private void Awake()
        {
            // RectTransform を取得
            rectTransform = GetComponent<RectTransform>();
        }

        public void Down()
        {
            if (rectTransform == null)
            {
                Debug.LogError("RectTransform is not assigned or this object is not a UI element.");
                return;
            }
            if (!isInCamera)
            {
                Debug.Log("Already out of camera");
                return;
            }
            if (isAnimating)
            {
                Debug.Log("Animation is already in progress");
                return;
            }

            isAnimating = true; // アニメーション開始
            isInCamera = false;

            // ローカル座標で下に移動
            Vector3 targetPosition = rectTransform.localPosition - new Vector3(0, moveDistance, 0);
            rectTransform.DOLocalMove(targetPosition, moveDuration)
                .SetEase(Ease.OutQuad)
                .OnComplete(() => isAnimating = false); // アニメーション終了時にフラグをリセット
        }

        public void Up()
        {
            if (rectTransform == null)
            {
                Debug.LogError("RectTransform is not assigned or this object is not a UI element.");
                return;
            }
            if (isInCamera)
            {
                Debug.Log("Already in camera");
                return;
            }
            if (isAnimating)
            {
                Debug.Log("Animation is already in progress");
                return;
            }

            isAnimating = true; // アニメーション開始
            isInCamera = true;

            // ローカル座標で上に移動
            Vector3 targetPosition = rectTransform.localPosition + new Vector3(0, moveDistance, 0);
            rectTransform.DOLocalMove(targetPosition, moveDuration)
                .SetEase(Ease.OutQuad)
                .OnComplete(() => isAnimating = false); // アニメーション終了時にフラグをリセット
        }

        public bool IsInCamera()
        {
            return isInCamera;
        }
    }
}