using UnityEngine;
using TMPro; // TextMeshPro を使用するために必要
using App.Scripts.Game.Data; // _DemandParameter クラスを使用するために必要

namespace App.Scripts.Game.Demand
{
    public class DemandPrefab : MonoBehaviour
    {
        private _DemandParameter _demandParameter;

        // 各項目ごとに別々の TextMeshProUGUI コンポーネントをアタッチ
        [SerializeField] private TextMeshProUGUI appearanceText;
        [SerializeField] private TextMeshProUGUI ageText;
        [SerializeField] private TextMeshProUGUI genderText;
        [SerializeField] private TextMeshProUGUI backgroundText;
        [SerializeField] private TextMeshProUGUI mbtiText;
        [SerializeField] private TextMeshProUGUI regionText;

        private void Start()
        {
            // 初期化処理が必要であればここに記述
        }

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
            if (appearanceText != null) appearanceText.text = $"Appearance: {_demandParameter.GetAppearance()}";
            if (ageText != null) ageText.text = $"Age: {_demandParameter.GetAge()}";
            if (genderText != null) genderText.text = $"Gender: {_demandParameter.GetGender()}";
            if (backgroundText != null) backgroundText.text = $"Background: {_demandParameter.GetBackground()}";
            if (mbtiText != null) mbtiText.text = $"MBTI: {_demandParameter.GetMbti()}";
            if (regionText != null) regionText.text = $"Region: {_demandParameter.GetRegion()}";
        }
    }
}