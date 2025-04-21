using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using App.Scripts.Game.Documents;

namespace App.Scripts.Game.Tester
{
    public class MiniTester : MonoBehaviour
    {
        [SerializeField] private GameObject BigTester;
        [SerializeField] private float moveDistance = 100f; // 下に移動する距離（ワールド座標系）
        [SerializeField] private float moveDuration = 0.5f; // 移動にかかる時間
        [SerializeField] private List<GameObject> documentsPrefabs;

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

            // 現在のローカルポジションを取得し、下に移動
            Vector3 targetPosition = rectTransform.localPosition - new Vector3(0, moveDistance, 0);
            rectTransform.DOLocalMove(targetPosition, moveDuration)
                .SetEase(Ease.OutQuad)
                .OnComplete(() => isAnimating = false); // アニメーション終了時にフラグをリセット

            // BigTester の Up メソッドを呼び出す
            if (BigTester != null)
            {
                BigTester.GetComponent<BigTester>()?.Up();
            }
            // DocumentsPrefabs の 全要素のIsInCameraがtrueのものに対してDownを実行
            foreach (var documentPrefab in documentsPrefabs)
            {
                if (documentPrefab != null)
                {
                    DocumentsAnimation animation = documentPrefab.GetComponent<DocumentsAnimation>();
                    if (animation != null && animation.IsInCamera())
                    {
                        animation.Down(); // IsInCamera が true の場合に Down を実行
                    }
                }
            }
        }

        public void Up()
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

            // 現在のローカルポジションを取得し、上に移動
            Vector3 targetPosition = rectTransform.localPosition + new Vector3(0, moveDistance, 0);
            rectTransform.DOLocalMove(targetPosition, moveDuration)
                .SetEase(Ease.OutQuad)
                .SetDelay(0.2f)
                .OnComplete(() => isAnimating = false); // アニメーション終了時にフラグをリセット
        }

        public void SetDocuments(List<GameObject> documents)
        {
            documentsPrefabs = documents;
        }
    }
}