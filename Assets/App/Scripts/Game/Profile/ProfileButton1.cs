using UnityEngine;
using DG.Tweening; // DOTweenを使用するために必要

namespace App.Scripts.Game.Profile
{
    public class ProfileButton1 : MonoBehaviour
    {
        [SerializeField] private GameObject ProfileButton2;
        [SerializeField] private float moveDistance = 100f; // 移動する距離（ローカル座標系）
        [SerializeField] private float moveDuration = 0.5f; // 移動にかかる時間

        private RectTransform rectTransform;

        private void Awake()
        {
            // RectTransform を取得
            rectTransform = GetComponent<RectTransform>();
        }

        public void OnClick()
        {
            if (rectTransform == null)
            {
                Debug.LogError("RectTransform is not assigned or this object is not a UI element.");
                return;
            }

            // 現在のローカルポジションを取得し、左に移動
            Vector3 targetPosition = rectTransform.localPosition - new Vector3(moveDistance, 0, 0);
            rectTransform.DOLocalMove(targetPosition, moveDuration)
                .SetEase(Ease.OutQuad); // イージングを設定

            // ProfileButton2 の Move メソッドを呼び出す
            if (ProfileButton2 != null)
            {
                ProfileButton2.GetComponent<ProfileButton2>()?.Move();
            }
            else
            {
                Debug.LogError("ProfileButton2 is not assigned in the inspector.");
            }
        }

        public void Move()
        {
            if (rectTransform == null)
            {
                Debug.LogError("RectTransform is not assigned or this object is not a UI element.");
                return;
            }

            // 現在のローカルポジションを取得し、右に移動
            Vector3 targetPosition = rectTransform.localPosition + new Vector3(moveDistance, 0, 0);
            rectTransform.DOLocalMove(targetPosition, moveDuration)
                .SetEase(Ease.OutQuad)
                .SetDelay(0.2f); // イージングを設定
        }
    }
}