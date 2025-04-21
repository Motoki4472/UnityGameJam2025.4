using UnityEngine;
using TMPro;

namespace App.Scripts.Result.Score
{
    public class ApplyScore : MonoBehaviour
    {
        [SerializeField] private GameObject _resultDataHolder;
        [SerializeField] private GameObject _peakScoreText;
        [SerializeField] private GameObject _finalScoreText;
        private TextMeshProUGUI _peakScoreTMP;
        private TextMeshProUGUI _finalScoreTMP;
        void Start()
        {
            _peakScoreTMP = _peakScoreText.GetComponent<TextMeshProUGUI>();
            _finalScoreTMP = _finalScoreText.GetComponent<TextMeshProUGUI>();

            if (_resultDataHolder != null)
            {
                var resultData = _resultDataHolder.GetComponent<App.Result.Data.ResultDataHolder>();
                if (resultData != null)
                {
                    _peakScoreTMP.text = resultData.maxActiveUserNumber.ToString();
                    _finalScoreTMP.text = resultData.finalActiveUserNumber.ToString();
                }
                else
                {
                    Debug.LogError("ResultDataHolderが見つかりません。");
                }
            }
            else
            {
                Debug.LogError("ResultDataHolderが見つかりません。");
            }
        }
    }
}
