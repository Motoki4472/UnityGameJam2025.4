using UnityEngine;
using App.Scripts.Game.Profile;
using App.Scripts.Game.Documents;

namespace App.Scripts.Game.Demand
{
    public class DemandSystem : MonoBehaviour
    {
        private _GenerateDemand _generateDemand;
        private _GenerateProfile _generateProfile;
        private _SurveyList _surveyList;
        private _GenerateMistakeProfile _generateMistakeProfile;
        private _ProfileParameter[] ProfileParameter = new _ProfileParameter[3];
        [SerializeField] private GameObject _demandPrefab;

        public void Start()
        {
            _generateDemand = new _GenerateDemand();
            _generateProfile = new _GenerateProfile();
            _generateMistakeProfile = new _GenerateMistakeProfile();
            _surveyList = new _SurveyList();

            GenerateDemandAndProfile();

            
            
        }
        public void GenerateDemandAndProfile()
        {
            System.Random random = new System.Random();
            _DemandParameter demandParameter = _generateDemand.GenerateDemandParameter(random.Next(0, 4));
            // DemandPrefabのインスタンスを生成
            GameObject demandPrefabInstance = Instantiate(_demandPrefab, transform.position, Quaternion.identity);
            // DemandPrefabコンポーネントを取得
            DemandPrefab demandPrefab = demandPrefabInstance.GetComponent<DemandPrefab>();
            // DemandPrefabにパラメータを設定
            demandPrefab.SetDemandParameter(demandParameter);
            for(int i = 0; i < ProfileParameter.Length; i++)
            {
                ProfileParameter[i] = _generateProfile.GenerateProfileParameter(demandParameter);
                if(i != 0)
                {
                    ProfileParameter[i] = _generateMistakeProfile.GenerateMistakeProfileParameter(demandParameter,ProfileParameter[i]);
                    
                }
                _surveyList.GenerateStudentList(ProfileParameter[i]);
            }
        }
    }
}
