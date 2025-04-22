using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using App.Scripts.Game.Profile;
using App.Scripts.Game.Documents;
using App.Scripts.Game.Tester;
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
        [SerializeField] private GameObject _surveyPrefab;
        [SerializeField] private ProcessSystem _processSystem;
        [SerializeField] private List<DocumentsButton> _documentsButton;
        [SerializeField] private List<GameObject> _ProfileButton;
        [SerializeField] private MiniTester  _miniTester; // MiniTesterのインスタンスを取得するための変数
        [SerializeField] private GameObject _ZodiacDocument;
        [SerializeField] private GameObject _canvas;
        [SerializeField] private GameObject _demandAnchor;
        [SerializeField] private GameObject _profileAnchor;
        private Vector3 _demandPosition; // ワールド座標での生成位置
        private Vector3 _profilePosition; // ワールド座標での生成位置
        private List<GameObject> ProfilePrefabList = new List<GameObject>();
        private List<GameObject> SurveyPrefabList = new List<GameObject>();

        public void GenerateDemandAndProfile()
        {
            ProfilePrefabList = new List<GameObject>();
            SurveyPrefabList = new List<GameObject>();
            System.Random random = new System.Random();

            _generateDemand = new _GenerateDemand();
            _generateProfile = new _GenerateProfile();
            _generateMistakeProfile = new _GenerateMistakeProfile();
            _surveyList = new _SurveyList();
            RectTransform demandRect = _demandAnchor.GetComponent<RectTransform>();
            RectTransform profileRect = _profileAnchor.GetComponent<RectTransform>();

            // 生成位置を取得
            _demandPosition = _demandAnchor.transform.position;
            _profilePosition = _profileAnchor.transform.position;
            // DemandPrefabの生成
            _DemandParameter demandParameter = _generateDemand.GenerateDemandParameter(random.Next(0, 4));
            GameObject demandPrefabInstance = Instantiate(_demandPrefab, Vector3.zero, Quaternion.identity);
            demandPrefabInstance.transform.SetParent(_canvas.transform, false);
            demandPrefabInstance.transform.position = _demandPosition; // ワールド座標で移動
            DemandPrefab demandPrefab = demandPrefabInstance.GetComponent<DemandPrefab>();
            demandPrefab.SetDemandParameter(demandParameter);
            _processSystem.SetDemand(demandPrefabInstance);

            // ProfilePrefabの生成
            for (int i = 0; i < ProfileParameter.Length; i++)
            {
                ProfileParameter[i] = _generateProfile.GenerateProfileParameter(demandParameter);
                if (i != 0)
                {
                    ProfileParameter[i] = _generateMistakeProfile.GenerateMistakeProfileParameter(demandParameter, ProfileParameter[i]);
                }

                GameObject profilePrefabInstance = Instantiate(_profilePrefab, Vector3.zero, Quaternion.identity);
                profilePrefabInstance.transform.SetParent(_canvas.transform, false);
                profilePrefabInstance.transform.position = _profilePosition; // ワールド座標で移動
                ProfilePrefab profilePrefab = profilePrefabInstance.GetComponent<ProfilePrefab>();
                profilePrefab.SetProfile(ProfileParameter[i]);
                profilePrefab.SetProcessSystem(_processSystem);
                ProfilePrefabList.Add(profilePrefabInstance);
            }

            // Listの中身をランダムに入れ替え
            ProfilePrefabList = ProfilePrefabList.OrderBy(x => random.Next()).ToList();
            _processSystem.SetProfileList(ProfilePrefabList);

            // SurveyPrefabの生成
            for (int i = 0; i < ProfileParameter.Length; i++)
            {
                _surveyList.GenerateStudentList(ProfileParameter[i]);
                GameObject surveyPrefabInstance = Instantiate(_surveyPrefab, Vector3.zero, Quaternion.identity);
                surveyPrefabInstance.transform.SetParent(_canvas.transform, false);
                surveyPrefabInstance.transform.position = _demandPosition; // ワールド座標で移動
                SurveyPrefab surveyPrefab = surveyPrefabInstance.GetComponent<SurveyPrefab>();
                surveyPrefab.SetSurvey(_surveyList);
                SurveyPrefabList.Add(surveyPrefabInstance);
            }
            _processSystem.SetSurveyList(SurveyPrefabList);

            //すべての_documentsButtonにdemandPrefabとsurveyPrefab3つとzodiacDocumentをこの順でリストにして渡す
            List<GameObject> documentsList = new List<GameObject>();
            documentsList.Add(demandPrefabInstance);
            documentsList.AddRange(SurveyPrefabList);
            documentsList.Add(_ZodiacDocument);
            //documentsList.Add(_ZodiacDocument); // ZodiacDocumentは一旦コメントアウト
            foreach (var documentsButton in _documentsButton)
            {
                documentsButton.SetDocumentPrefabs(documentsList);
            }
            _miniTester.SetDocuments(documentsList);

            if (_ProfileButton.Count == 2)
            {
                // _ProfileButtonの各要素にProfilePrefabListを渡す
                _ProfileButton[0].GetComponent<ProfileButton1>().SetProfileToButton(ProfilePrefabList);
                _ProfileButton[1].GetComponent<ProfileButton2>().SetProfileToButton(ProfilePrefabList);
            }
        }
    }
}