using UnityEngine;
using DG.Tweening; // DOTweenを使用するために必要

namespace App.Scripts.Game.Profile
{
    public class ProfileButton1 : MonoBehaviour
    {
        [SerializeField] private GameObject ProfileButton2;
        [SerializeField] private float moveDistance = 100f; // 移動する距離
        [SerializeField] private float moveDuration = 0.5f; // 移動にかかる時間

        public void OnClick()
        {
            // 現在の位置から左に移動
            transform.DOMoveX(transform.position.x - moveDistance, moveDuration)
                .SetEase(Ease.OutQuad); // イージングを設定
            ProfileButton2.GetComponent<ProfileButton2>().Move();
        }
        public void Move()
        {
            // 現在の位置から右に移動
            transform.DOMoveX(transform.position.x + moveDistance, moveDuration)
                .SetEase(Ease.OutQuad)
                .SetDelay(0.2f);
        }
    }
}