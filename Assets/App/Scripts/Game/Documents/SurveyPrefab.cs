using UnityEngine;
using TMPro;
using App.Scripts.Game.Data;

namespace App.Scripts.Game.Documents
{
    public class SurveyPrefab : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI SurveyTitle;
        [SerializeField] private TextMeshProUGUI StudentName;

        public void SetSurvey(_SurveyList surveyList)
        {
            if (surveyList == null)
            {
                Debug.LogError("SurveyList is not assigned.");
                return;
            }

            // 各 TextMeshProUGUI コンポーネントに _SurveyList の値を設定
            if (SurveyTitle != null) SurveyTitle.text = surveyList.GetSurveyTitle();
            if (StudentName != null) StudentName.text = surveyList.GetStudentName();
        }
    }
}
