using UnityEngine;
using TMPro;
using App.Scripts.Game.Data;

namespace App.Scripts.Game.Demand
{
    public class DemandPrefab : MonoBehaviour
    {
        private _DemandParameter _demandParameter;

        [SerializeField] private TextMeshProUGUI appearanceText;
        [SerializeField] private TextMeshProUGUI ageText;
        [SerializeField] private TextMeshProUGUI genderText;
        [SerializeField] private TextMeshProUGUI backgroundText;
        [SerializeField] private TextMeshProUGUI mbtiText;
        [SerializeField] private TextMeshProUGUI regionText;


        public void SetDemandParameter(_DemandParameter demandParameter)
        {
            _demandParameter = demandParameter;
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (_demandParameter == null)
            {
                Debug.LogError("_DemandParameter is not assigned.");
                return;
            }

            // 各 TextMeshProUGUI コンポーネントに _DemandParameter の値を設定
            if (appearanceText != null) appearanceText.text = $"外見: {_demandParameter.GetAppearance()}";
            if (ageText != null) ageText.text = $"年齢: {_demandParameter.GetAge()}";
            if (genderText != null) genderText.text = $"性別: {_demandParameter.GetGender()}";
            if (backgroundText != null) backgroundText.text = $"来歴: {_demandParameter.GetBackground()}";
            if (mbtiText != null) mbtiText.text = $"MBTI: {_demandParameter.GetMbti()}";
            if (regionText != null) regionText.text = $"出身: {_demandParameter.GetRegion()}";
        }
    }
}