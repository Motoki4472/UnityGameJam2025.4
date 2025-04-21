using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using App.Scripts.Game.Documents;

namespace App.Scripts.Game.Profile
{
    public class ProfileButton2 : MonoBehaviour
    {
        [SerializeField] private GameObject ProfileButton1;
        [SerializeField] private float moveDistance = 130f; // 移動する距離（ローカル座標系）
        [SerializeField] private float moveDuration = 0.5f; // 移動にかかる時間
        [SerializeField] private List<GameObject> Profile;

        private RectTransform rectTransform;
        private bool isAnimating = false; // アニメーション中かどうかを管理するフラグ

        private void Awake()
        {
            // RectTransform を取得
            rectTransform = GetComponent<RectTransform>();
        }

        public void OnClick()
        {
            if (isAnimating)
            {
                Debug.Log("Animation is already in progress");
                return;
            }

            if (rectTransform == null)
            {
                Debug.LogError("RectTransform is not assigned or this object is not a UI element.");
                return;
            }

            // アニメーション開始
            isAnimating = true;

            // 現在のローカルポジションを取得し、左に移動
            Vector3 targetPosition = rectTransform.localPosition - new Vector3(moveDistance, 0, 0);
            rectTransform.DOLocalMove(targetPosition, moveDuration)
                .SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    isAnimating = false;
                    Move();
                     // アニメーション終了時にフラグをリセット
                });

            int index = 0;
            foreach (var profile in Profile)
            {
                if (profile != null)
                {
                    DocumentsAnimation animation = profile.GetComponent<DocumentsAnimation>();
                    if (animation != null && animation.IsInCamera())
                    {
                        animation.Down(); // IsInCamera が true の場合に Down を実行
                        index = Profile.IndexOf(profile);
                        index++;
                    }
                }
            }
            if (index >= Profile.Count) index = 0;
            Profile[index].GetComponent<DocumentsAnimation>().Up();
        }

        public void Move()
        {
            if (isAnimating)
            {
                Debug.Log("Animation is already in progress");
                return;
            }

            if (rectTransform == null)
            {
                Debug.LogError("RectTransform is not assigned or this object is not a UI element.");
                return;
            }

            // アニメーション開始
            isAnimating = true;

            // 現在のローカルポジションを取得し、右に移動
            Vector3 targetPosition = rectTransform.localPosition + new Vector3(moveDistance, 0, 0);
            rectTransform.DOLocalMove(targetPosition, moveDuration)
                .SetEase(Ease.OutQuad)
                .SetDelay(0.2f)
                .OnComplete(() => isAnimating = false); // アニメーション終了時にフラグをリセット
        }

        public void SetProfileToButton(List<GameObject> profile)
        {
            Profile = profile;
        }
    }
}