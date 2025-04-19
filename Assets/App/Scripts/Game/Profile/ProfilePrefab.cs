using UnityEngine;
using UnityEngine.UI; // 画像を扱うために必要
using TMPro;
using App.Scripts.Game.Data;
using App.Scripts.Game.Demand;

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
        [SerializeField] private Image _profileImage; // 画像を格納する変数を追加
        [SerializeField] private bool _isCorrect;
        [SerializeField] private bool _isPhotoEffect;
        [SerializeField] private bool _isBackgroundFraud;

        public void SetProfile(_ProfileParameter profileParameter)
        {
            if (profileParameter == null)
            {
                Debug.LogError("ProfileParameter is null.");
                return;
            }

            // テキストを設定
            _nameText.text = profileParameter.GetName();
            _genderText.text = profileParameter.GetGender();
            _ageText.text = profileParameter.GetAge();
            _birthdateText.text = profileParameter.GetBirthdate();
            _backgroundText.text = profileParameter.GetBackground();
            _zodiacText.text = profileParameter.GetZodiac();
            _mbtiText.text = profileParameter.GetMbti();
            _regionText.text = profileParameter.GetRegion();
            _isCorrect = profileParameter.IsCorrect();
            _isPhotoEffect = profileParameter.IsPhotoEffect();
            _isBackgroundFraud = profileParameter.IsBackgroundFraud();

            // 画像を設定
            if (_profileImage != null && profileSprite != null)
            {
                _profileImage.sprite = profileSprite;
            }
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