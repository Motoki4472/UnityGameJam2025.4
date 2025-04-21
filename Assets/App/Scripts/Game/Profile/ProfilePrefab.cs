using UnityEngine;
using UnityEngine.UI; // 画像を扱うために必要
using TMPro;
using App.Scripts.Game.Data;
using App.Scripts.Game.Demand;
using App.Game.ProcessSystem;

namespace App.Scripts.Game.Profile
{
    public class ProfilePrefab : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _genderText;
        [SerializeField] private TextMeshProUGUI _ageText;
        [SerializeField] private TextMeshProUGUI _birthdateText;
        [SerializeField] private TextMeshProUGUI _backgroundText;
        [SerializeField] private TextMeshProUGUI _zodiacText;
        [SerializeField] private TextMeshProUGUI _mbtiText;
        [SerializeField] private TextMeshProUGUI _regionText;
        [SerializeField] private GameObject _profileImage; // 画像を格納する変数を追加
        [SerializeField] private bool _isCorrect;
        [SerializeField] private bool _isPhotoEffect;
        [SerializeField] private bool _isBackgroundFraud;
        private ProcessSystem _processSystem;

        public void SetProfile(_ProfileParameter profileParameter)
        {
            if (profileParameter == null)
            {
                Debug.LogError("ProfileParameter is null.");
                return;
            }
            _nameText.text = "名前:" + profileParameter.GetName();
            _genderText.text = "性別:" + profileParameter.GetGender();
            _ageText.text = "年齢:" + profileParameter.GetAge();
            _birthdateText.text = "誕生日:" + profileParameter.GetBirthdate();
            _backgroundText.text = "来歴:" + profileParameter.GetBackground();
            _zodiacText.text = "干支:" + profileParameter.GetZodiac();
            _mbtiText.text = "MBTI:" + profileParameter.GetMbti();
            _regionText.text = "出身:" + profileParameter.GetRegion();

            _isCorrect = profileParameter.GetIsCorrect();
            _isPhotoEffect = profileParameter.GetIsPhotoEffect();
            _isBackgroundFraud = profileParameter.GetIsBackgroundFraud();

            // 画像を設定
            _FaceGenerator faceGenerator = new _FaceGenerator(_profileImage, profileParameter.GetIsPhotoEffect(), profileParameter.GetImageId());
            faceGenerator.GenerateFace();
        }
        public void SetProcessSystem(ProcessSystem processSystem)
        {
            this._processSystem = processSystem;
        }


        public void Match()
        {
            _processSystem.Match(_isCorrect);
        }

        public bool IsCorrect()
        {
            return _isCorrect;
        }
        public bool IsPhotoEffect()
        {
            return _isPhotoEffect;
        }
        public bool IsBackgroundFraud()
        {
            return _isBackgroundFraud;
        }
    }
}