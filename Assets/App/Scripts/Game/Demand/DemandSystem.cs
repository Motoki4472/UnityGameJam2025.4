using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using App.Scripts.Game.Profile;
using App.Scripts.Game.Documents;
using App.Game.ProcessSystem;

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
        [SerializeField] private GameObject _profilePrefab;
        [SerializeField] private ProcessSystem _processSystem;
        [SerializeField] private GameObject _canvas;

        public void Start()
        {
            _generateDemand = new _GenerateDemand();
            _generateProfile = new _GenerateProfile();
            _generateMistakeProfile = new _GenerateMistakeProfile();
            _surveyList = new _SurveyList();
        }
        public void GenerateDemandAndProfile()
        {
            List<GameObject> ProfilePrefabList = new List<GameObject>();
            System.Random random = new System.Random();
            _DemandParameter demandParameter = _generateDemand.GenerateDemandParameter(random.Next(0, 4));
            GameObject demandPrefabInstance = Instantiate(_demandPrefab, transform.position, Quaternion.identity);
            demandPrefabInstance.transform.SetParent(_canvas.transform, false);
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
                GameObject profilePrefabInstance = Instantiate(_profilePrefab, transform.position, Quaternion.identity);
                profilePrefabInstance.transform.SetParent(_canvas.transform, false);
                ProfilePrefab profilePrefab = profilePrefabInstance.GetComponent<ProfilePrefab>();
                profilePrefab.SetProfile(ProfileParameter[i]);
                // ProfilePrefabListにProfilePrefabを追加
                ProfilePrefabList.Add(profilePrefabInstance);
                _surveyList.GenerateStudentList(ProfileParameter[i]);
            }
            // Listの中身をランダムに入れ替え
            ProfilePrefabList = ProfilePrefabList.OrderBy(x => random.Next()).ToList();
            _processSystem.SetProfileList(ProfilePrefabList);
        }
    }
}
