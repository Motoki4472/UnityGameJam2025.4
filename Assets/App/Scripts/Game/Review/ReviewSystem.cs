using UnityEngine;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;

namespace App.Scripts.Game.Review
{
    public class ReviewSystem : MonoBehaviour
    {
        private _ReviewComment _reviewComment;
        [SerializeField] private float _Star1Time = 50f;
        [SerializeField] private float _Star2Time = 25f;
        private List<string> ReviewComments = new List<string>();
        [SerializeField] private TextMeshProUGUI ReviewText;
        [SerializeField] private GameObject reviewObject;
        [SerializeField] private int targetPosition = 110; // 移動先の位置
        private RectTransform targetTransform; // RectTransformコンポーネントを格納する変数
        public int Star;
        private void Start()
        {
            _reviewComment = new _ReviewComment();
            if (reviewObject != null)
            {
                targetTransform = reviewObject.GetComponent<RectTransform>();
            }
            else
            {
                Debug.LogWarning("reviewObject が設定されていません");
            }
        }
        public void GenerateReviewComment(float TimeToMatching, bool isCorrect)
        {
            string comment = "";
            ReviewComments.Clear();
            System.Random random = new System.Random();
            if(_Star2Time >= TimeToMatching)
            {
                if (isCorrect)
                {
                    Star = 5;
                }
                else
                {
                    Star = 2;
                }
            }
            else if (_Star1Time >= TimeToMatching)
            {
                if(isCorrect)
                {
                    Star = 4;
                }
                else
                {
                    Star = 1;
                }
            }
            else
            {
                if (isCorrect)
                {
                    Star = 3;
                }
                else
                {
                    Star = 0;
                }
            }
            ReviewComments.AddRange(_reviewComment.GetComments(Star));
            for (int i = 0; i < Star; i++)
            {
                comment += "☆";
            }
            for (int i = 0; i < 5 - Star; i++)
            {
                comment += "★";
            }
            comment += "\n" + ReviewComments[random.Next(0, ReviewComments.Count)];

            ReviewText.text = comment;
            PlayReviewAnimation();
        }
        private void PlayReviewAnimation()
        {
            Sequence sequence = DOTween.Sequence();

            sequence
                .Append(targetTransform.DOMoveY(targetPosition, 1f)) // 1秒で指定位置へ
                .AppendInterval(3f)                                  // 3秒間待機
                .Append(targetTransform.DOMoveY(-targetPosition, 1f)); // 1秒で戻る
            
            sequence.Play();
        }
    }
}