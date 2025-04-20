using UnityEngine;
using DG.Tweening;

namespace App.Scripts.Game.Documents
{
    public class DocumentsAnimation : MonoBehaviour
    {
        [SerializeField] private float moveDistance = 100f; // 下に移動する距離
        [SerializeField] private float moveDuration = 0.5f; // 移動にかかる時間

        public void Down()
        {
            transform.DOMoveY(transform.position.y - moveDistance, moveDuration)
                .SetEase(Ease.OutQuad);

        }

        public void Up()
        {

            transform.DOMoveY(transform.position.y + moveDistance, moveDuration)
                .SetEase(Ease.OutQuad);
        }
    }
}