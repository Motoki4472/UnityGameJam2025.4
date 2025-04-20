using UnityEngine;
using DG.Tweening; // DOTweenを使用するために必要

namespace App.Scripts.Game.Tester
{
    public class MiniTester : MonoBehaviour
    {
        [SerializeField] private GameObject BigTester;
        [SerializeField] private float moveDistance = 100f; // 下に移動する距離
        [SerializeField] private float moveDuration = 0.5f; // 移動にかかる時間

        public void OnClick()
        {
            // 現在の位置から下に移動
            transform.DOMoveY(transform.position.y - moveDistance, moveDuration)
                .SetEase(Ease.OutQuad); // イージングを設定
            BigTester.GetComponent<BigTester>().Up();
        }
        public void Up()
        {
            // 現在の位置から上に移動
            transform.DOMoveY(transform.position.y + moveDistance, moveDuration)
                .SetEase(Ease.OutQuad)
                .SetDelay(0.2f);
        }
    }
}