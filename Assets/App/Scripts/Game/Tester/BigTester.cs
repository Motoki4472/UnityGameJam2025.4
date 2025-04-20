using UnityEngine;
using DG.Tweening; // DOTweenを使用するために必要

namespace App.Scripts.Game.Tester
{
    public class BigTester : MonoBehaviour
    {
        [SerializeField] private GameObject miniTester;
        [SerializeField] private float moveDistance = 200f; // 下に移動する距離（ローカル座標系）
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

            // 現在のローカルポジションを取得し、下に移動
            Vector3 targetPosition = rectTransform.localPosition - new Vector3(0, moveDistance, 0);
            rectTransform.DOLocalMove(targetPosition, moveDuration)
                .SetEase(Ease.OutQuad); // イージングを設定

            // miniTester の Up メソッドを呼び出す
            if (miniTester != null)
            {
                MiniTester miniTesterScript = miniTester.GetComponent<MiniTester>();
                if (miniTesterScript != null)
                {
                    miniTesterScript.Up();
                }
                else
                {
                    Debug.LogError("MiniTester script is not attached to the miniTester GameObject.");
                }
            }
        }

        public void Up()
        {
            if (rectTransform == null)
            {
                Debug.LogError("RectTransform is not assigned or this object is not a UI element.");
                return;
            }

            // 現在のローカルポジションを取得し、上に移動
            Vector3 targetPosition = rectTransform.localPosition + new Vector3(0, moveDistance, 0);
            rectTransform.DOLocalMove(targetPosition, moveDuration)
                .SetEase(Ease.OutQuad)
                .SetDelay(0.2f); // イージングを設定
        }
    }
}